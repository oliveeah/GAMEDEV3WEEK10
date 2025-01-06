using GameDevWithMarco.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariablesSetter : MonoBehaviour
{
    [SerializeField] Animator transitionAnim;

    private void Awake()
    {
        //Sets the fade variable
        MyScenemanager.Instance.transitionAnim = transitionAnim;
    }
}
