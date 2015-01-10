using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
	private GameObject player;
	private GameObject enemyRespawner;
	private Vector3 originalPosition;
	public bool isBigEnemy;
	public bool stomp = false;
	public int health = 3;
	private int currentHealth;
	private int damageAmount = 1;
	private Color originalColor;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		enemyRespawner = GameObject.FindGameObjectWithTag("EnemyRespawner");
		originalPosition = transform.position;
		currentHealth = health;
		originalColor = renderer.material.color;
	}

	void Update()
	{
		if(stomp)
		{
			stomp = false;
			currentHealth = currentHealth - 1;
		}

		if(currentHealth <= 0)
		{
			if(isBigEnemy)
			{
				isBigEnemy = false;
				gameObject.GetComponent<DropCoin>().MoveCoin();
				Destroy(gameObject);
			}
			else
			{
				// Calls the EnemyRespawner to do a respawn of the enemy.
				enemyRespawner.GetComponent<EnemyRespawner>().DoRespawn(gameObject);
			}
		}
	}

	public void ReactivateEnemy()
	{
		currentHealth = health;
		transform.position = originalPosition;
		renderer.material.color = originalColor;
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