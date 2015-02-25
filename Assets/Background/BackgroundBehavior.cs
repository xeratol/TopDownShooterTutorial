using UnityEngine;
using System.Collections;

public class BackgroundBehavior : MonoBehaviour {

	public float scrollSpeed = 0.5f;

	void Update () {
		float yOffset = Time.time * scrollSpeed;
		renderer.material.mainTextureOffset = new Vector2(0, yOffset);
	}
}
