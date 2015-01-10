using UnityEngine;
using System.Collections;

public class Stomp : MonoBehaviour
{
	private Renderer parentRenderer;
	private StompDeath parentStompDeath;
	private Color originalColor;
	public Color damageColor = Color.green;

	// Use this for initialization
	void Start ()
	{
		parentRenderer = GetComponentInParent<SpriteRenderer> ();
		parentStompDeath = GetComponentInParent<StompDeath> ();
		originalColor = parentRenderer.material.color;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.gameObject.tag == "Player")
		{
			parentStompDeath.stomp = true;
			PlayerMovement pm = coll.GetComponent<PlayerMovement>();
			pm.bounce = true;

			parentRenderer.material.color = damageColor;
			yield return new WaitForSeconds(0.1f);
			parentRenderer.material.color = originalColor;
		}
	}
}
