using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource audioPlayer1;
    private AudioSource audioPlayer2;
    private AudioSource player;
    private float volume;
    private bool isPlaying1;
    [SerializeField] private List<ClipScript> songs = new List<ClipScript>();
    public ClipScript CurrentClip { get; private set; }
    [SerializeField] private DefaultableText musicVolumeText;
    
    void Start()
    {
        audioPlayer1 = gameObject.AddComponent<AudioSource>();
        audioPlayer2 = gameObject.AddComponent<AudioSource>();
        player = audioPlayer1;
        LoopClip("menu");
        musicVolumeText.UpdateText("10");
        isPlaying1 = true;
    }


    private ClipScript stringToClip(string clip)
    {
        foreach(ClipScript song in songs)
        {
            if(song.ClipName == clip)
            {
                return song;
            }
        }

        return null;
    }

    public void LoopClip(string clip)
    {
        CurrentClip = stringToClip(clip);
        player.clip = CurrentClip.Clip;
        player.loop = true;
        player.Play();
    }

    public void StopClip()
    {
        player.Stop();
    }

    public void UpdateVolume(float newVolume)
    {
        volume = newVolume;
        player.volume = volume;
        float volumeText = newVolume * 10;
        int volumeTextInt = (int)volumeText;
        musicVolumeText.UpdateText(volumeTextInt.ToString());
    }

    public void CrossFadeClip(string clip) {
        StopAllCoroutines();

        StartCoroutine(FadeTrack(clip));

        isPlaying1 = !isPlaying1;
    }

    private IEnumerator FadeTrack(string clip) {
        float timeToFade = 3f;
        float timeElapsed = 0f;

        if(isPlaying1){
            player = audioPlayer2;
            LoopClip(clip);

            while(timeElapsed < timeToFade) {
                audioPlayer2.volume = Mathf.Lerp(0, volume, timeElapsed / timeToFade);
                audioPlayer1.volume = Mathf.Lerp(volume, 0, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            audioPlayer1.Stop();
            
        } else {
            player = audioPlayer1;
            LoopClip(clip);

            while(timeElapsed < timeToFade) {
                audioPlayer1.volume = Mathf.Lerp(0, volume, timeElapsed / timeToFade);
                audioPlayer2.volume = Mathf.Lerp(volume, 0, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            audioPlayer2.Stop();
        }
    }

    public List<ClipScript> getSongs() {
        return songs;
    }
}
