using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	private Animator animator;

	void Start ()
	{
		// get animator and store reference for further use
		this.animator = GetComponent<Animator>();
	}
	
	void Update () {

		// if there are any touches
		if (Input.touchCount > 0) {
			// go over all touches
			foreach (Touch touch in Input.touches){
				// check if button is pressed, if pressed leave method
				if(checkIfPressed(touch.position.x, touch.position.y)){
					return;
				}
			}
			// if none of the touches hit the button return the state pressed to false
			if(this.animator.GetBool("pressed")){
				this.animator.SetBool("pressed", false);
			}	
		}
		// also check left mouse button for debuging purposes
		else if(Input.GetMouseButton(0)) {
			checkIfPressed(Input.mousePosition.x, Input.mousePosition.y);
		}
		else {
			// if Button was pressed!
			if(this.animator.GetBool("pressed")){
				this.animator.SetBool("pressed", false);
				Application.LoadLevel(1);
			}
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
				if(!this.animator.GetBool("pressed")){
					this.animator.SetBool("pressed", true);
				}	
				return true;				
			}
		}
		return false;
	}
}
