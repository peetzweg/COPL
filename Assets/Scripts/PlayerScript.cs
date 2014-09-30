using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
	private Animator animator;

	// Use this for initialization
	void Start()
	{
		// get animator and store reference for further use
		this.animator = GetComponent<Animator>();

		// set transition variable for jumping to false, to start in driving mode
		this.animator.SetBool("Jumping", false);

		// inital push
		this.rigidbody2D.AddForce(new Vector2(600, 0));
	}

	// Update is called once per frame
	void Update()
	{
		// continues acceleration
		if (this.rigidbody2D.velocity.x < 15) {
			this.rigidbody2D.AddForce(new Vector2(0.5f, 0));
		}

		// lose if player left through the bottom of the screen
		if (this.transform.position.y < -7) {
			endRound();
		}
	}

	// Only allow jumping if roof is trigger
	void OnTriggerStay2D(Collider2D other)
	{
		if (!legitRotation()) {
			endRound();
		}
		checkForJump();

	}

	// also allow jumping when leaving the roof with a part of the board
	void OnTriggerExit2D(Collider2D other)
	{
		checkForJump();
	}

	private void endRound()
	{
		Distance.saveDistance();
		Application.LoadLevel(2);
	}

	private bool legitRotation()
	{
		int zRotation = Mathf.CeilToInt(this.transform.rotation.eulerAngles.z);
		if (zRotation >= 90 && zRotation <= 270) {
			return false;
		}
		return true;
	}
	
	// handles jumping
	private void checkForJump()
	{

		// debug keyboard input
		if (Input.GetKeyDown("space") && !(this.animator.GetBool("Jumping"))) {
			this.animator.SetBool("Jumping", true);
		} else if (Input.GetKeyUp("space") && this.animator.GetBool("Jumping")) {
			this.animator.SetBool("Jumping", false);
			this.rigidbody2D.AddForce(new Vector2(0, 150));
		
		}

		// only if there are any touches
		if (Input.touchCount > 0) {
			// if touch began change 'Jumping' to true, to begin jumping animation if in correct area
			if (!(this.animator.GetBool("Jumping"))) {
				bool inCorrectArea = false;
				foreach (Touch touch in Input.touches) {
					if (touch.position.y < Screen.height/2) {
						inCorrectArea = true;
					}
				}
				if (inCorrectArea) {
					this.animator.SetBool("Jumping", true);
				}

			}
		} else if (this.animator.GetBool("Jumping")) {
			this.animator.SetBool("Jumping", false);
			this.rigidbody2D.AddForce(new Vector2(0, 150));
		}
	}
}
