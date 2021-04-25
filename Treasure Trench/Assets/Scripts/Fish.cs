using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Fish : MonoBehaviour
{
	public int damage;
	public Vector2 moveSpeed;

	protected Rigidbody2D rb;
	protected SpriteRenderer sr;
	protected float directionMultiplier;
	protected float startY;
	protected float endY;
	protected float minX;
	protected float maxX;

	protected void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();

		minX = -2 * Camera.main.orthographicSize + 2f;
		maxX = 2 * Camera.main.orthographicSize - 2f;

		startY = -Camera.main.orthographicSize - 1f;
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
}
