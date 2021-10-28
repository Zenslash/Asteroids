using Game.Modules.IHit;
using Game.Modules.Movement;
using Game.Modules.Stats;
using UnityEngine;

namespace Game.Entity
{
    public abstract class EntityView : MonoBehaviour, IHit
    {
    
        #region Fields

        [SerializeField] protected Stats _stats;
        
        protected IMovable      _movePattern;
        protected HitHandler    _hitHandler;

        #endregion

        #region Interfaces

        public void OnHit(HitInfo info)
        {
            if (_hitHandler != null)
            {
                _hitHandler.Handle(info);
            }
        }

        #endregion
    }
}


