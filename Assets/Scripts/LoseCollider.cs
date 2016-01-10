using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	
	public LevelManager lvlManager;

	private void OnTriggerEnter2D(Collider2D trigger) {
		print ("LoseCollider:Trigger()");
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		print ("LoseCollider:Collision()");
		lvlManager.LoadLevel("Lose");
	}
}
