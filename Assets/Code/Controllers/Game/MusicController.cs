using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource audioPlayer;
    public float volume;
    public float currentVolume;

    public List<ClipScript> songs = new List<ClipScript>();
    private ClipScript currentClip;

    public bool isFading = false;
    
    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(isFading)
        {
            if(currentVolume < volume)
            {
                currentVolume += 0.001f;
                audioPlayer.volume = currentVolume;
            } else
            {
                isFading = false;
                currentVolume = volume;
            }
        }
    }


    private ClipScript stringToClip(string clip)
    {
        foreach(ClipScript song in songs)
        {
            if(song.clipName == clip)
            {
                return song;
            }
        }

        return null;
    }

    public void loopClip(string clip)
    {
        currentClip = stringToClip(clip);
        audioPlayer.clip = currentClip.clip;
        audioPlayer.loop = true;
        audioPlayer.Play();
    }

    public void stopClip()
    {
        audioPlayer.Stop();
    }

    public void endLoop()
    {
        audioPlayer.loop = false;
    }

    public bool getClipStatus()
    {
        if(audioPlayer.isPlaying)
        {
            return false;
        } else
        {
            return true;
        }
    }

    public void updateVolume(float newVolume)
    {
        volume = newVolume;
        currentVolume = newVolume;
        audioPlayer.volume = volume;
    }

    public bool isClipPlaying(string clip)
    {
        if(clip == currentClip.clipName)
        {
            return true;
        } else
        {
            return false;
        }
    }

    public void fadeInClip(string clip)
    {
        loopClip(clip);
        isFading = true;
        currentVolume = 0f;
    }

    public ClipScript getCurrentClip() {
        return currentClip;
    }
}
