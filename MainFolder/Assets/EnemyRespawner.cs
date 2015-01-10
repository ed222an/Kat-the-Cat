using UnityEngine;
using System.Collections;

public class EnemyRespawner : MonoBehaviour
{
	public float inactiveTime = 10.0f;

	public void DoRespawn(GameObject enemy)
	{
		enemy.SetActive (false);
		StartCoroutine(ReactivateObject(enemy));
	}

	private IEnumerator ReactivateObject(GameObject enemy)
	{
		yield return new WaitForSeconds (inactiveTime);

		enemy.GetComponent<EnemyHealth> ().ReactivateEnemy ();
		enemy.SetActive(true);
	}
}
