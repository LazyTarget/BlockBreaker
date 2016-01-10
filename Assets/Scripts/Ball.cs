using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;

	private bool _launched;
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!_launched) {
			this.transform.position = paddle.transform.position + paddleToBallVector;
			
			if (Input.GetMouseButton(0)) {
				Launch();
			}
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
