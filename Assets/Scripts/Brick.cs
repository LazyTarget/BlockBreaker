using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public static int breakableCount = 0;

	private LevelManager lvlManager;
	private int timesHit;
	private bool isBreakable;

	public Sprite[] hitSprites;
	public AudioClip crackAudio;
	
	// Use this for initialization
	void Start () {
		timesHit = 0;
		lvlManager = GameObject.FindObjectOfType<LevelManager>();

		isBreakable = this.tag == "Breakable";
		if (isBreakable) {
			breakableCount++;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	private void OnCollisionEnter2D(Collision2D collision) {
		print ("Brick:Collision()");
		//AudioSource.PlayClipAtPoint(crackAudio, transform.position);
		AudioSource.PlayClipAtPoint(crackAudio, transform.position, 0.2f);

		if (isBreakable) {
			HandleHits();
		}
	}

	private void HandleHits() {
		timesHit++;
		var maxHits = hitSprites.Length + 1;
		print ("Brick:HandleHits() Times hit: " + timesHit + "/" + maxHits);
		if (timesHit >= maxHits) {
			breakableCount--;
			print ("Brick:HandleHits() Brick destroyed, bricks left: " + breakableCount);
			Destroy(gameObject);

			//lvlManager.BrickDestroyed ();
			if (breakableCount <= 0) {
				lvlManager.LoadNextLevel();
			}
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

}
