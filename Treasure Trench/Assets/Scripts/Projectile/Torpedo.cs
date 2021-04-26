using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Torpedo : Projectile
{
	public LayerMask fishLayer;
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
	}
}
