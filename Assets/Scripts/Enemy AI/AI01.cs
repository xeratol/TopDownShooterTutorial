using UnityEngine;
using System.Collections;

public class AI01 : MonoBehaviour {

	void State_BasicMovement () {
		state = State.BasicMovement;

		constantForce.relativeForce = new Vector3 (0, 0, 10);

		followTarget.enabled = false;
		setPlayerAsTarget.enabled = false;
	}

	void State_Chasing () {
		state = State.Chasing;

		constantForce.relativeForce = new Vector3 (0, 0, 10);

		setPlayerAsTarget.enabled = true;
		followTarget.enabled = true;
		followTarget.turningSpeed = 180;
	}

	void State_Strafing () {
		state = State.Strafing;

		// freeze the ship
		rigidbody.velocity = Vector3.zero;
		rigidbody.angularVelocity = Vector3.zero;

		constantForce.relativeForce = new Vector3 (10, 0, 0);
	}

	enum State {
		BasicMovement,
		Chasing,
		Strafing
	};
	State state;
	FollowTarget followTarget;
	SetPlayerAsTarget setPlayerAsTarget;

	IEnumerator Start () {
		gameObject.AddComponent<Rigidbody>();
		gameObject.AddComponent<ConstantForce>();
		followTarget =
			gameObject.AddComponent<FollowTarget>();
		setPlayerAsTarget = 
			gameObject.AddComponent<SetPlayerAsTarget>();

		rigidbody.useGravity = false;
		rigidbody.drag = 1;
		rigidbody.constraints = 
			RigidbodyConstraints.FreezeRotationX |
			RigidbodyConstraints.FreezeRotationZ |
			RigidbodyConstraints.FreezePositionY;

		// Starting state
		State_BasicMovement();

		yield return new WaitForSeconds(2);

		// Change to chasing state
		State_Chasing();
	}
	
	void Update () {
		//Debug.Log(Vector3.Distance(followTarget.target.position, transform.position));
		switch (state) {
		case State.BasicMovement:
			break;
		case State.Chasing:
			if (Vector3.Distance(followTarget.target.position,
			                     transform.position) < 10) {
				State_Strafing();
			}
			break; 
		case State.Strafing:
			if (Vector3.Distance(followTarget.target.position,
			                     transform.position) > 12) {
				State_Chasing();
			}
			break;
		}
	}
}
