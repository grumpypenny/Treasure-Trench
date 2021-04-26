using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Torpedo : Projectile
{
	public LayerMask fishLayer;
	public GameObject bubbleParticleSystem;

	private void OnEnable()
	{
		if (transform.childCount == 0)
		{
			GameObject obj = Instantiate(bubbleParticleSystem);
			obj.transform.parent = transform;
			obj.transform.localPosition = new Vector3(-0.95f, 0f, 1f);
			obj.transform.forward = -transform.right;
			obj.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
		}
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if (fishLayer == (fishLayer | (1 << collider.gameObject.layer)))
		{
			if (collider.gameObject.tag.Equals("AnglerFish"))
			{
				GameObject player = GameObject.FindGameObjectWithTag("Player");

				if (player != null)
					player.GetComponent<IHealth>().Heal();
			}

			int score = collider.gameObject.GetComponent<Fish>().score;
			collider.gameObject.SetActive(false);
			FindObjectOfType<ScoreManager>().UpdateScore(score);
		}

		Transform bubbleEffect = transform.GetChild(0);
		bubbleEffect.parent = null;
		bubbleEffect.localScale = new Vector3(0.5f, 0.5f, 1f);
		Destroy(bubbleEffect.gameObject, 5f);
		gameObject.SetActive(false);
	}
}
