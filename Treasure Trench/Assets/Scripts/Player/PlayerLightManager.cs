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
}

