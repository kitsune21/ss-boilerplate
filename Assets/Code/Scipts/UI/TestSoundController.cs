using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSoundController : MonoBehaviour
{
    public SoundController sc;

    public void playRandomSound() {
        sc.playRandomSound();
    }
}
