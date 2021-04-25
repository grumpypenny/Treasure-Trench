using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	public Transform upFire;
	public Transform downFire;

	public float timeBetweenShots;

	private float lastFireTime;
    // Start is called before the first frame update
    void Start()
    {
		lastFireTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
		float input = Input.GetAxisRaw("Vertical");
		if (Input.GetButtonDown("Vertical") && Time.time > lastFireTime + timeBetweenShots)
		{
			Fire(input > 0);
		}
	}

	private void Fire(bool fireup)
	{

		GameObject torpedo = ObjectPool.instance.GetPooledObject("Torpedo");
		if (torpedo == null)
		{
			return;
		}
		if (fireup)
		{
			torpedo.transform.position = upFire.position;
			torpedo.transform.eulerAngles = upFire.eulerAngles;
		} else
		{
			torpedo.transform.position = downFire.position;
			torpedo.transform.eulerAngles = downFire.eulerAngles;
		}
		lastFireTime = Time.time;
		torpedo.SetActive(true);
	}
}
