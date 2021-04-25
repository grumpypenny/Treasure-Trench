using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerLightManager : MonoBehaviour
{
	public Light2D submarineLight;
	public Animator lightAnimator;

	public void TakeOutLights(float duration)
	{
		StartCoroutine(DisableLights(duration));
	}

	IEnumerator DisableLights(float duration)
	{
		lightAnimator.SetBool("IsLightOut", true);
		yield return new WaitForSeconds(duration);
		lightAnimator.SetBool("IsLightOut", false);
	}
}

