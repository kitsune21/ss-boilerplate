using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public List<ClipScript> fxs = new List<ClipScript>();

    private List<AudioSource> audioPlayers;

    public float volume;
    public DefaultableText soundVolumeText;

    void Awake()
    {
        audioPlayers = new List<AudioSource>();
        volume = 1f;
        soundVolumeText.updateText("10");
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
            if (fx.clipName == effect)
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

    public void playEffect(string effect)
    {
        AudioSource availablePlayer = availableSource();
        availablePlayer.clip = stringToClip(effect).clip;
        availablePlayer.volume = volume;
        availablePlayer.Play();
    }

    public void playRandomSound()
    {
        int randomIndex = Random.Range(0, fxs.Count);
        AudioSource availablePlayer = availableSource();
        availablePlayer.clip = fxs[randomIndex].clip;
        availablePlayer.volume = volume;
        availablePlayer.Play();
    }

    public void updateVolume(float newVolume) {
        volume = newVolume;
        float volumeText = newVolume * 10;
        int volumeTextInt = (int)volumeText;
        soundVolumeText.updateText(volumeTextInt.ToString());
        playEffect("click");
    }
}
