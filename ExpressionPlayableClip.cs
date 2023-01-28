using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class ExpressionPlayableClip : PlayableAsset, ITimelineClipAsset
{
    // �K��public�i���R�[�h�{�^�����\������Ȃ��j��Behaviour����������
    public ExpressionPlayableBehaviour behaviour = new ExpressionPlayableBehaviour();

    // ���̃N���b�v�̓������`
    public ClipCaps clipCaps
    {
        get
        {
            // �u�����h�ɑΉ��A�^�C���X�P�[���ύX�ɑΉ�
            return ClipCaps.Blending | ClipCaps.SpeedMultiplier;
        }
    }

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        // Behaviour��Playable������ĕԂ�����
        return ScriptPlayable<ExpressionPlayableBehaviour>.Create(graph);
    }
}