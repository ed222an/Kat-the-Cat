using UnityEngine;
using System.Collections;

public class Stomp : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			transform.root.gameObject.GetComponent<StompDeath>().stomp = true;
			PlayerMovement pm = coll.GetComponent<PlayerMovement>();
			pm.bounce = true;
		}

		if(coll.gameObject.tag == "Ground")
		{
			transform.root.gameObject.GetComponent<StompDeath>().stomp = true;
		}
	}
}
