using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour    
{
    /// <summary>
    /// This script will make the whatever it is attached to
    /// </summary>

    public float rotationSpeed;
    

    // Update is called once per frame
    void Update()
    {
        Rotation();
    }

    private void Rotation()
    {
        transform.Rotate(0, 0, rotationSpeed);
    }
}
