using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMusicController : MonoBehaviour
{
    public MusicController mc;

    public void playNext() {
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
    
    public void stopMusic() {
        mc.stopClip();
    }
}
