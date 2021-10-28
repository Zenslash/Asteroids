using UnityEngine;

namespace Game.Modules.Movement.Behaviours
{
    public class FollowPlayerMovable : IMovable
    {
        #region Fields
        
        private MovementSystem  _movementSystem;
        private Vector3         _dir;
        
        #endregion

        #region Constructor

        public FollowPlayerMovable()
        {
            _movementSystem = new MovementSystem
            {
                IsUsingPortal = true
            };
        }

        #endregion
        
        public void Move(Transform transform, Stats.Stats stats, Transform target)
        {
            if (target == null)
            {
                return;
            }

            Vector3 targetPos = target.position;
            _dir = Vector3.Normalize(targetPos - transform.position);

            _movementSystem.RotateToPoint(transform, targetPos);
            _movementSystem.Move(transform, _dir, 1f, stats.Speed, stats.MaxSpeed);
        }
    }
}
