using UnityEngine;
using System.Collections;

// TODO: Should be called DamageOnImpact
public class Kamikazee : MonoBehaviour {
	
	public int damage = 50;
	
	void OnCollisionEnter (Collision info) {
		ShipBehavior ship = info.collider.GetComponent<ShipBehavior>();
		if (ship)
			ship.GetDamage(damage);
		
		Destroy(gameObject);
	}
}
