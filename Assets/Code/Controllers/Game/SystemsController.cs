using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemsController : MonoBehaviour
{
    public static SystemsController Instance;
    public GameStateMachine State { get; private set; }
    public BaseGameController Game { get; private set; }
    public MusicController Music { get; private set; }
    public SoundController Sound { get; private set; }
    public DialogueManager Dialogue { get; private set; }
    public CameraCont Camera { get; private set; }
    public MenuController Menu { get; private set; }

    void Awake() {
        if(Instance != null && Instance != this) {
            Destroy(this);
        } else {
            Instance = this;
        }

        State = GetComponentInChildren<GameStateMachine>();
        Game = GetComponentInChildren<BaseGameController>();
        Music = GetComponentInChildren<MusicController>();
        Sound = GetComponentInChildren<SoundController>();
        Dialogue = GetComponentInChildren<DialogueManager>();
        Camera = GetComponentInChildren<CameraCont>();
        Menu = GetComponentInChildren<MenuController>();
    }
}
