using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel (string name) {
		Debug.Log("LoadLevel() Name: " + name);
		Brick.breakableCount = 0;
		Application.LoadLevel(name);
	}

	public void LoadNextLevel() {
		Debug.Log("LoadNextLevel() Loaded Level: " + Application.loadedLevelName);
		Brick.breakableCount = 0;
		Application.LoadLevel(Application.loadedLevel + 1);
	}

	public void Quit(){
		Debug.Log("Quit()");
		Application.Quit();
	}


	public void BrickDestroyed() {
		if (Brick.breakableCount <= 0) {
			LoadNextLevel();
		}
	}
}
