using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ClipType {
    Song,
    FX
}

[CreateAssetMenu(fileName = "New Clip", menuName = "Sound/Clip")]
public class ClipScript : ScriptableObject
{
    public int Id;
    public string ClipName;
    public AudioClip Clip;
    public ClipType Type;
}

