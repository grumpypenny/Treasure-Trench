using UnityEngine;

public class FishSpawner : MonoBehaviour
{
	public float spawnRate;
	public float stageDuration;

	[Header("Class 1 Fish")]
	public float class1Weight;
	public float class1EvolveRate;
	public string[] class1Fish;

	[Header("Class 2 Fish")]
	public float class2Weight;
	public float class2EvolveRate;
	public string[] class2Fish;

	[Header("Class 3 Fish")]
	public float class3Weight;
	public float class3EvolveRate;
	public string[] class3Fish;

	private float timeToSpawn;
	private float stageTime;
	private int stage;

	private void Start()
	{
		timeToSpawn = 0f;
		stageTime = 0f;
		stage = 0;
	}

	private void Update()
	{
		timeToSpawn += Time.deltaTime;	
		stageTime = Mathf.Clamp(stageTime + Time.deltaTime, 0f, 10f * stageDuration);

		if (stage == 0)
		{
			class1Weight = Mathf.Lerp(1f, 0f, Mathf.Clamp01(class1EvolveRate * stageTime / stageDuration));
			class2Weight = Mathf.Lerp(0f, 1f, Mathf.Clamp01(class2EvolveRate * stageTime / stageDuration));
		}
		else
		{
			class2Weight = Mathf.Lerp(1f, 0.05f, Mathf.Clamp01(class2EvolveRate * stageTime / stageDuration));
			class3Weight = Mathf.Lerp(0f, 2f, Mathf.Clamp01(class3EvolveRate * stageTime / stageDuration));
		}

		if (class2Weight == 1f && stage == 0)
		{
			stage = 1;
			stageTime = 0f;
			class1Weight = 0f;
		}

		if (timeToSpawn >= spawnRate)
		{
			SpawnFish();
			timeToSpawn = 0f;
		}
	}

	private void SpawnFish()
	{
		float cummulativeWeight = class1Weight + class2Weight + class3Weight;
		float r = Random.value * cummulativeWeight;

		float[] classProbabilities = { class1Weight, class2Weight, class3Weight };
		int selectedClass = 1;

		for (int i = 0; i < 3; i++)
		{
			if (classProbabilities[i] >= r)
			{
				selectedClass = i;
				break;
			}
		}

		string tag = GetRandomFishFromClass(selectedClass + 1);
		if (tag == null)
		{
			Debug.Log("TAG IS NULL");
			return;
		}

		GameObject fish = ObjectPool.instance.GetPooledObject(tag);
		if (fish == null)
		{
			return;
		}
		fish.SetActive(true);
	}


	private string GetRandomFishFromClass(int classID) 
	{
		string[] selectedClass;
		switch(classID)
		{
			case 1:
				selectedClass = class1Fish;
				break;
			case 2:
				selectedClass = class2Fish;
				break;
			case 3:
				selectedClass = class3Fish;
				break;
			default:
				return null;
		}

		if (selectedClass.Length == 0)
			return null;

		return selectedClass[Random.Range(0, selectedClass.Length )];
	}
}
