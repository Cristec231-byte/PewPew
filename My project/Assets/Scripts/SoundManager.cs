using UnityEngine;

public class SoundManager : MonoBehaviour
{
  public static SoundManager instance {get; private set;}
  private AudioSource source;

  private void Awake()
  {
    instance = this;
    source = GetComponent<AudioSource>();
  }

  // Play a looping sound
    public void PlayLoopingSound(AudioClip _sound)
    {
        if (source.clip != _sound || !source.isPlaying) // Only change clip if it's a new sound
        {
            source.clip = _sound;
            source.loop = true;
            source.Play();
        }
    }

    // Stop the looping sound
    public void StopLoopingSound()
    {
       if (source.isPlaying) // Stop only if it is playing
        {
            source.loop = false;
            source.Stop();
        }
    }
}
