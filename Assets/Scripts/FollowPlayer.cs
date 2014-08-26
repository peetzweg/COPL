using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	public float xOffset = 6;
	private GameObject player;
	// Use this for initialization
	void Start () {
		this.player = GameObject.Find("/Tottens");
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3(this.player.transform.position.x + this.xOffset, 0, -10);
	}
}
