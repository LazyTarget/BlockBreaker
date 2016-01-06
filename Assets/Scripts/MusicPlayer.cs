using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	private static MusicPlayer _instance = null;

	void Awake() {
		if (_instance != null) {
			// Don't create new music players if one already exists
			Destroy(gameObject);
		}
		else {
			// Don't destroy the music player when changing scenes
			_instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
