using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
	public float speed = 2.0f;
	public float flipTime = 4.0f;
	private float dirTimer = 0.0f;
	private bool changeDir = false;
	private bool resetTimer = false;

	public bool facingRight = true;

	// Use this for initialization
	void Start ()
	{
		int r = Random.Range (1, 3);
		if (r == 1)
		{
			speed = speed * -1;
		}
	}

	void FixedUpdate()
	{
		rigidbody2D.velocity = new Vector3 (speed, rigidbody2D.velocity.y, 0.0f);

		// Flip the player
		if (speed > 0 && !facingRight)
		{
			Flip();
		}
		else if(speed < 0 && facingRight)
		{
			Flip();
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		dirTimer = dirTimer + Time.deltaTime;

		if(dirTimer >= flipTime)
		{
			changeDir = true;
			resetTimer = true;
			speed = speed * -1;
		}

		if(changeDir)
		{
			if(resetTimer)
			{
				dirTimer = 0.0f;
				resetTimer = false;
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
