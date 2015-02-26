using UnityEngine;
using System.Collections;

public class DamageOnImpact : MonoBehaviour {
	
	public int damage = 50;
	
	void OnCollisionEnter (Collision info) {
		ShipBehavior ship = info.collider.GetComponent<ShipBehavior>();
		if (ship)
			ship.GetDamage(damage);
		
		Destroy(gameObject);
	}
}
