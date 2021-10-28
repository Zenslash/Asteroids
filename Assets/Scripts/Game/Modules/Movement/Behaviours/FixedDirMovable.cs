using UnityEngine;

namespace Game.Modules.Movement.Behaviours
{
    public class FixedDirMovable : IMovable
    {
        
        #region Fields
        
        private MovementSystem  _movementSystem;
        private Vector3         _dir = Vector3.up;
        private bool            _isDirDefined = false;
        
        #endregion

        
        #region Constructor

        public FixedDirMovable()
        {
            _movementSystem = new MovementSystem
            {
                IsUsingPortal = true
            };
        }

        #endregion
        
        #region Methods
        
        public void Move(Transform transform, Stats.Stats stats, Transform target = null)
        {
            if (_movementSystem == null)
            {
                _movementSystem = new MovementSystem();
            }

            if (!_isDirDefined)
            {
                _isDirDefined = true;

                _dir = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)) * _dir;
            }

            _movementSystem.Move(transform, _dir, 1f, stats.Speed, stats.MaxSpeed);
        }
        
        #endregion
    }
}
