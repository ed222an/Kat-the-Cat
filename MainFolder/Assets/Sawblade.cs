using UnityEngine;
using System.Collections;

public class Sawblade : MonoBehaviour
{
	public int damageAmount = 2;

	IEnumerator OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			PlayerMovement pm = coll.GetComponent<PlayerMovement>();
			PlayerHealth ph = coll.GetComponent<PlayerHealth>();

			pm.bounce = true;

			if(coll.transform.position.y <= transform.position.y)
			{
				// Bounce down
				pm.bouncePower = pm.bouncePower * -1;
			}

			ph.DoDamage(damageAmount);

			yield return new WaitForSeconds(0.1f);
		}
	}
}
