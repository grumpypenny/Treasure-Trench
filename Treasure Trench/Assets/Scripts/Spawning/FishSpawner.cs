using UnityEngine;

public class FishSpawner : MonoBehaviour
{
	public float spawnRate;

	public float class1Weight;
	public float class2Weight;
	public float class3Weight;

	private float timeToSpawn;

	private void Start()
	{
		timeToSpawn = 0f;
	}

	private void Update()
	{
		timeToSpawn += Time.deltaTime;	

		if (timeToSpawn >= spawnRate)
		{
			SpawnFish();
		}
	}

	private void SpawnFish()
	{
	/*	GameObject fish = ObjectPool.instance.GetPooledObject("BubbleProjectile");
		if (proj == null)
		{
			return;
		}

		proj.SetActive(true);*/
	}
}
