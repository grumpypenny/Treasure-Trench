using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Fish : MonoBehaviour
{
	public int score;
	public int damage;
	public Vector2 moveSpeed;

	protected Rigidbody2D rb;
	protected SpriteRenderer sr;
	protected float directionMultiplier;
	protected float startY;
	protected float endY;
	protected float minX;
	protected float maxX;

	private void OnEnable()
	{
		startY = -Camera.main.orthographicSize - 0.2f;
		endY = Camera.main.orthographicSize + 1f;

		transform.position = new Vector2(Random.Range(minX, maxX), startY);
		directionMultiplier = Random.value > 0.5f ? 1 : -1;
		sr = GetComponent<SpriteRenderer>();
		sr.flipX = directionMultiplier != 1;
	}

	protected void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();

		minX = -Camera.main.orthographicSize + 2f;
		maxX = Camera.main.orthographicSize - 2f;

		startY = -Camera.main.orthographicSize - 0.2f;
		endY = Camera.main.orthographicSize + 1f;

		transform.position = new Vector2(Random.Range(minX, maxX), startY);
		directionMultiplier = Random.value > 0.5f ? 1 : -1;
		sr.flipX = directionMultiplier != 1;
	}

	protected void FixedUpdate()
	{
		// Move the fish up and left/right
		if (rb.position.x < minX && directionMultiplier == -1)
		{
			directionMultiplier = 1;
		}
		else if (rb.position.x > maxX && directionMultiplier == 1)
		{
			directionMultiplier = -1;
		}
		
		sr.flipX = directionMultiplier != 1;

		//rb.MovePosition(rb.position + Vector2.Scale(new Vector2(directionMultiplier, 1f), moveSpeed) * Time.deltaTime);
		rb.velocity = new Vector2(directionMultiplier * moveSpeed.x, moveSpeed.y) * Time.deltaTime;

		// Despawn this fish
		if (rb.position.y > endY)
			gameObject.SetActive(false);
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		IHealth health = collider.gameObject.GetComponent<IHealth>();
		if (health != null)
		{
			health.DealDamage(damage);
		}
	}
}
