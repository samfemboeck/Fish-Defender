using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioClip MenuClip;
    public AudioClip GameClip;
    public AudioSource MusicSource;
    bool alreadyPlaying;

    void Start()
    {
        MusicSource.clip = MenuClip;
        MusicSource.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !alreadyPlaying)
        {
            MusicSource.clip = GameClip;
            MusicSource.Play();
            alreadyPlaying = true;
        }
    }

}
