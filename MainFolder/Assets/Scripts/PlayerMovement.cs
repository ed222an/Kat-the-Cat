using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public float maxSpeed = 10f;
	public bool facingRight = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		float move = Input.GetAxis ("Horizontal");
		rigidbody.velocity = new Vector3 (move * maxSpeed, rigidbody.velocity.y, 0.0f);

		if (move > 0 && !facingRight)
		{
			Flip();
		}
		else if(move < 0 && facingRight)
		{
			Flip();
		}
	}

	// Flips the world around the player, allowing us to only use 1 set of animations.
	private void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
