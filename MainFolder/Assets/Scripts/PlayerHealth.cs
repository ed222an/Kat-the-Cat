using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public int startHealth = 3;
	public int health;
	public float invTime = 1.5f;
	public int blinkAmount = 10;
	public AudioClip meow;

	private bool canTakeDamage = true;
	private GameObject spawnPoint;
	private Color originalColor;
	private Color damageColor = Color.red;

	// Use this for initialization
	void Start ()
	{
		spawnPoint = GameObject.FindGameObjectWithTag ("Respawn");
		health = startHealth;
		originalColor = renderer.material.color;
	}

	
	// Update is called once per frame
	void Update ()
	{
		if (health <= 0)
		{
			RespawnPlayer();
		}
	}

	public void RespawnPlayer()
	{
		health = startHealth;
		gameObject.transform.position = spawnPoint.transform.position;
	}

	public void DoDamage(int amount)
	{
		if(canTakeDamage)
		{	
			health = health - amount;
			audio.PlayOneShot(meow);
			StartCoroutine(Invulnerable());
			StartCoroutine(Blink(damageColor));
		}
	}

	private IEnumerator Invulnerable()
	{
		canTakeDamage = false;
		yield return new WaitForSeconds(invTime);
		canTakeDamage = true;
	}

	private IEnumerator Blink(Color chosenColor)
	{
		for(int i = 0; i < blinkAmount; i++)
		{
			renderer.material.color = chosenColor;
			yield return new WaitForSeconds(0.01f);
			renderer.material.color = originalColor;
		}
	}
}
