using UnityEngine;
using System.Collections;

public class KillZone : MonoBehaviour
{
	private GameObject player;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			player.GetComponent<PlayerHealth>().RespawnPlayer();
		}

		if(coll.gameObject.tag == "Enemy")
		{
			Destroy(coll.gameObject);
		}
	}
}
