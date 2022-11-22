using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    void Awake() { instance = this;  }

    //Sound Effects
    public AudioClip sfx_Landing, sfx_Attack;
    //Music
    public AudioClip music_creepy;

    public GameObject currentMusicObject;

    //Sound object
    public GameObject soundObject;

    public void PlaySFX(string sfxName)
    {
        switch (sfxName)
        {
            case "Landing":
                SoundObjectCreation(sfx_Landing);
                break;
        }    
    }

    public void PlayMusic(string musicName)
    {
        switch (musicName)
        {
            case "Creepy":
                MusicObjectCreation(music_creepy);
                break;

        }
    }

    void MusicObjectCreation(AudioClip clip)
    {
        if (currentMusicObject)
            Destroy(currentMusicObject);

        currentMusicObject = Instantiate(soundObject, transform);
        currentMusicObject.GetComponent<AudioSource>().clip = clip;
        currentMusicObject.GetComponent<AudioSource>().Play();
    }

    void SoundObjectCreation(AudioClip clip)
    {
        GameObject newObject = Instantiate(soundObject, transform);
        newObject.GetComponent<AudioSource>().clip = clip;
        newObject.GetComponent<AudioSource>().Play();
    }

}
