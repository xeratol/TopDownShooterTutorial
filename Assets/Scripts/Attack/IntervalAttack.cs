using UnityEngine;
using System.Collections;

public class IntervalAttack : MonoBehaviour {
	
	public Transform weapon;
	public float initialDelay = 2; // seconds before first attack
	public float interval = 0.5f; // seconds between each attack
	public int numTimes = -1; // -1 is unlimited attacks
	public bool attachToThis = false;

	IEnumerator Start () {
		yield return new WaitForSeconds(initialDelay);
		
		while (numTimes != 0) {
			numTimes--;
			Transform w = Instantiate(weapon,
				transform.position, transform.rotation)
				as Transform;
			if (attachToThis)
				w.parent = transform;
			yield return new WaitForSeconds(interval);
		}
	}
}
