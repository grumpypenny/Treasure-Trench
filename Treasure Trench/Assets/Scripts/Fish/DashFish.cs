using UnityEngine;
using System.Collections;

public class DashFish : Fish
{
	public float dashSpeed;
	public float dashChargeTime;
	public float coolDownTime;

	private bool isDashing;
	private Transform player;
	private float coolDown;

	private new void Start()
	{
		base.Start();
		player = GameObject.FindGameObjectWithTag("Player").transform;
		coolDown = coolDownTime;
	}

	private void Update()
	{
		if (isDashing)
			return;

		if (player == null)
			return;

		// Check if it is above the player
		if (transform.position.y > player.position.y)
			return;

		coolDown -= Time.deltaTime;
		if (coolDown <= 0)
		{
			StartCoroutine(Dash());
			coolDown = coolDownTime;
		}
	}

	private new void FixedUpdate()
	{
		if (isDashing)
			return;

		base.FixedUpdate();
	}

	private IEnumerator Dash()
	{
		if (player != null)
		{
			isDashing = true;
			rb.velocity = Vector2.zero;

			Quaternion startRotation = transform.rotation;

			Vector2 dir = (player.position - transform.position) * directionMultiplier;
			dir.Normalize();
			float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			Quaternion endRotation = Quaternion.AngleAxis(angle, Vector3.forward);

			float rotationProgress = 0;
			while (rotationProgress < 1 && rotationProgress >= 0)
			{
				rotationProgress += Time.deltaTime * dashChargeTime;
				transform.rotation = Quaternion.Lerp(startRotation, endRotation, rotationProgress);
				yield return null;
			}

			rb.AddForce(directionMultiplier * transform.right * dashSpeed * Time.deltaTime, ForceMode2D.Impulse);

			yield return new WaitForSeconds(1f);

			transform.rotation = startRotation;

			isDashing = false;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		IHealth health = collision.gameObject.GetComponent<IHealth>();
		if (health != null)
			health.DealDamage(damage);
	}
}
