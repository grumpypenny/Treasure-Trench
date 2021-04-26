using System.Collections;
using UnityEngine;

public class ProjectileFish : Fish
{
	public float fireInterval;
	public string projectile;
	
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
		Vector2 dir = player.position - transform.position;
		dir.Normalize();
		transform.right = dir * directionMultiplier;
	}

	private void Fire()
	{
		GameObject proj = ObjectPool.instance.GetPooledObject(projectile);
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
