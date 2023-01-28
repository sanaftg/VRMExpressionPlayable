using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UniVRM10;

/// <summary>
/// Expression‚ÌPlayableBehaviour
/// </summary>
[System.Serializable]
public class ExpressionPlayableBehaviour : PlayableBehaviour
{
    public ExpressionPreset preset;
    [Range(0f, 1f)] public float start;
    [Range(0f, 1f)] public float end;
    public bool isBlinkEye;
}