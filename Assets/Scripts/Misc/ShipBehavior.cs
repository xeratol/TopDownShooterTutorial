using UnityEngine;
using System.Collections;

public class ShipBehavior : MonoBehaviour {

	public float maxHealth = 100;
	private float _health = 0;
	
	public float healthBarYOffset = 50;
	public float healthBarMaxWidth = 100;
	private float _healthBarWidth;
	public float healthBarHeight = 10;
	private Vector2 _healthBarPos;
	public GUIStyle healthBar;
	public GUIStyle healthBarBkgd;

	public Transform deathAnimation;
	
	void Start () {
		_health = maxHealth;

		// TODO:
		// Set constraints: Position.Y, Rotation.X, Rotation.Z
	}
	
	// to be called by the weapons that hit this ship
	public void GetDamage (float amount) {
		_health -= amount;
		if (_health <= 0)
			Died ();
	}
	
	void Died () {
		// boom?
		Destroy (gameObject);
		if (deathAnimation)
			Instantiate(deathAnimation, transform.position, transform.rotation);
		
		// tell level manager i'm dead
		if (tag == "Player")
			GameObject.Find("LevelManager").SendMessage("PlayerDestroyed");
		else
			GameObject.Find("LevelManager").SendMessage("EnemyDestroyed");
	}
	
	void Update () {
		_healthBarPos = 
			Camera.main.WorldToScreenPoint(transform.position);
		_healthBarPos.x -= healthBarMaxWidth * 0.5f;
		_healthBarPos.y = 
			Screen.height - _healthBarPos.y - healthBarYOffset;
		_healthBarWidth = healthBarMaxWidth * _health / maxHealth;
	}
	
	void OnGUI () {
		GUI.Label(new Rect(_healthBarPos.x, _healthBarPos.y, 
		                   healthBarMaxWidth, healthBarHeight),
		          "", healthBarBkgd);
		GUI.Label(new Rect(_healthBarPos.x, _healthBarPos.y, 
		                   _healthBarWidth, healthBarHeight), 
		          "", healthBar);
	}
}
