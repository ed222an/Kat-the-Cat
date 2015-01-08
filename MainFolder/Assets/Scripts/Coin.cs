using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{
	IEnumerator OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			gameObject.collider2D.enabled = false;
			GameObject gc = GameObject.FindGameObjectWithTag("GameController");
			gc.GetComponent<GameControllerScript>().coinScore++;
			audio.Play();
			gameObject.renderer.enabled = false;
			yield return new WaitForSeconds(audio.clip.length);
			Destroy(gameObject);
		}
	}
}
