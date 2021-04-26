using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ColourChange : MonoBehaviour
{
	public float speed = 6f;
	public float duration = 20f;

	public Color start;
	public Color end;

	public Tilemap t;

	private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
		t.color = start;
	}

    // Update is called once per frame
    void Update()
    {
		time = Mathf.Clamp(time + Time.deltaTime, 0f, duration);

		t.color = Color.Lerp(start, end, time * speed);    
    }
}
