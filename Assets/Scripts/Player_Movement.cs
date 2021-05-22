using TMPro;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
	// This is a reference to the Rigidbody component
	public Rigidbody rb;
	public float forwardForce = 2000f;
	public float sidwaysForce = 100f;
	public float upForce = 1000f;
	bool isGrounded;
	bool soundPlayed;
	bool startGame;

	GameObject startLevel;

	private AudioSource source;
	public AudioClip fallSound;

	void Start()
	{
		Time.timeScale = 0f;
		source = GetComponent<AudioSource>();
		startLevel = GameObject.Find("StartLevel");
	}

	//OnCollisionEnter() wird ausgeführt, sobald ein Rigidbody und/oder Collider mit einem anderen Rigidbody und/oder Collider zusammenstöß
	void OnCollisionEnter()
	{
		isGrounded = true;
	}

	void OnCollisionExit()  //Das ist die Methode für links und rechts. Der Sprung wird
	{						//direkt in der Methode auf "false" gesetzt
	
		isGrounded = false;
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.W))
		{
			startGame = true;
			startLevel.SetActive(false);
			Time.timeScale = 1f;
		}
	}



	// This is marked as "FixedUpdate" because we are messing around
	// with physics and Unity likes that better than "Update"
	void FixedUpdate()
	{
		
			if (startGame == true)
			{
				rb.AddForce(0, 0, forwardForce * Time.deltaTime); // Add a forward force on the z-axis
																  // Time.deltaTime sorta controls the fps so it runs smoothly on every system and not fast on strong systems an slow on weaks systems

				// Moves the object "Player" to the right if the user presses "d"
				if (Input.GetKey(KeyCode.D) && isGrounded == true)
				{
					rb.AddForce(sidwaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

				}

				// Moves the object "Player" to the left if the user presses "a"
				if (Input.GetKey(KeyCode.A) && isGrounded == true)
				{
					rb.AddForce(-sidwaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
				}


				// Moves the object "Player"  up if the user presses "space" and this object is touching the object "Ground"
				if (Input.GetKey(KeyCode.Space) && isGrounded == true)
				{
					rb.AddForce(0, upForce * Time.deltaTime, 0, ForceMode.VelocityChange);
					isGrounded = false; 
				}

				if (rb.position.y < -1f)
				{
					FindObjectOfType<GameManager>().Gameover();


					if (soundPlayed == false)
					{
						source.PlayOneShot(fallSound, 1.0f);
						soundPlayed = true;
					}
				}
			}
		
	}
	
}	

