using UnityEngine;
using System.Collections;

public class DropCoin : MonoBehaviour
{
	public GameObject unreachableCoin;
	private Color colorStart = Color.red;
	private Color colorEnd = Color.green;
	public float duration = 1.0F;

	void Update()
	{
		// Enemies that drop coins also glow in different colors.
		float lerp = Mathf.PingPong(Time.time, duration) / duration;
		renderer.material.color = Color.Lerp(colorStart, colorEnd, lerp);
	}

	// Move the unreachable coin to the transforms position.
	public void MoveCoin()
	{
		unreachableCoin.transform.position = transform.position;
	}
}
