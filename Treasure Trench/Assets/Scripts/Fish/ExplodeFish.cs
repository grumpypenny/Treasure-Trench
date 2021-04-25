using System.Collections;
using UnityEngine;

public class ExplodeFish : Fish
{
	public float explosionRadius;
	public float explosionTriggerRange;
	public float explosionChargeTime;

	public AudioClip explosionSound;

	private bool isExploding;
	private Transform player;
	private AudioSource explosionAudioSource;
	private Animator animator;
	private float squaredTriggerDistance;

	private new void Start()
	{
		base.Start();
		
		player = GameObject.FindGameObjectWithTag("Player").transform;
		explosionAudioSource = GetComponent<AudioSource>();
		animator = GetComponent<Animator>();

		isExploding = false;
		squaredTriggerDistance = Mathf.Pow(explosionTriggerRange, 2);
	}

	private void Update()
	{
		if (isExploding)
			return;

		// Check if is within player range
		Vector2 distVector = transform.position - player.position;
		if (Vector2.SqrMagnitude(distVector) <= squaredTriggerDistance)
			StartCoroutine(StartExplode());

	}

	private new void FixedUpdate()
	{
		if (isExploding)
			return;

		base.FixedUpdate();
	}

	private IEnumerator StartExplode()
	{
		isExploding = true;
		rb.velocity = Vector2.zero;
		
		animator.Play("Explode");

		yield return new WaitForSeconds(explosionChargeTime);

		Explode();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Explode();
	}

	private void Explode()
	{
		explosionAudioSource.PlayOneShot(explosionSound);
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

		foreach (Collider2D col in colliders)
		{
			IHealth health = col.gameObject.GetComponent<IHealth>();
			if (health != null)
				health.DealDamage(damage);
		}

		gameObject.SetActive(false);
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, explosionRadius);

		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, explosionTriggerRange);
	}
}
