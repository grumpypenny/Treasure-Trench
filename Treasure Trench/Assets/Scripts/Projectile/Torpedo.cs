using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Torpedo : Projectile
{
	public LayerMask fishLayer;

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (fishLayer == (fishLayer | (1 << collider.gameObject.layer)))
		{
			collider.gameObject.SetActive(false);
		}
		gameObject.SetActive(false);
	}
}
