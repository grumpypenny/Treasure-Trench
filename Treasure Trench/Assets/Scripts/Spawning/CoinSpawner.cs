using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
	public List<Transform> spawnPositions;
	public float timeBetweenSpawns = 2f;
	private float lastSpawnTime = 0;

    // Start is called before the first frame update
    void Start()
    {
		if (spawnPositions.Count == 0)
		{
			spawnPositions.Add(transform);
		}
    }

    // Update is called once per frame
    void Update()
    {
		if (Time.time > lastSpawnTime + timeBetweenSpawns)
		{
			Spawn();
			lastSpawnTime = Time.time;
		}
    }

	private void Spawn()
	{
		int index = Random.Range(0, spawnPositions.Count);
		GameObject coin = ObjectPool.instance.GetPooledObject("Coin");
		if (coin != null)
		{
			coin.transform.position = spawnPositions[index].position;
			coin.SetActive(true);
		}
	}
}
