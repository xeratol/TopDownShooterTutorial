using UnityEngine;
using System.Collections;

public class InputKeyAttack : MonoBehaviour {
	
	public Transform weapon;
	public KeyCode key;
	public float cooldown = 0.5f;
	private float _lastFire = -10000; // arbitrarily large negative number
	public bool attachToThis = false;

	void Update () {
		if (Input.GetKey(key) && _lastFire < Time.time - cooldown) {
			Transform w = Instantiate(weapon, transform.position,
				transform.rotation) as Transform;
			if (attachToThis)
				w.parent = transform;
			_lastFire = Time.time;
		}
	}
}
