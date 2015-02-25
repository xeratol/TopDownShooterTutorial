using UnityEngine;
using System.Collections;

public class SurroundAttack : MonoBehaviour {

	public Transform weapon;
	public float initialDelay = 2;
	public int divisions = 6;
	public float intervalBetweenDivisions = 0.1f;
	public float intervalBetweenCircles = 0.5f;
	private float _angleIncrement;
	public int numTimes = -1; // -1 means infinite
	public bool attachToThis = false;
	
	IEnumerator Start () {
		_angleIncrement = 360/divisions;
		
		yield return new WaitForSeconds(initialDelay);
		
		while (numTimes != 0) {
			numTimes--;
			for (int i = 0; i < divisions; i++) {
				Transform w = Instantiate(weapon, transform.position, transform.rotation) as Transform;
				w.Rotate(transform.up, i * _angleIncrement);
				if (attachToThis)
					w.parent = transform;
				if (intervalBetweenDivisions > 0)
					yield return new WaitForSeconds(intervalBetweenDivisions);
			}
			yield return new WaitForSeconds(intervalBetweenCircles);
		}
	}
}
