using UnityEngine;

public class ElectricFish : Fish
{

	public float lightOutageDuration;

	private void OnTriggerEnter2D(Collider2D collider)
	{
		IHealth health = collider.gameObject.GetComponent<IHealth>();
		if (health != null)
		{
			health.DealDamage(damage);
			collider.gameObject.GetComponent<PlayerLightManager>().TakeOutLights(lightOutageDuration);
		}
	}
}
