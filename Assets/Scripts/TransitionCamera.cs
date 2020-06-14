using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionCamera : MonoBehaviour
{
    [SerializeField] Material TransitionMaterial;
    // Start is called before the first frame update
    float cutOff = 1f;
    void Start()
    {
        // TransitionMaterial.SetFloat("_Fade",1);
        TransitionMaterial.SetFloat("_Cutoff",cutOff);
        TransitionMaterial.SetFloat("_Fade",1);
    }

    // Update is called once per frame
    void Update()
    {
        if (cutOff > 0)
        {
        cutOff  -= Time.deltaTime;
        TransitionMaterial.SetFloat("_Cutoff",cutOff);            
        }

    }
    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        if (TransitionMaterial != null)
            Graphics.Blit(src, dst, TransitionMaterial);
    }
}
