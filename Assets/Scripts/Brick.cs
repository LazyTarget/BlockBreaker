using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	private LevelManager lvlManager;
	private int timesHit;

	public Sprite[] hitSprites;
	
	// Use this for initialization
	void Start () {
		timesHit = 0;
		lvlManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	private void OnCollisionEnter2D(Collision2D collision) {
		print ("Brick:Collision()");
		if (this.tag != "Breakable") {
			return;
		}

		HandleHits();
	}

	private void HandleHits() {
		timesHit++;
		var maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			print ("Brick:Collision() Reached max hits");
			Destroy(gameObject);
		}
		else {
			LoadHitSprite();
		}
	}

	private void LoadHitSprite() {
		if (timesHit < 1) {
			return;
		}
		var spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}

	private void SimulateWin() {
		lvlManager.LoadNextLevel();
	}
}
