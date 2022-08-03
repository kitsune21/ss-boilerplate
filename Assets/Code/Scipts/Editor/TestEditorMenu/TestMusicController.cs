using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestMusicController
{
    [MenuItem("Test/Music/Play Next Song")]
    public static void playNext() {
        MusicController mc = SystemsController.Instance.Music;
        ClipScript temp = mc.CurrentClip;
        if(temp != null) {
            for(int i = 0; i < mc.getSongs().Count; i++) {
                if(temp.ClipName == mc.getSongs()[i].ClipName) {
                    if(i + 1 >= mc.getSongs().Count) {
                        mc.LoopClip(mc.getSongs()[0].ClipName);
                    } else {
                        mc.LoopClip(mc.getSongs()[i+1].ClipName);
                    }
                }
            }
        } else {
            mc.LoopClip(mc.getSongs()[0].ClipName);
        }
    }
    
    [MenuItem("Test/Music/Stop Song")]
    public static void stopMusic() {
        SystemsController.Instance.Music.StopClip();
    }
}
