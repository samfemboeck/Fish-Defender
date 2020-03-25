using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.Setup();
        }
    }

    public void Play(string name)
    {
        Sound sound = FindSoundByName(name);
        sound.Play();
    }

    public void Stop(string name)
    {
        Sound sound = FindSoundByName(name);
        sound.Stop();
    }

    private Sound FindSoundByName(string name)
    {
        Sound sound = System.Array.Find(sounds, s => s.name == name);
        if (sound == null)
            Debug.LogWarning("Sound " + name + " not found!");
        return sound;
    }
}
