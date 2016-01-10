using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		int worldUnits = 16;
		var mousePosInBlocks = Input.mousePosition.x / Screen.width * worldUnits;
		mousePosInBlocks = Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f);
		var vector = new Vector3(mousePosInBlocks, this.transform.position.y, this.transform.position.z);
		this.transform.position = vector;
	}
}
