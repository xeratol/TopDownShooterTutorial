using UnityEngine;
using System.Collections;

public class DamageOverTime : MonoBehaviour {

	public float dps = 30;
	
	void OnTriggerStay (Collider other) {
		other.SendMessage("GetDamage",
			dps * Time.deltaTime,
            SendMessageOptions.DontRequireReceiver);
	}
}
