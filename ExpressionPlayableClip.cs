using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class ExpressionPlayableClip : PlayableAsset, ITimelineClipAsset
{
    // 必ずpublic（レコードボタンが表示されない）でBehaviourを持たせる
    public ExpressionPlayableBehaviour behaviour = new ExpressionPlayableBehaviour();

    // このクリップの特徴を定義
    public ClipCaps clipCaps
    {
        get
        {
            // ブレンドに対応、タイムスケール変更に対応
            return ClipCaps.Blending | ClipCaps.SpeedMultiplier;
        }
    }

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        // BehaviourのPlayableを作って返すだけ
        return ScriptPlayable<ExpressionPlayableBehaviour>.Create(graph);
    }
}