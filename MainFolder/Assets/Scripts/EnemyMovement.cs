using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
	public float speed = 2.0f;
	public float flipTime = 4.0f;
	private float dirTimer = 0.0f;
	private bool changeDir = false;
	private bool resetTimer = false;

	// Use this for initialization
	void Start () {
	
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

		rigidbody2D.velocity = new Vector3 (speed, 0.0f, 0.0f);
	}
}
