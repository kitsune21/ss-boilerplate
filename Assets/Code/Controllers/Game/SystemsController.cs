using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemsController : MonoBehaviour
{
    public static SystemsController systemInstance;
    public GameStateMachine gsm;
    public BaseGameController bgc;
    public MusicController mc;
    public SoundController sc;
    public DialogueManager dm;
    public CameraCont cc;
    public Player player;

    void Awake() {
        if(systemInstance != null && systemInstance != this) {
            Destroy(this);
        } else {
            systemInstance = this;
        }
    }
}
