using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Checker : MonoBehaviour
{

    public GameObject shaderObj;
    private PostProcessVolume vol;
    private ChromaticAberration chrom;
    private LensDistortion lens;
    
    void Start()
    {
       vol = shaderObj.GetComponent<PostProcessVolume>();
       
       vol.profile.TryGetSettings(out chrom);
       vol.profile.TryGetSettings(out lens);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (chrom.intensity.value > 0)
        {
            chrom.intensity.value -= Time.deltaTime * 0.5f;
        }

        if (lens.intensity.value > 15)
        {
            lens.intensity.value -= Time.deltaTime * 20 * 1f;
        }
    }
}
