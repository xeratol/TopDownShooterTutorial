using UnityEngine;
using System.Collections;

public class Expiration : MonoBehaviour {

	public float duration = 1;

	void Start () {
		Destroy(gameObject, duration);
	}
}
