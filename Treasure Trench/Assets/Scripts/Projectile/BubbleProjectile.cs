using UnityEngine;

public class BubbleProjectile : Projectile
{
	private void OnTriggerEnter2D(Collider2D collider)
	{
		IHealth health = collider.gameObject.GetComponent<IHealth>();
		if (health != null)
		{
			health.DealDamage(damage);
		}
		gameObject.SetActive(false);
	}
}
