using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	private int bestDistance=0;
	private int lastDistance=0;
	// Use this for initialization
	void Start () {
		this.bestDistance = PlayerPrefs.GetInt("BestDistance");
		this.lastDistance = PlayerPrefs.GetInt("LastDistance");
		if(this.lastDistance > this.bestDistance){
			this.bestDistance = this.lastDistance;
			PlayerPrefs.SetInt("BestDistance",this.bestDistance);
		}
		this.guiText.text = "last: "+ this.lastDistance +"\nbest: "+ this.bestDistance;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
