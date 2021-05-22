using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BackgroundMusic : MonoBehaviour
{
    static private AudioSource _audioSource;




    void Awake()
    {
        if (_audioSource)
        {

            DestroyImmediate(gameObject);
            
        }
        else
        {
            DontDestroyOnLoad(transform.gameObject);
            _audioSource = GetComponent<AudioSource>();
            
        }

    }
}
