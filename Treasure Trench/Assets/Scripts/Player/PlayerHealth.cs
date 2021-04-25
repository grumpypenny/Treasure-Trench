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
	private Rigidbody2D rb;
	private float startRadius;

	// Start is called before the first frame update
	void Start()
    {
		health = maxHealth;
		anim = GetComponent<Animator>();
		light2d = GetComponentInChildren<Light2D>();
		startRadius = light2d.pointLightInnerRadius;
		rb = GetComponent<Rigidbody2D>();
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
		anim.SetTrigger("Hit");
		// make the light smaller
		light2d.pointLightInnerRadius -= startRadius / maxHealth;
	}

	private void Die()
	{
		StartCoroutine(delay());
		anim.SetTrigger("Die");
		rb.gravityScale = 2;
		GetComponent<PlayerMovement>().enabled = false;
	}

	IEnumerator delay()
	{
		yield return new WaitForSeconds(5);
		gameObject.SetActive(false);
	}
}
