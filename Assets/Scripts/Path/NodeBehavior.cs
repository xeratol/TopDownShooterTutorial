using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]

public class NodeBehavior : MonoBehaviour {
	
	public Transform nextTarget;

	void Start () {
		collider.isTrigger = true;
	}
	
	void OnTriggerEnter (Collider other) {
		FollowTarget followTargetOfOther =
			other.GetComponent<FollowTarget>();

		// if the 'other' is not following this node
		if (followTargetOfOther == null ||
		    followTargetOfOther.target != transform) {
			// do nothing
			return;
		}

		// change target
		if (nextTarget) {
			followTargetOfOther.target = nextTarget;
		}
	}
	
	void OnDrawGizmos () {
		Gizmos.DrawCube(transform.position, Vector3.one);
		if (nextTarget) {
			Gizmos.color = Color.green;
			Gizmos.DrawLine(transform.position, 
			                nextTarget.position);
		}
	}
}
