using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource audioPlayer1;
    private AudioSource audioPlayer2;
    private AudioSource player;
    public float volume;
    private bool isPlaying1;

    public List<ClipScript> songs = new List<ClipScript>();
    private ClipScript currentClip;

    public DefaultableText musicVolumeText;
    
    void Start()
    {
        audioPlayer1 = gameObject.AddComponent<AudioSource>();
        audioPlayer2 = gameObject.AddComponent<AudioSource>();
        player = audioPlayer1;
        loopClip("menu");
        musicVolumeText.updateText("10");
        isPlaying1 = true;
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
        player.clip = currentClip.clip;
        player.loop = true;
        player.Play();
    }

    public void stopClip()
    {
        player.Stop();
    }

    public void endLoop()
    {
        player.loop = false;
    }

    public bool getClipStatus()
    {
        if(player.isPlaying)
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
        player.volume = volume;
        float volumeText = newVolume * 10;
        int volumeTextInt = (int)volumeText;
        musicVolumeText.updateText(volumeTextInt.ToString());
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
    }

    public ClipScript getCurrentClip() {
        return currentClip;
    }

    public void crossFadeClip(string clip) {
        StopAllCoroutines();

        StartCoroutine(FadeTrack(clip));

        isPlaying1 = !isPlaying1;
    }

    private IEnumerator FadeTrack(string clip) {
        float timeToFade = 3f;
        float timeElapsed = 0f;

        if(isPlaying1){
            player = audioPlayer2;
            loopClip(clip);

            while(timeElapsed < timeToFade) {
                audioPlayer2.volume = Mathf.Lerp(0, volume, timeElapsed / timeToFade);
                audioPlayer1.volume = Mathf.Lerp(volume, 0, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            audioPlayer1.Stop();
            
        } else {
            player = audioPlayer1;
            loopClip(clip);

            while(timeElapsed < timeToFade) {
                audioPlayer1.volume = Mathf.Lerp(0, volume, timeElapsed / timeToFade);
                audioPlayer2.volume = Mathf.Lerp(volume, 0, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            audioPlayer2.Stop();
        }
    }
}
