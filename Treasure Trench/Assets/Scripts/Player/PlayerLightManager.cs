using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerLightManager : MonoBehaviour
{
	public Light2D submarineLight;
	public void TakeOutLights(float duration)
	{
		StartCoroutine(DisableLights(duration));
	}
	IEnumerator DisableLights(float duration)
	{
		for (int i = 0; i < 5; i++)
		{
			submarineLight.enabled = false;
			yield return new WaitForSeconds(0.5f);
			submarineLight.enabled = true;
		}

		submarineLight.enabled = false;
		yield return new WaitForSeconds(duration);
		submarineLight.enabled = true;
	}
}

