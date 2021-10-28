using Game.Modules.IHit.Handlers;
using Game.Modules.Movement.Behaviours;
using UnityEngine;

namespace Game.Entity
{
    public class UFOView : EntityView
    {
        private Transform _playerTransform = null;
        
        #region Unity Callbacks
        
        // Start is called before the first frame update
        void Start()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                _playerTransform = player.transform;
            }

            _movePattern = new FollowPlayerMovable();
            _hitHandler = new InstantDestroyHandler(transform);
        }

        private void Update()
        {
            _movePattern.Move(transform, _stats, _playerTransform);
        }

        #endregion
    
    }
}
