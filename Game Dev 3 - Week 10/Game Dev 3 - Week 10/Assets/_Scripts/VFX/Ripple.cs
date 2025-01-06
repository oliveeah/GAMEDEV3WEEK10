using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ripple : MonoBehaviour
{
    //Ripple Variables
    public Material RippleMaterial;
    public float MaxAmount = 50f;

    [Range(0, 1)]
    public float Friction = .9f;
    private float Amount = 0f;

    public Transform ripplePos;
    private Vector3 pos;
    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
        pos = cam.WorldToScreenPoint(ripplePos.position);
    }
    void Update()
    { 
        pos = cam.WorldToScreenPoint(ripplePos.position); 
        this.RippleMaterial.SetFloat("_Amount", this.Amount);
        this.Amount *= this.Friction;
    }

    /// <summary>
    /// This is the method we will call in other scripts
    /// </summary>
    public void RippleReaction()
    {
        this.Amount = this.MaxAmount;
        this.RippleMaterial.SetFloat("_CenterX", pos.x);
        this.RippleMaterial.SetFloat("_CenterY", pos.y);
    }

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        Graphics.Blit(src, dst, this.RippleMaterial);
    }
}
