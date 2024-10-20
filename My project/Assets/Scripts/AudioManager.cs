using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

//using static Unity.VisualScripting.Member;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] musicSounds, pewSounds, sfxSounds;
    public AudioSource musicSource, pewSource, sfxSource;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("Background");
    }
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null) 
        {
            Debug.Log("Sound not found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void StopMusic()
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }


    public void PlayPew(string name)
    {
        Sound s = Array.Find(pewSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            pewSource.PlayOneShot(s.clip);
            
        }
    }
    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            sfxSource.clip = s.clip;
            sfxSource.Play();

        }
    }

    // Play a looping sound
    public void PlayLoopingSound(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            sfxSource.clip = s.clip;
            sfxSource.loop = true;
            sfxSource.Play();

        }
        
        
    }

    // Stop the looping sound
    public void StopLoopingSound()
    {
        if (sfxSource.isPlaying) // Stop only if it is playing
        {
            sfxSource.loop = false;
            sfxSource.Stop();
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void TogglePew()
    {
        pewSource.mute = !pewSource.mute;   
    }

    public void ToggleSfx()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void PewVolume(float volume)
    {
        pewSource.volume = volume;
    }

    public void SfxVolume(float volume)
    {
        sfxSource.volume = volume;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene Loaded: " + scene.name); // To verify scene name

        if (scene.name == "Main Menu")
        {
            StopMusic(); // Stop the music when returning to the main menu
        }
        else if (scene.name == "SampleScene" || (scene.name == "Easy2")|| (scene.name == "Easy3")|| (scene.name == "Medium")|| (scene.name == "Medium2")|| (scene.name == "Medium3")|| (scene.name == "Hard")|| (scene.name == "Hard 2")|| (scene.name == "Hard 3"))  // Replace "Game" with your actual game scene name
        {
            PlayMusic("Background"); // Play the background music when entering the game scene
        }
    }


}


