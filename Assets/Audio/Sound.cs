using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 1f;
    [Range(.1f, 3f)]
    public float pitch = 1f;

    public bool looped = false;

    [HideInInspector]
    public AudioSource source;

    public Sound(AudioClip clip, string name, GameObject parent, float volume = 1f, float pitch = 1f)
    {
        this.clip = clip;
        this.name = name;

        if (volume < 0 || volume > 1)
            this.volume = 1f;
        else
            this.volume = volume;

        if (pitch < .1f || pitch > 3f)
            this.pitch = 1f;
        else
            this.pitch = pitch;

        source = parent.AddComponent<AudioSource>();

        Setup();
    }

    public void Setup()
    {
        source.clip = clip;
        source.volume = volume;
        source.pitch = pitch;
        source.loop = looped;
    }

    public void Play()
    {
        source.Play();
    }

    public void Stop()
    {
        source.Stop();
    }
}
