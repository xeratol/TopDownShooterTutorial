using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour {
	
	public float turningSpeed = 1000000; // arbitrarily huge
	private Plane refPlane;

	void Start () {
		// refPlane is the x-z plane (where y = 0)
		refPlane = new Plane(Vector3.up, Vector3.zero);
	}
	
	void Update () {
		// Get mouse world coordinates
		Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
		float dist;
		refPlane.Raycast(r, out dist);
		Vector3 worldMousePos = r.GetPoint(dist);
		
		// Facing a target in 3D space
		Quaternion rotToTarget = 
			Quaternion.LookRotation(worldMousePos - transform.position);
		transform.rotation = Quaternion.RotateTowards(transform.rotation,
													  rotToTarget,
		                                              turningSpeed * Time.deltaTime);
	}
}
