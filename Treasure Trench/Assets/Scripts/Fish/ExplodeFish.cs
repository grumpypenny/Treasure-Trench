using System.Collections;
using UnityEngine;

public class ExplodeFish : Fish
{
	public float explosionRadius;
	public float explosionTriggerRange;
	public float explosionChargeTime;

	public AudioClip explosionSound;

	private bool isExploding;
	private GameObject playerObj;
	private Transform player;
	private AudioSource explosionAudioSource;
	private Animator animator;
	private float squaredTriggerDistance;

	private void OnEnable()
	{
		isExploding = false;

		startY = -Camera.main.orthographicSize - 0.2f;
		endY = Camera.main.orthographicSize + 1f;

		transform.position = new Vector2(Random.Range(minX, maxX), startY);
		directionMultiplier = Random.value > 0.5f ? 1 : -1;
		sr = GetComponent<SpriteRenderer>();
		sr.flipX = directionMultiplier != 1;
	}

	private new void Start()
	{
		base.Start();

		playerObj = GameObject.FindGameObjectWithTag("Player");
		if (playerObj != null)
			player = playerObj.transform;
		explosionAudioSource = GetComponent<AudioSource>();
		animator = GetComponent<Animator>();

		isExploding = false;
		squaredTriggerDistance = Mathf.Pow(explosionTriggerRange, 2);
	}

	private void Update()
	{
		if (isExploding)
			return;
		if (player == null)
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
		
		animator.Play("StartExplode");

		yield return new WaitForSeconds(explosionChargeTime);

		animator.Play("Explode");

		yield return new WaitForSeconds(1.5f);

		gameObject.SetActive(false);
	}

	public void Explode()
	{
		explosionAudioSource.PlayOneShot(explosionSound);
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

		foreach (Collider2D col in colliders)
		{
			IHealth health = col.gameObject.GetComponent<IHealth>();
			if (health != null)
				health.DealDamage(damage);
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, explosionRadius);

		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, explosionTriggerRange);
	}
}
