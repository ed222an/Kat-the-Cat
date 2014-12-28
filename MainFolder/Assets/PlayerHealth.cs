using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
	public int startHealth = 3;
	public int health;

	private bool canTakeDamage = true;
	public float invTime = 1.5f;

	private GameObject spawnPoint;

	// Use this for initialization
	void Start ()
	{
		spawnPoint = GameObject.FindGameObjectWithTag ("Respawn");
		health = startHealth;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (health <= 0)
		{
			RespawnPlayer();
		}
	}

	private void RespawnPlayer()
	{
		health = startHealth;
		transform.position = spawnPoint.transform.position;
	}

	public void DoDamage(int amount)
	{
		if(canTakeDamage)
		{	
			health = health - amount;
			StartCoroutine(Invulnerable());
		}
	}

	private IEnumerator Invulnerable()
	{
		canTakeDamage = false;
		yield return new WaitForSeconds(invTime);
		canTakeDamage = true;
	}
}
