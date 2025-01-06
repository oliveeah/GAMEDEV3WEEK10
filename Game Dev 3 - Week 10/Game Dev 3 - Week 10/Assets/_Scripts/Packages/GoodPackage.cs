using GameDevWithMarco.Interfaces;
using GameDevWithMarco.Managers;
using UnityEngine;

namespace GameDevWithMarco.Packages
{
    public class GoodPackage : MonoBehaviour, ICollidable
    {
        [SerializeField] GameEvent goodPackageCollected;

        public void CollidedLogic()
        {
            goodPackageCollected.Raise();
        }
    }
}
