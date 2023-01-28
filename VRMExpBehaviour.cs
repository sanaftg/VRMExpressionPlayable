using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UniVRM10;
[RequireComponent(typeof(Vrm10Instance))]
public class VRMExpBehaviour : MonoBehaviour
{
    [SerializeField] private Vrm10Instance vrm;
    [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField,Range(0f,1f)] private float volume = 1f;
    [SerializeField] private bool isAutoBlink;
    private float blinkWeight = 0.001f;
    private float blinkWaitTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (isAutoBlink && blinkWaitTime == 0f)
        {
            blinkWeight = Mathf.PingPong(Time.time*1f,1f);
            SetWeight(ExpressionKey.Blink, blinkWeight);
            if(blinkWeight == 0f){
                blinkWaitTime = Random.Range(1f,3f);
            }
        }else{
            if(blinkWeight != 0){
                blinkWeight = 0;
                SetWeight(ExpressionKey.Blink, 0);
            }
            if(isAutoBlink && blinkWaitTime > 0f){
                blinkWaitTime = Mathf.Max(0, blinkWaitTime - Time.deltaTime);
            }
        }
    }
    public void SetWeight(ExpressionKey key,float weight){
        vrm.Runtime.Expression.SetWeight(key,weight);
    }
    public void SetWeight(ExpressionPreset preset, float weight)
    {
        if (Application.isPlaying)
        {
            List<ExpressionKey> expList = vrm.Runtime.Expression.ExpressionKeys.ToList();
            var idx =  expList.FindIndex(k => k.Preset == preset);
            if (idx < 0) return;
            var key = expList[idx];

            vrm.Runtime.Expression.SetWeight(key, weight);
        }else{
            // Editor
            var clip = vrm.Vrm.Expression.Clips.FirstOrDefault(c => c.Preset == preset);
            if (clip == default) return;
            foreach(var binding in clip.Clip.MorphTargetBindings){
                skinnedMeshRenderer.SetBlendShapeWeight(binding.Index,binding.Weight*weight * 100);
            }
        }
    }
    public void SetAutoBlink(bool isAutoBlink){
        this.isAutoBlink = isAutoBlink;
    }
}
