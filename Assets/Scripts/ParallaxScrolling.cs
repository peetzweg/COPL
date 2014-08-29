using UnityEngine;
using System.Collections;

public class ParallaxScrolling : MonoBehaviour {


	public GameObject prefabObject;
	public int prefabScale;
	public float speed;
	public bool random=false;
	public int min=0;
	public int max=50;



	private GameObject player;
	// Use this for initialization
	void Start () {
		// get player for player dependet parallax
		this.player = GameObject.Find("/Tottens");

		// generate a stream of ground texture
		for(int i = 0; i < 100; i++){
			SpriteRenderer sp = prefabObject.renderer as SpriteRenderer;
			float xOffset;
			if(this.random){
				xOffset = Random.Range(this.min,this.max);
			}else{
				xOffset= sp.sprite.texture.width/this.prefabScale;
			}
			GameObject obj = Instantiate (prefabObject, prefabObject.transform.position + new Vector3(xOffset*i, 0, 0), prefabObject.transform.rotation) as GameObject;
			 
			obj.transform.parent = this.transform;
		}

	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position -= new Vector3(this.player.rigidbody2D.velocity.x*speed,0,0);
	}
}
