using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	private const int WORLD_UNITS = 16;

	public Ball ball;
	public bool autoPlay = false;

	void Start () {
		if (ball == null) {
			ball = GameObject.FindObjectOfType<Ball>();
		}
	}

	void Update () {
		if (!ball.Launched || !autoPlay) {
			MoveWithMouse();
		} else {
			AutoMove();
		}
	}

	private void MoveWithMouse() {
		var mousePosInBlocks = Input.mousePosition.x / Screen.width * WORLD_UNITS;
		mousePosInBlocks = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);
		var vector = new Vector3(mousePosInBlocks, this.transform.position.y, this.transform.position.z);
		this.transform.position = vector;
	}

	private void AutoMove() {
		var ballPosInBlocks = ball.transform.position.x;
		ballPosInBlocks = Mathf.Clamp(ballPosInBlocks, 0.5f, 15.5f);
		var vector = new Vector3(ballPosInBlocks, this.transform.position.y, this.transform.position.z);
		this.transform.position = vector;
	}
}
