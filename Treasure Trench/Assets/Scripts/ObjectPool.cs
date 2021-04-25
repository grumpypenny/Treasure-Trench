using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Example script from Unity Learn
/// </summary>
public class ObjectPool : MonoBehaviour
{

	public static ObjectPool instance;
	[Header("Pooling variables")]
	public List<GameObject> objectsToPool;
	public List<List<GameObject>> pools;
	public int amountToPool = 20;

	[Space]

	[Header("Where to spawn items")]
	public Transform spawnPosition;

	private void Awake()
	{
		if (spawnPosition == null)
		{
			spawnPosition = this.gameObject.transform;
		}
		instance = this;
	}


	private void Start()
	{
		pools = new List<List<GameObject>>();
		GameObject t;
		for (int i = 0; i < objectsToPool.Count; i++)
		{
			pools.Add(new List<GameObject>());
			for (int j = 0; j < amountToPool; j++)
			{
				t = Instantiate(objectsToPool[i], spawnPosition.position, Quaternion.identity);
				t.SetActive(false);
				pools[i].Add(t);
			}
		}
	}

	public GameObject GetPooledObject(String tag)
	{
		int index = -1;
		for (int i = 0; i < objectsToPool.Count; i++)
		{
			if (objectsToPool[i].tag == tag)
			{
				index = i;
				break;
			}
		}
		if (index == -1)
		{
			// invalid name
			Debug.Log("Invalid name");
			return null;
		}

		for (int i = 0; i < amountToPool; i++)
		{
			if (!pools[index][i].activeInHierarchy)
			{
				return pools[index][i];
			}
		}
		// pool is full
		Debug.Log("Pool is empty");
		return null;
	}

	//public static ObjectPool SharedInstance;
	//public List<GameObject> pooledObjects;
	//public GameObject objectToPool;
	//public int amountToPool;

	//private void Awake()
	//{
	//	SharedInstance = this;
	//}

	//private void Start()
	//{
	//	pooledObjects = new List<GameObject>();
	//	GameObject temp;
	//	for (int i = 0; i < amountToPool; i++)
	//	{
	//		temp = Instantiate(objectToPool);
	//		temp.SetActive(false);
	//		pooledObjects.Add(temp);
	//	}
	//}

	//public GameObject GetPooledObject()
	//{
	//	for (int i = 0; i < amountToPool; i++)
	//	{
	//		if (!pooledObjects[i].activeInHierarchy)
	//		{
	//			return pooledObjects[i];
	//		}
	//	}
	//	return null;
	//}
}