//Specific Purpose: Define a component that can be utilized to play an audio clip for the 2D Player sprite and Zombie sprites
//This was identified based on a tutorial for Audio and Sound Manager Singleton Script - Daggerhart Lab

using UnityEngine;

public class SoundManager : MonoBehaviour 
{
    public AudioSource EffectsSource;
    public AudioSource MusicSource;

    public float LowPitchRange = 0.95f;
    public float HighPitchRange = 1.05f;

public static SoundManager Instance = null;

private void Singleton()
{
    if (Instance == null)
    {
        Instance = this;
    }
    
    else {
        Destroy(gameObject);
    }
    
    DontDestroyOnLoad (gameObject);
}

public void Play(AudioClip clip)
{
    EffectsSource.clip = clip;
    EffectsSource.Play();
    Debugging.Log("Audio clip playing");
}

public void PlayMusic(AudioClip clip)
{
    MusicSource.clip = clip;
    MusicSource.Play();
    Debugging.Log("Music clip playing");
    }

} 
