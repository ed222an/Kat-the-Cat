using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	// Speed & animaton related
	public float maxSpeed = 10f;
	public bool facingRight = true;
	private Animator anim;

	// Ground stuff for jumping
	public bool grounded = false;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;
	public AudioClip jumpClip;
	private float groundRadius = 0.2f;
	private bool doubleJump = false;

	// Bouncing
	public bool bounce = false;
	public float bouncePower;
	public AudioClip bounceClip;
	private float originalBouncePower = 10.0f;

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
		bouncePower = originalBouncePower;
	}

	void FixedUpdate ()
	{
		// Check if the player is grounded
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);

		if(grounded)
		{
			doubleJump = false;
		}

		/*
		// Disables movement while jumping
		if(!grounded)
		{
			return;
		}
		*/

		// Movement & speed
		float move = Input.GetAxis ("Horizontal");

		anim.SetFloat ("Speed", Mathf.Abs (move));

		rigidbody2D.velocity = new Vector3 (move * maxSpeed, rigidbody2D.velocity.y, 0.0f);

		// Flip the player
		if (move > 0 && !facingRight)
		{
			Flip();
		}
		else if(move < 0 && facingRight)
		{
			Flip();
		}

		// Bounce
		if(bounce)
		{
			rigidbody2D.velocity = new Vector3 (move * maxSpeed, bouncePower, 0.0f);
			bounce = false;
			bouncePower = originalBouncePower;
			audio.PlayOneShot(bounceClip);
		}
	}

	void Update()
	{

		if((grounded || !doubleJump) && Input.GetKeyDown(KeyCode.Space))
		{
			anim.SetBool ("Ground", false);
			rigidbody2D.AddForce(new Vector2(0,jumpForce));
			audio.PlayOneShot(jumpClip);

			if(!doubleJump && !grounded)
			{
				doubleJump = true;
			}
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
