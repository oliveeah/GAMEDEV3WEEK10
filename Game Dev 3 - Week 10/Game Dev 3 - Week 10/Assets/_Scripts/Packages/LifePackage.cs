using GameDevWithMarco.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevWithMarco.Packages
{
    public class LifePackage : MonoBehaviour, ICollidable
    {
        [SerializeField] GameEvent lifePackageCollected;

        public void CollidedLogic()
        {
            lifePackageCollected.Raise();
        }
    }
}
