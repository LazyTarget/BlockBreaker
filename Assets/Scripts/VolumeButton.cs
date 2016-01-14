using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VolumeButton : MonoBehaviour {

	public MusicPlayer MusicPlayer { get { return MusicPlayer.Instance; } }
	public Sprite MuteSprite;
	public Sprite NoVolumeSprite;
	public Sprite LowVolumeSprite;
	public Sprite HighVolumeSprite;

	void Awake () {
		Debug.Log("VolumeButton:Awake() ::" + GetInstanceID ());
	}

	// Use this for initialization
	void Start () {
		Debug.Log("VolumeButton:Start() ::" + GetInstanceID ());
		
		/*
		if (MusicPlayer == null) {
			Debug.Log("Getting instance from singleton");
			MusicPlayer = MusicPlayer.Instance;
		}
		*/
	}
	
	// Update is called once per frame
	void Update () {
		if (MusicPlayer == null){
			return;
		}
		
		var volumeButton = GetComponent<Image>();
		//var volumeButton = VolumeButton;
		/*
		if (MusicPlayer.audio.mute) {
			volumeButton.sprite = MuteSprite;
		} else if (MusicPlayer.audio.volume <= 0) {
			volumeButton.sprite = NoVolumeSprite;
		} else if (MusicPlayer.audio.volume <= 0.5) {
			volumeButton.sprite = LowVolumeSprite;
		} else {
			volumeButton.sprite = HighVolumeSprite;
		}
		*/

		if (AudioListener.volume <= 0) {
			volumeButton.sprite = MuteSprite;
		} else if (AudioListener.volume <= 0) {
			volumeButton.sprite = NoVolumeSprite;
		} else if (AudioListener.volume <= 0.5) {
			volumeButton.sprite = LowVolumeSprite;
		} else {
			volumeButton.sprite = HighVolumeSprite;
		}
	}
	
	public void Click() {
		Debug.Log("VolumeButton:Click() ::" + GetInstanceID());
		if (MusicPlayer == null){
			return;
		}

		/*
		if (MusicPlayer.audio.mute) {
			MusicPlayer.audio.volume = 0.25f;
			MusicPlayer.audio.mute = false;
		} else if (MusicPlayer.audio.volume <= 0) {
			MusicPlayer.audio.volume = 0.50f;
		} else if (MusicPlayer.audio.volume <= 0.5f) {
			MusicPlayer.audio.volume = 0.75f;
		} else {
			MusicPlayer.audio.mute = true;
		}
		*/

		if (AudioListener.volume <= 0) {
			AudioListener.volume = 1.0f;
		} else if (AudioListener.volume <= 0.50f) {
			AudioListener.volume = 0;
		} else {
			AudioListener.volume = 0.50f;
		}
		Debug.Log("Music volume: " + AudioListener.volume + " (mute=" + (AudioListener.volume <= 0) + ")");
	}
}
