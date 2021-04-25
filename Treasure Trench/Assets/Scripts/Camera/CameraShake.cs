using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
	private Vector3 originalPos;

	private void Start()
	{
		originalPos = transform.position;
	}

	public void Shake(float intensity, float duration)
	{
		StopAllCoroutines();
		transform.position = originalPos;

		StartCoroutine(StartShake(intensity, duration));
	}

	IEnumerator StartShake(float intensity, float duration)
	{
		float elapsed = 0f;

		while (elapsed < duration)
		{
			float x = Random.Range(-1f, 1f) * intensity;
			float y = Random.Range(-1f, 1f) * intensity;

			transform.localPosition = new Vector3(x, y, originalPos.z);

			elapsed += Time.deltaTime;

			yield return null;
		}

		transform.position = originalPos;
	} 
}
