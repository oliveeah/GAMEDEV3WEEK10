using UnityEngine;

namespace GameDevWithMarco.DesignPattern
{
    [CreateAssetMenu(fileName = "Pool", menuName = "Scriptable Objects/Pool")]
    public class PoolData : ScriptableObject
    {
        //To set the size of the pool
        public int poolAmount = 40;
        //To store the prefab to use in the pool
        public GameObject poolItem;

     
    }
}
