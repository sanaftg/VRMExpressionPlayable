using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

[TrackBindingType(typeof(VRMExpBehaviour))] // コントロールする対象の型
[TrackColor(1, 0, 0)] // トラックの色
[TrackClipType(typeof(ExpressionPlayableClip))] // 設定できるクリップの型（複数指定可能）
public class ExpressionPlayableTrack : TrackAsset // TrackAssetを継承する
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        // Mixer
        var mixer = ScriptPlayable<ExpressionPlayableMixerBehaviour>.Create(graph, inputCount);
        mixer.GetBehaviour().Clips = GetClips().ToArray();
        mixer.GetBehaviour().Director = go.GetComponent<PlayableDirector>();
        return mixer;
    }
}