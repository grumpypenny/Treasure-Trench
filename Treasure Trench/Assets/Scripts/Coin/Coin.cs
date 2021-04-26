using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	public int value = 20;
	public float speed = 3f;
	public LayerMask playerMask;

	private Renderer rend;

	private void Start()
	{
		rend = GetComponent<Renderer>();
	}

	private void Update()
	{
		transform.Translate(Vector2.up * speed * Time.deltaTime);

		if (!rend.isVisible)
		{
			gameObject.SetActive(false);
		}
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (playerMask == (playerMask | (1 << collider.gameObject.layer)))
		{
			FindObjectOfType<ScoreManager>().UpdateScore(value);
			gameObject.SetActive(false);
		}
	}
}
