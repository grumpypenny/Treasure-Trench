using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Torpedo : Projectile
{
	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Fish")
		{
			collider.gameObject.SetActive(false);
		}
		gameObject.SetActive(false);
	}
}
