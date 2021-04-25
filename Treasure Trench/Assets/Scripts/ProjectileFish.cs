using System.Collections;
using UnityEngine;

public class ProjectileFish : Fish
{
	public float fireInterval;
	
	private Transform player;
	private float timeToFire;

	private new void Start()
	{
		base.Start();
		player = GameObject.FindGameObjectWithTag("Player").transform;

		timeToFire = 0f;
	}

    private void Update()
    {
		if (timeToFire >= fireInterval)
		{
			Fire();
			timeToFire = 0f;
		}


		timeToFire += Time.deltaTime;
    }

	private void LateUpdate()
	{
		// Overwrite flip x so that it always looks at player

		Vector2 dir = player.position - transform.position;
		dir.Normalize();
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		sr.flipX = Mathf.Abs(angle) >= 90;
	}

	private void Fire()
	{
		GameObject proj = ObjectPool.instance.GetPooledObject("BubbleProjectile");
		if (proj == null)
		{
			return;
		}

		Vector2 dir = player.position - transform.position;
		dir.Normalize();
		proj.GetComponent<Projectile>().SetDirection(dir);
		proj.transform.position = transform.position;
		proj.SetActive(true);
	}
}
