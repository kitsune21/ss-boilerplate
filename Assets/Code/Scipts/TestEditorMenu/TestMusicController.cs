using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestMusicController
{
    [MenuItem("Test/Music/Play Next Song")]
    public static void playNext() {
        MusicController mc = SystemsController.systemInstance.mc;
        ClipScript temp = mc.getCurrentClip();
        if(temp != null) {
            for(int i = 0; i < mc.songs.Count; i++) {
                if(temp.clipName == mc.songs[i].clipName) {
                    if(i + 1 >= mc.songs.Count) {
                        mc.loopClip(mc.songs[0].clipName);
                    } else {
                        mc.loopClip(mc.songs[i+1].clipName);
                    }
                }
            }
        } else {
            mc.loopClip(mc.songs[0].clipName);
        }
    }
    
    [MenuItem("Test/Music/Stop Song")]
    public static void stopMusic() {
        SystemsController.systemInstance.mc.stopClip();
    }
}
