using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	public Transform upFire;
	public Transform downFire;

	public AudioSource shootSoundSource;
	public AudioClip shootSound;
	public float timeBetweenShots;

	private float lastFireTime;
    // Start is called before the first frame update
    void Start()
    {
		lastFireTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
		if ((Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2")) && Time.time > lastFireTime + timeBetweenShots)
		{
			Fire(Input.GetButtonDown("Fire1"));
		}
	}

	private void Fire(bool fireup)
	{

		GameObject torpedo = ObjectPool.instance.GetPooledObject("Torpedo");
		if (torpedo == null)
		{
			return;
		}
		if (fireup)
		{
			torpedo.GetComponent<Projectile>().SetDirection(upFire.up);
			torpedo.transform.position = upFire.position;
		} else
		{
			torpedo.transform.position = downFire.position;
			torpedo.GetComponent<Projectile>().SetDirection(downFire.up);
		}

		lastFireTime = Time.time;
		torpedo.SetActive(true);

		shootSoundSource.PlayOneShot(shootSound);
	}
}
