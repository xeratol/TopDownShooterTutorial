using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public Transform [] enemyTypes;
	private int enemyCount = 0;

	IEnumerator Start () {
		while (true) {
			LaunchWave01();
			yield return StartCoroutine( EnemyCountLessThan(1) );
			LaunchWave02();
			yield return new WaitForSeconds(1);
		}
	}

	void OnTriggerExit (Collider other) {
		// destroys weapons, enemies, etc
		Destroy(other.gameObject);

		if (other.GetComponent<ShipBehavior>())
			enemyCount--;
	}

	IEnumerator EnemyCountLessThan(int n) {
		while (enemyCount >= n) {
			yield return null; // skip a frame
		}
	}

	// should be called by enemy ship when they die
	void EnemyDestroyed () {
		enemyCount--;
	}

	// should be called by player when it dies
	IEnumerator PlayerDestroyed() {
		// wait 2 seconds
		yield return new WaitForSeconds(2);
		// restart level
		Application.LoadLevel(Application.loadedLevel);
	}

	void LaunchWave01 () {
		// 3 enemies just moving forward
		Instantiate(enemyTypes[0], new Vector3(-14, 0, 25), Quaternion.Euler(0, -180, 0));
		Instantiate(enemyTypes[0], new Vector3(0, 0, 30), Quaternion.Euler(0, -180, 0));
		Instantiate(enemyTypes[0], new Vector3(14, 0, 35), Quaternion.Euler(0, -180, 0));

		enemyCount += 3;
	}

	void LaunchWave02 () {
		Transform e = Instantiate (enemyTypes[0], 
		                           new Vector3(26, 0, 0), 
		                           Quaternion.Euler(0,-90,0)) 
			as Transform;
		e.gameObject.AddComponent<SetPlayerAsTarget>();

		e = Instantiate (enemyTypes[0], 
		                           new Vector3(-26, 0, 0), 
		                           Quaternion.Euler(0,90,0)) 
			as Transform;
		e.gameObject.AddComponent<SetPlayerAsTarget>();
		e.gameObject.AddComponent<IntervalAttack>().weapon =
			Resources.Load<Transform>("Ammo/Enemy Missile");

		enemyCount += 2;
	}

	void LaunchWave03 () {
		// something
	}
}
