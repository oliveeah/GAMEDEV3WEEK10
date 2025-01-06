using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevWithMarco.DataSO
{

    [CreateAssetMenu(fileName = "New Sound Data", menuName = "Scriptable Objects/SoundSO")]

    public class SoundSO : ScriptableObject
    {
        // Start is called before the first frame update
        public float minPitchValue;
        public float maxPitchValue;
        public AudioClip clipToUse;
        public float soundVolume;
    }
}
