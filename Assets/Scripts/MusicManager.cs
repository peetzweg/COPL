using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
	private static MusicManager instance;
	public AudioClip[] soundtrack;

	void Awake(){
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}

	void Start () {
		if(!this.audio.isPlaying){
			int trackNo = Random.Range(0, this.soundtrack.Length-1);
			this.audio.clip = this.soundtrack[trackNo];
			this.guiText.text = this.soundtrack[trackNo].name;
			
			this.audio.Play();
		}	
	}

}
