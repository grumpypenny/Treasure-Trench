using UnityEngine;

public class InkProjectile : Projectile
{
	public float lightOutageDuration;

	private void OnTriggerEnter2D(Collider2D collider)
	{
		IHealth health = collider.gameObject.GetComponent<IHealth>();
		if (health != null)
		{
			health.DealDamage(damage);
			collider.gameObject.GetComponent<PlayerLightManager>().TakeOutLightsFast(lightOutageDuration);
		}
		gameObject.SetActive(false);
	}
}
