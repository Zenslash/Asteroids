using UnityEngine;

namespace Game.Modules.IHit.Handlers
{
    public class PlayerHitHandler : HitHandler
    {
        #region Fields

        private Transform _transform;

        #endregion
        
        #region Constructor
        public PlayerHitHandler(Transform transform) : base(transform)
        {
            _transform = transform;
        }
        
        #endregion
        
        #region Methods

        public override void Handle(HitInfo info)
        {
            Debug.LogError("Player dead");
            _transform.gameObject.SetActive(false);
            
            GameController.Instance.ShowEndGameWnd();
        }

        #endregion
    }
}
