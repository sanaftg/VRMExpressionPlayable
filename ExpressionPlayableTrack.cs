using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

[TrackBindingType(typeof(VRMExpBehaviour))] // �R���g���[������Ώۂ̌^
[TrackColor(1, 0, 0)] // �g���b�N�̐F
[TrackClipType(typeof(ExpressionPlayableClip))] // �ݒ�ł���N���b�v�̌^�i�����w��\�j
public class ExpressionPlayableTrack : TrackAsset // TrackAsset���p������
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