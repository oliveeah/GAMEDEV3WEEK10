using GameDevWithMarco.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevWithMarco.Packages
{
    public class BadOacjage : MonoBehaviour, ICollidable
    {

        [SerializeField] GameEvent badPackageCollected;

        public void CollidedLogic()
        {
            badPackageCollected.Raise();
        }
    }
}
