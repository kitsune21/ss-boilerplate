using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private List<ClipScript> fxs = new List<ClipScript>();

    private List<AudioSource> audioPlayers;

    private float volume;
    [SerializeField] private DefaultableText soundVolumeText;

    void Awake()
    {
        audioPlayers = new List<AudioSource>();
        volume = 1f;
        soundVolumeText.UpdateText("10");
    }

    void FixedUpdate()
    {
        if(audioPlayers.Count > 0)
        {
            List<AudioSource> tempList = new List<AudioSource>();
            foreach (AudioSource player in audioPlayers)
            {
                if (!player.isPlaying)
                {
                    DestroyImmediate(player);
                } else
                {
                    tempList.Add(player);
                }
            }
            audioPlayers = tempList;
        }
    }

    private ClipScript stringToClip(string effect)
    {
        foreach (ClipScript fx in fxs)
        {
            if (fx.ClipName == effect)
            {
                return fx;
            }
        }

        return null;
    }

    private AudioSource availableSource()
    {
        foreach(AudioSource player in audioPlayers)
        {
            if(!player.isPlaying)
            {
                return player;
            }
        }

        AudioSource temp =  gameObject.AddComponent<AudioSource>();
        audioPlayers.Add(temp);

        return temp;
    }

    public void PlayEffect(string effect)
    {
        AudioSource availablePlayer = availableSource();
        availablePlayer.clip = stringToClip(effect).Clip;
        availablePlayer.volume = volume;
        availablePlayer.Play();
    }

    public void UpdateVolume(float newVolume) {
        volume = newVolume;
        float volumeText = newVolume * 10;
        int volumeTextInt = (int)volumeText;
        soundVolumeText.UpdateText(volumeTextInt.ToString());
        PlayEffect("click");
    }
}
