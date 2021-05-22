using UnityEngine;

public class Finishline : MonoBehaviour
{
    private AudioSource source;
    public AudioClip finishSound;

    public GameManager gameManager;


    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    void OnTriggerEnter()
    {
        gameManager.CompleteLevel();

        source.PlayOneShot(finishSound, 1.0f);
    }
}
