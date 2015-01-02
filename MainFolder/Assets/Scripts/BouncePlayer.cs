using UnityEngine;
using System.Collections;

public class BouncePlayer : MonoBehaviour
{
	public float bouncePower = 10f;

	IEnumerator OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			PlayerMovement pm = coll.GetComponent<PlayerMovement>();
			pm.bouncePower = this.bouncePower;
			pm.bounce = true;

			yield return new WaitForSeconds(0.1f);
		}
	}
}
