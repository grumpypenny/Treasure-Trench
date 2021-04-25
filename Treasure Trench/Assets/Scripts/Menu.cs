using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Place on Canvas of main menu
/// </summary>
[RequireComponent(typeof(Animator))]
public class Menu : MonoBehaviour
{
	public int sceneToLoad = 1;
	private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
		anim = GetComponent<Animator>();
    }

	public void Back()
	{
		anim.ResetTrigger("Control");
		anim.ResetTrigger("About");
		anim.SetTrigger("Main");
	}

	public void About()
	{
		anim.ResetTrigger("Main");
		anim.ResetTrigger("Control");
		anim.SetTrigger("About");
	}

	public void Controls()
	{
		anim.ResetTrigger("Main");
		anim.ResetTrigger("About");
		anim.SetTrigger("Control");
	}

	public void Quit()
	{
		Application.Quit();
	}

	public void Play()
	{
		SceneManager.LoadScene(sceneToLoad);
	}


}
