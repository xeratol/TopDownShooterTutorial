using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class WASDMovement : MonoBehaviour {
	
	public float forceMultiplier = 100;
	public Vector2 limits;
	
	void Start () {
		rigidbody.useGravity = false;
	}
	
	void FixedUpdate () {
		/* movement */
		Vector3 mvmtForce = Vector3.zero;
		mvmtForce.x = Input.GetAxis("Horizontal") * forceMultiplier;
		mvmtForce.z = Input.GetAxis("Vertical") * forceMultiplier;
		rigidbody.AddForce(mvmtForce);
		
		/* limit position */
		Vector3 pos = transform.position;
		if (pos.x < -limits.x)		pos.x = -limits.x;
		else if (pos.x > limits.x)	pos.x = limits.x;
		if (pos.z < -limits.y)		pos.z = -limits.y;
		else if (pos.z > limits.y)	pos.z = limits.y;
		transform.position = pos;
	}

	void OnDrawGizmosSelected () {
		Gizmos.DrawWireCube(Vector3.zero, new Vector3(limits.x * 2, 1, limits.y * 2));
	}
}
