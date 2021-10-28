using Core.ObjectPooling;
using Game.Modules.IHit;
using Game.Modules.Movement;
using UnityEngine;

namespace Game.Modules.Item.Projectile
{
    public class Projectile : MonoBehaviour
    {
        #region Fields

        [SerializeField] private ProjectileData _data;
        
        private PoolObject      _poolObject;
        private Vector3         _direction = Vector3.zero;
        private int             _damage;
        private MovementSystem  _movementSystem;
        private Collider2D      _collider;
        private bool            _updateMovement = false;
    
        #endregion
    
        #region Unity callbacks
    
        private void Awake()
        {
            _poolObject = GetComponent<PoolObject>();
            _movementSystem = new MovementSystem();
            _collider = GetComponent<BoxCollider2D>();

            if (_data == null)
            {
                Debug.LogError("Assign ProjectileData to Projectile");
            }
        }

        private void Update()
        {
            if (_updateMovement)
            {
                //Update movement
                if (!_movementSystem.Move(transform, _direction, 1f, _data.Speed, _data.MaxSpeed))
                {
                    //Hide object if we outside of map
                    _poolObject.ReturnToPool();
                }
            }
            
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Projectile collided with " + other.GetComponent<Collider2D>().name);
            
            IHit.IHit hit = other.gameObject.GetComponent<IHit.IHit>();
            if (hit != null)
            {
                hit.OnHit(new HitInfo(gameObject, _damage, false));
            }

            _poolObject.ReturnToPool();
        }
    
        #endregion
        
        #region Methods

        public void SetupDirection(Vector3 dir)
        {
            _direction = dir;
        }

        public void SetupDamage(int damage)
        {
            _damage = damage;
        }

        public void LaunchProjectile()
        {
            _updateMovement = true;
        }

        public void StopProjectile()
        {
            _updateMovement = false;
        }
        
        #endregion
    }
}


