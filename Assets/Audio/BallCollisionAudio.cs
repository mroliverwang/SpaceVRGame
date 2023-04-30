using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionAudio : MonoBehaviour
{
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    
    void OnCollisionExit(Collision collision)
    {
        PlayAudioFeedback();
    }

    private void PlayAudioFeedback()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}