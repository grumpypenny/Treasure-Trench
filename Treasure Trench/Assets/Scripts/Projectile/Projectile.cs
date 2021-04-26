using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
	public float speed;
	public int damage;
	protected Rigidbody2D rb;
	protected Renderer rend;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		rend = GetComponent<Renderer>();
	}

	public void SetDirection(Vector2 newDirection)
	{
		transform.right = newDirection.normalized;
	}

	void FixedUpdate()
	{
		rb.MovePosition(transform.position + transform.right * speed * Time.deltaTime);
		if (!rend.isVisible)
		{
			if (gameObject.tag.Equals("Torpedo"))
			{
				Transform bubbleEffect = transform.GetChild(0);
				bubbleEffect.parent = null;
				bubbleEffect.localScale = new Vector3(0.5f, 0.5f, 1f);
				Destroy(bubbleEffect.gameObject, 5f);
			}


			gameObject.SetActive(false);
		}
	}
}
