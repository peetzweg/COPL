using UnityEngine;
using System.Collections;

public class Distance : MonoBehaviour {

	private GameObject player;
	// Use this for initialization
	void Start () {
		this.player = GameObject.Find("/Tottens");
	}
	
	// Update is called once per frame
	void Update () {
		this.guiText.text = Mathf.FloorToInt(this.player.transform.position.x/2) +"m";
	}
}
