using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestSoundController
{
    [MenuItem("Test/Sound/Play Random Sound")]
    public static void playRandomSound() {
        SystemsController.systemInstance.sc.playRandomSound();
    }
}
