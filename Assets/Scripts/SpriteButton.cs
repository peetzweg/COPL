using UnityEngine;
using System.Collections;

public class SpriteButton : MonoBehaviour {
	private SpriteRenderer sp;
	private BoxCollider2D bc2d;
	private bool pressed = false;
	public Sprite unpressedSprite, pressedSprite;

	void Start () {
		this.sp = this.renderer as SpriteRenderer;
		this.sp.sprite = this.unpressedSprite;


		// adding a Collider, otherwise the mouse/touch hit's won't be detected
		this.gameObject.AddComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		// if there are any touches
		if (Input.touchCount > 0) {
			// go over all touches
			foreach (Touch touch in Input.touches){
				// check if button is pressed, if pressed leave method
				checkIfPressed(touch.position.x, touch.position.y);
			}	
		}
		// also check left mouse button for debuging purposes
		else if(Input.GetMouseButton(0)) {
			Debug.Log("Checking if mouse hits the object");
			checkIfPressed(Input.mousePosition.x, Input.mousePosition.y);
		}
		else {
			// return to unpressed state if no touches or mouse click detected
			if(this.pressed){
				this.pressed = false;
			}
		}

		if(this.pressed && this.sp.sprite != this.pressedSprite){
			this.sp.sprite = this.pressedSprite;
		}

		else if(!this.pressed && this.sp.sprite != this.unpressedSprite){
			this.sp.sprite = this.unpressedSprite;
			Application.LoadLevel(1);
		}
	}

	private bool checkIfPressed(float x, float y){
		Vector2 pos = new Vector2(x, y);
		RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);
		
		// if something is hit
		if(hitInfo){
			// if this gameObject was hit
			if(hitInfo.transform.gameObject.name == this.gameObject.name){
				// change value of pressed to true only if it was false
				if(!this.pressed){
					Debug.Log("Target is hit");
					this.pressed = true;
				}	
				return true;				
			}
		}
		return false;
	}
}
