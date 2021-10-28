using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.ObjectPooling
{
    
    [AddComponentMenu("Pool/PoolSetup")]
    public class PoolSetup : MonoBehaviour
    {
        
        #region Unity Scene settings

        [SerializeField] private PoolManager.PoolPart[] _pools;

        #endregion
        
        #region Unity Callbacks
        
        void OnValidate()
        {
            for (int i = 0; i < _pools.Length; i++)
            {
                _pools[i].Name = _pools[i].Prefab.name; //Assign names
            }
        }

        void Awake()
        {
            Initialize ();
        }

        void Initialize ()
        {
            PoolManager.Initialize(_pools); //Init pools
        }
        
        #endregion

    }
}


