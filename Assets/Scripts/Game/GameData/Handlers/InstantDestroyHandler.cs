using System.Collections;
using System.Collections.Generic;
using Core.ObjectPooling;
using Game.Entity.Spawner;
using UnityEngine;

namespace Game.Modules.IHit.Handlers
{
    public class InstantDestroyHandler : HitHandler
    {

        #region Constructor

        public InstantDestroyHandler(Transform transform) : base(transform)
        {
            
        }
        
        #endregion
        
        #region Methods

        public override void Handle(HitInfo info)
        {
            if (_poolObject != null)
            {
                GameStats.score += 100;
                
                SpawnManager.FreeObject(_poolObject.name);
                _poolObject.ReturnToPool();
            }
        }

        #endregion
    }
}
