using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed = 6;
	private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
    }

	/// <summary>
	/// Update called 50 times a second
	/// for physics calculations
	/// </summary>	
	private void FixedUpdate()
	{
		float input = Input.GetAxisRaw("Horizontal");
		Vector2 value = new Vector2(input, 0);
		value = value.normalized;

		rb.MovePosition((Vector2)transform.position + value * moveSpeed * Time.deltaTime);
	}
}
