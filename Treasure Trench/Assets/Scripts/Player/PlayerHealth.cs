using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IHealth
{

	public Image healthBar;

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

		Debug.Log(startRadius);
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

	void IHealth.Heal()
	{
		health = maxHealth;
		light2d.pointLightInnerRadius = startRadius;
		healthBar.fillAmount = 1f;
	}

	private void GetHit()
	{
		if (anim.GetCurrentAnimatorStateInfo(0).IsName("hit"))
		{
			return;
		}

		anim.SetTrigger("Hit");

		if (GetComponent<PlayerLightManager>().isLightOut)
			return;

		// make the light smaller
		light2d.pointLightInnerRadius -= startRadius / maxHealth;
		healthBar.fillAmount = (float)health / (float)maxHealth;

		Camera.main.GetComponent<CameraShake>().Shake(0.08f, 0.5f);
	}
	private void Die()
	{
		light2d.pointLightInnerRadius -= startRadius / maxHealth;
		healthBar.fillAmount = (float)health / (float)maxHealth;

		StartCoroutine(delay());
		anim.SetTrigger("Die");
		rb.gravityScale = 2;
		GetComponent<PlayerMovement>().enabled = false;
		FindObjectOfType<Canvas>().GetComponent<Animator>().SetTrigger("Die");
	}

	IEnumerator delay()
	{
		yield return new WaitForSeconds(5);
		gameObject.SetActive(false);
	}
}
