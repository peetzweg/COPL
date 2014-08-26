using UnityEngine;
using System.Collections;

public class RandomMusic : MonoBehaviour {

	public AudioClip[] soundtrack;
	// Use this for initialization
	void Start () {
		int trackNo = Random.Range(0, this.soundtrack.Length-1);
		this.audio.clip = this.soundtrack[trackNo];
		this.audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
