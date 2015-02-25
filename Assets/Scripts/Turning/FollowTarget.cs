using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {

	public Transform target;
	public float turningSpeed = 1000000; // arbitrarily huge
	
	void Update () {
		if (!target) return;
		// Facing a target in 3D space
		Quaternion rotToTarget = Quaternion.LookRotation(target.position - 
			transform.position);
		transform.rotation = Quaternion.RotateTowards(transform.rotation,
			rotToTarget, turningSpeed * Time.deltaTime);
	}
	
	public void SetTarget (Transform newTarget) {
		target = newTarget;
	}
	
	void OnDrawGizmos () {
		Gizmos.color = Color.cyan;
		Gizmos.DrawRay(transform.position, transform.forward * 5);
		if (target) {
			Gizmos.color = Color.blue;
			Gizmos.DrawLine(transform.position, target.position);
		}
	}
}
