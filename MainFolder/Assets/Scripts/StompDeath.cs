using UnityEngine;
using System.Collections;

public class StompDeath : MonoBehaviour
{
	private GameObject player;
	public bool stomp = false;
	public int health = 3;
	private int damageAmount = 1;

	private bool takingDamage = false;
	public int blinkAmount = 10;
	private Color originalColor;
	private Color damageColor = Color.white;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		originalColor = renderer.material.color;
	}

	void Update()
	{
		if(stomp)
		{
			stomp = false;
			health = health - 1;
		}

		if(health <= 0)
		{
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(!stomp)
		{
			if(other.gameObject.tag == "Player")
			{
				PlayerHealth ph = player.GetComponent<PlayerHealth>();
				ph.DoDamage(damageAmount);
			}
		}
	}
}