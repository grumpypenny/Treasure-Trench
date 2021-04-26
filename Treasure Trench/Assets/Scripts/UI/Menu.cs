using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Place on Canvas of main menu
/// </summary>
[RequireComponent(typeof(Animator))]
public class Menu : MonoBehaviour
{

	public Animator submarineAnimator;

	public int sceneToLoad = 1;
	private Animator anim;


    // Start is called before the first frame update
    void Start()
    {
		Time.timeScale = 1f;
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
		anim.SetTrigger("StartGame");
		StartCoroutine(StartGame());
	}

	IEnumerator StartGame()
	{
		yield return new WaitForSeconds(2f);

		submarineAnimator.SetTrigger("StartGame");

		yield return new WaitForSeconds(5f);

		SceneManager.LoadScene(sceneToLoad);
	}

	public void LoadScene()
	{
		SceneManager.LoadScene(sceneToLoad);
	}

	public void LoadMainMenu()
	{
		SceneManager.LoadScene(0);
	}
}
