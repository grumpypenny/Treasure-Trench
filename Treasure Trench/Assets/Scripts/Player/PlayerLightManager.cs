using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerLightManager : MonoBehaviour
{
	public Light2D submarineLight;
	public bool isLightOut = false;

	public void TakeOutLights(float duration)
	{
		StartCoroutine(DisableLights(duration));
	}

	public void TakeOutLightsFast(float duration)
	{
		StartCoroutine(DisableLightsFast(duration));
	}

	IEnumerator DisableLights(float duration)
	{
		isLightOut = true;
		float currRadius = submarineLight.pointLightInnerRadius;
		
		for (int i = 0; i < 5; i++)
		{
			submarineLight.pointLightInnerRadius = 6f - i;
			yield return new WaitForSeconds(0.05f);
			submarineLight.pointLightInnerRadius = 10f;
			yield return new WaitForSeconds(0.05f);
		}

		submarineLight.pointLightInnerRadius = 0.4f;

		yield return new WaitForSeconds(duration);
		
		isLightOut = false;

		submarineLight.pointLightInnerRadius = currRadius;
	}

	IEnumerator DisableLightsFast(float duration)
	{
		isLightOut = true;
		float currRadius = submarineLight.pointLightInnerRadius;
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

