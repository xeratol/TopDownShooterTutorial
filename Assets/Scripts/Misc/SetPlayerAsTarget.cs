using UnityEngine;
using System.Collections;

[RequireComponent(typeof(FollowTarget))]

public class SetPlayerAsTarget : MonoBehaviour {

	void Start () {
		FollowTarget t = GetComponent<FollowTarget>();
		t.target = GameObject.FindWithTag("Player").transform;
	}
}
