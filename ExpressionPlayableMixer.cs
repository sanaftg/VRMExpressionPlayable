using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;
using UniVRM10;

public class ExpressionPlayableMixerBehaviour : PlayableBehaviour
{
    public TimelineClip[] Clips { get; set; }
    public PlayableDirector Director { get; set; }

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        if (Clips.Length == 0) return;
        var vrmExp = playerData as VRMExpBehaviour;
        if (vrmExp == null)
        {
            return;
        }
        var time = Director.time; // TimelineëSëÃÇÃåªç›ÇÃéûä‘
        ExpressionPreset[] presets = (ExpressionPreset[])System.Enum.GetValues(typeof(ExpressionPreset));
        foreach (var preset in presets)
        {
            for (int i = 0; i < Clips.Length; i++)
            {
                var weight = 0f;
                var clip = Clips[i];
                var clipAsset = clip.asset as ExpressionPlayableClip;
                var behaviour = clipAsset.behaviour;
                if (behaviour.preset != preset)
                {
                    if (i == 1)
                    {
                        // èâä˙âª
                        vrmExp.SetWeight(preset, 0);
                    }
                }
                else
                {
                    var clipWeight = playable.GetInputWeight(i);
                    var clipProgress = (float)((time - clip.start) / clip.duration);
                    if (clipProgress >= 0.0f && clipProgress <= 1.0f)
                    {
                        weight += Mathf.Lerp(behaviour.start, behaviour.end, clipProgress) * clipWeight;
                    }
                    vrmExp.SetWeight(preset, weight);
                    vrmExp.SetAutoBlink(behaviour.isBlinkEye);
                    break;
                }
            }
        }



    }
}