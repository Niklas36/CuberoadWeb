using UnityEngine;

public class Player_Collision : MonoBehaviour
{
	private AudioSource source;
	public AudioClip crashSound;

	public Player_Movement movement;

	void Start()
	{
		source = GetComponent<AudioSource>();
	}

	void OnCollisionEnter(Collision collisionInfo)
	{
		if (collisionInfo.collider.tag == "Obstacle")
		{
			movement.enabled = false;
			FindObjectOfType<GameManager>().Gameover();
			source.PlayOneShot(crashSound, 1.0f);
		}
	}
}
