using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	public int value = 20;

	public LayerMask playerMask;

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (playerMask == (playerMask | (1 << collider.gameObject.layer)))
		{
			FindObjectOfType<ScoreManager>().UpdateScore(value);
		}
		gameObject.SetActive(false);
	}
}
