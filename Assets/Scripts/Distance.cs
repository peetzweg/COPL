using UnityEngine;
using System.Collections;

public class Distance : MonoBehaviour {

	private GameObject player;

	static int distance;
	// Use this for initialization
	void Start () {
		this.player = GameObject.Find("/Tottens");
	}
	
	// Update is called once per frame
	void Update () {
		distance = Mathf.FloorToInt(player.transform.position.x/2);
		this.guiText.text = distance +"m";
	}

	public static void saveDistance(){
		PlayerPrefs.SetInt("LastDistance", distance);
	}

}
