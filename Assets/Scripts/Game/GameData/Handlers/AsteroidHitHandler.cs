using Core.ObjectPooling;
using Game.Entity.Spawner;
using UnityEngine;

namespace Game.Modules.IHit.Handlers
{
    public class AsteroidHitHandler : HitHandler
    {
        #region Constructor

        public AsteroidHitHandler(Transform transform) : base(transform)
        {
            
        }
        
        #endregion
        
        #region Methods

        public override void Handle(HitInfo info)
        {
            if (_poolObject != null)
            {
                GameStats.score += 100;
                
                if (info.ForceDestroy)
                {
                    SpawnManager.FreeObject(_poolObject.name);
                    _poolObject.ReturnToPool();
                    return;
                }

                for (int i = 0; i < 4; i++)
                {
                    GameObject go = PoolManager.GetObject("SmallAsteroid", _poolObject.transform.position,
                        _poolObject.transform.rotation);
                }
                
                SpawnManager.FreeObject(_poolObject.name);
                _poolObject.ReturnToPool();
            }
        }

        #endregion
    }
}


