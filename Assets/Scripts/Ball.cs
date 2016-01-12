using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public static int bounces;

	private Paddle _paddle;
	private bool _launched;
	private Vector3 _paddleToBallVector;

	// Use this for initialization
	void Start () {
		bounces = 0;
		_paddle = GameObject.FindObjectOfType<Paddle>();
		_paddleToBallVector = this.transform.position - _paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!_launched) {
			this.transform.position = _paddle.transform.position + _paddleToBallVector;
			
			if (Input.GetMouseButton(0)) {
				Launch();
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		//print ("Ball:Collision()");

		if (_launched) {
			// Ball doesn't trigger oncollision when brick is destroyed ?
			// Not 100% sure why, possibly because brick isn't there
			audio.Play();
			bounces++;
			

			// todo: should not tweak twice if hit two blocks at the same time?
			// tweak needed?
			Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
			rigidbody2D.velocity += tweak;
		}
	}

	private void Launch() {
		if (_launched) {
			return;
		}
		_launched = true;
		this.rigidbody2D.velocity = new Vector2(2f, 8f);
	}

}
