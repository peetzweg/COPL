using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{
	private static MusicManager instance;
	private int currentTrack = 0;
	private bool changeMusic;
	public AudioClip[] soundtrack;

	void Awake()
	{
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}

	void Update()
	{
		if (!this.audio.isPlaying) {
			startRandomTrack();

		}
		if (Input.touchCount > 0) {
			foreach (Touch touch in Input.touches) {
				if (this.guiText.HitTest(touch.position)) {
					this.changeMusic = true;
				}
			}
		} else if (this.changeMusic) {
			startNextTrack();
			this.changeMusic = false;
		}
	}

	void startRandomTrack()
	{
		int trackNo = Random.Range(0, this.soundtrack.Length - 1);
		this.audio.clip = this.soundtrack [trackNo];
		this.guiText.text = this.soundtrack [trackNo].name;
			
		this.audio.Play();
		this.currentTrack = trackNo;
	}

	void startNextTrack()
	{
		if (this.currentTrack < this.soundtrack.Length - 1) {
			this.currentTrack++;
		} else {
			this.currentTrack = 0;
		}
		
		this.audio.clip = this.soundtrack [this.currentTrack];
		this.guiText.text = this.soundtrack [this.currentTrack].name;
		
		this.audio.Play();
	}

}
