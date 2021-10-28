using Core.ObjectPooling;
using UnityEngine;

namespace Game.Modules.IHit
{
    public abstract class HitHandler
    {
        #region Fields

        protected PoolObject _poolObject;

        #endregion

        #region Constructor

        public HitHandler()
        {
            _poolObject = null;
        }
        
        public HitHandler(Transform owner)
        {
            _poolObject = owner.GetComponent<PoolObject>();
        }

        #endregion
        
        #region Methods

        public abstract void Handle(HitInfo info);

        #endregion

    }
}


