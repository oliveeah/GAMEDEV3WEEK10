using GameDevWithMarco.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collision : MonoBehaviour
{
    //References
    private VfxManager vfx;
    private Ripple ripple;
    public  UIManager ui;
    
    //Variables
    public bool greenCollected = false;
    
    void Start()
    {
        Initialisation();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        ExecuteLogicBasedOnWhatWeHaveCollidedWith(collision);
        Destroy(collision.gameObject);
    }

    private void ExecuteLogicBasedOnWhatWeHaveCollidedWith(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "GoodBox":
                GameManager.Instance.GreenPackLogic();
                vfx.GoodPickupParticles();
                vfx.AddPointsPromptMethod();
                ripple.RippleReaction();
                AudioManager.Instance.GoodPickupSound();
                greenCollected = true;
                break;
            case "BadBox":                
                GameManager.Instance.RedPackLogic();
                vfx.CamShake();
                vfx.BadPickupParticles();
                vfx.SubtractPointsPromptMethod();
                ui.MinusOneLifeFeedback();
                AudioManager.Instance.BadPickupSound();
                break;
            case "LifeBox":
                GameManager.Instance.lives++;
                ripple.RippleReaction();
                ui.PlusOneLifeFeedback();
                AudioManager.Instance.LifePickupSound();
                break;
            default:
                break;
        }
    }

    private void Initialisation()
    {
        vfx             = FindObjectOfType<VfxManager>();
        ripple          = FindObjectOfType<Ripple>();
        ui              = FindObjectOfType<UIManager>();
    }
}
