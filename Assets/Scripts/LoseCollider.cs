using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	
	public LevelManager lvlManager;

	private void OnTriggerEnter2D(Collider2D trigger) {
		print ("trigger");
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		print ("collision");
		lvlManager.LoadLevel("Lose");
	}
}
