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

    // OnCollisionEnter is called when this collider/rigidbody starts touching another rigidbody/collider
    void OnCollisionEnter(Collision collision)
    {
        PlayAudioFeedback();
    }

    private void PlayAudioFeedback()
    {
        audioSource.Play();
    }
}