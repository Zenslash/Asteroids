using System;
using Game.Modules.IHit.Handlers;
using Game.Modules.Movement.Behaviours;
using UnityEngine;

namespace Game.Entity
{
    public class AsteroidView : EntityView
    {
        #region Unity Callbacks
        
        // Start is called before the first frame update
        void Start()
        {
            _movePattern = new FixedDirMovable();
            _hitHandler = new AsteroidHitHandler(transform);
        }

        private void Update()
        {
            _movePattern.Move(transform, _stats);
        }

        #endregion
    }
}


