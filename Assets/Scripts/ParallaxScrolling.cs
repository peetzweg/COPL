using UnityEngine;
using System.Collections;

public class ParallaxScrolling : MonoBehaviour {

	public int speed = 1;
	private GameObject player;
	// Use this for initialization
	void Start () {
		this.player = GameObject.Find("/Tottens");
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position -= new Vector3(speed/10000f*this.player.rigidbody2D.velocity.x,0,0);
	}
}
