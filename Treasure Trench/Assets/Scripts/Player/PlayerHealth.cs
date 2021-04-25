using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerHealth : MonoBehaviour, IHealth
{
	public int maxHealth = 3;
	[SerializeField] private int health;
	int IHealth.health => health;

	private Animator anim;
	private Light2D light2d;
	private float startRadius;

	// Start is called before the first frame update
	void Start()
    {
		health = maxHealth;
		anim = GetComponent<Animator>();
		light2d = GetComponentInChildren<Light2D>();
		startRadius = light2d.pointLightInnerRadius;
    }

	void IHealth.DealDamage(int damage)
	{
		health--;
		if (health <= 0)
		{
			Die();
			return;
		}
		GetHit();
	}

	private void GetHit()
	{
		// make the light smaller
		light2d.pointLightInnerRadius -= startRadius / maxHealth;
	}

	private void Die()
	{
		gameObject.SetActive(false);
	}
}
