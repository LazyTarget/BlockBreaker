using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel (string name) {
		Debug.Log("LoadLevel() Name: " + name);
		Application.LoadLevel(name);
	}

	public void Quit(){
		Debug.Log("Quit()");
		Application.Quit();
	}
}
