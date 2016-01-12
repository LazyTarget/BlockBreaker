using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	
	private LevelManager lvlManager;

	void Start() {
		lvlManager = GameObject.FindObjectOfType<LevelManager>();
	}

	private void OnTriggerEnter2D(Collider2D trigger) {
		print ("LoseCollider:Trigger()");
		Lose ();
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		print ("LoseCollider:Collision()");
		Lose ();
	}

	private void Lose() {
		print ("Ball bounced " + Ball.bounces + " times during game");
		lvlManager.LoadLevel("Lose");
	}
}
