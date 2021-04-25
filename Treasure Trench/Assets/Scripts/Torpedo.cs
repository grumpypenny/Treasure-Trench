using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Torpedo : MonoBehaviour
{
	public float moveSpeed;

	private Rigidbody2D rb;
	private Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		rend = GetComponent<Renderer>();
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		rb.MovePosition(transform.position + transform.up * moveSpeed * Time.deltaTime);
		if (!rend.isVisible)
		{
			gameObject.SetActive(false);
		}
    }
}
