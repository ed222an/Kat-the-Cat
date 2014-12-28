using UnityEngine;
using System.Collections;

public class StompDeath : MonoBehaviour
{
	private GameObject player;
	private bool stomp = false;
	private int damageAmount = 1;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
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
		else
		{
			Destroy (gameObject.transform);
		}
	}
}