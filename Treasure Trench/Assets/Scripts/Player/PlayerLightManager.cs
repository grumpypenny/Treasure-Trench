using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerLightManager : MonoBehaviour
{
	public Light2D submarineLight;
	public bool isLightOut = false;

	private float currRadius;

	public void SetRadius(float newRadius)
	{
		currRadius = newRadius;
	}

	public void TakeOutLights(float duration)
	{
		if (isLightOut)
			return;

		StartCoroutine(DisableLights(duration));
	}

	public void TakeOutLightsFast(float duration)
	{
		if (isLightOut)
			return;

		StartCoroutine(DisableLightsFast(duration));
	}

	IEnumerator DisableLights(float duration)
	{
		isLightOut = true;
		currRadius = submarineLight.pointLightInnerRadius;
		
		for (int i = 0; i < 2; i++)
		{
			submarineLight.pointLightInnerRadius = 5f;
			yield return new WaitForSeconds(0.1f);
			submarineLight.pointLightInnerRadius = 3f;
			yield return new WaitForSeconds(0.1f);
		}

		submarineLight.pointLightInnerRadius = 0.4f;

		yield return new WaitForSeconds(duration);
		
		submarineLight.pointLightInnerRadius = currRadius;
		isLightOut = false;
	}

	IEnumerator DisableLightsFast(float duration)
	{
		isLightOut = true;
		currRadius = submarineLight.pointLightInnerRadius;
		float time = 0f;

		while(time < 1f)
		{
			submarineLight.pointLightInnerRadius = Mathf.Lerp(currRadius, 0.2f, time);
			time += Time.deltaTime;
			yield return null;
		}

		yield return new WaitForSeconds(duration);

		isLightOut = false;
		submarineLight.pointLightInnerRadius = currRadius;
	}
}

