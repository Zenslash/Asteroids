using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.ObjectPooling;
using Game.Modules.IHit;
using UnityEngine;

namespace Game.Modules.Item
{
    public class WeaponRuntime
    {
        
        #region Fields

        private WeaponData _data;
        private Transform _parent;
        private Transform _socket;
        private int _currentAmmo;
        
        private float _lastChargeTime = 0f;
        private float _lastTimeAttacked = 0f;
        
        #endregion
        
        #region Constructor
        
        public WeaponRuntime(WeaponData data, Transform transform, Transform weaponSocket)
        {
            _data = data;
            _parent = transform;
            _socket = weaponSocket;
            _currentAmmo = _data.MaxAmmo;
            
            ChargeWeapon();
        }
        
        #endregion
        
        #region Properties

        public int CurrentAmmo
        {
            get => _currentAmmo;
        }

        public float ChargeAmount
        {
            get => (Time.time - _lastChargeTime) / _data.ChargeDuration;
        }
        
        #endregion
        
        #region Methods

        public void Use()
        {
            if (Time.time - _lastTimeAttacked >= _data.FireRate)
            {
                _lastTimeAttacked = Time.time;
                
                //TODO Implement reload mechanic
                if (_data.AmmoType == AmmunitionType.RELOAD)
                {
                    if (_currentAmmo <= 0)
                    {
                        return;
                    }

                    _currentAmmo--;
                }
                
                switch (_data.AttackType)
                {
                    case AttackType.SHOOT:
                        Projectile.Projectile proj = PoolManager.GetObject(_data.ProjectilePrefab.name,
                            _socket.position, _parent.rotation).GetComponent<Projectile.Projectile>();
                        proj.SetupDirection(_parent.up);
                        proj.LaunchProjectile();
                        
                        //Play sound
                        break;
                    case AttackType.CONTINUOUS:
                        LaunchContinuous();
                        break;
                }
            }
        }
        
        #endregion
        
        #region Coroutines

        private async void LaunchContinuous()
        {
            GameObject vfx = null;
            //Enable fx
            if (_data.ShootVFX != null)
            {
                vfx = PoolManager.GetObject(_data.ShootVFX.name, _parent.position, _parent.rotation);
                vfx.SetActive(true);
            }
            //Play sound
            
            
            float time = Time.time;
            while (Time.time - time <= _data.AttackDuration)
            {
                //Raycast
                RaycastHit2D[] colliders = Physics2D.RaycastAll(_socket.position, _parent.up, _data.AttackLength, _data.AttackLayerMask);
                foreach (RaycastHit2D col in colliders)
                {
                    //Dont work
                    IHit.IHit hit = col.collider.GetComponent<IHit.IHit>();
                    if (hit != null)
                    {
                        hit.OnHit(new HitInfo(_parent.gameObject, _data.Damage, true));
                        Debug.Log("Hit " + col.collider.name);
                    }
                    else
                    {
                        Debug.LogError("Cannot find hit interface");
                    }
                }
                
                //Rotate vfx
                if (vfx != null)
                {
                    vfx.transform.rotation = _parent.rotation;
                    vfx.transform.position = _parent.position;
                }
                
                //Wait for end of frame
                await Task.Yield();
            }
            
            //Disable fx
            if (vfx != null)
            {
                vfx.GetComponent<PoolObject>().ReturnToPool();
            }
            
            //Disable sound
        }

        private async void ChargeWeapon()
        {
            if (!_data.IsCharging)
            {
                return;
            }

            while (true)
            {
                //Charge weapon
                if ((Time.time - _lastChargeTime >= _data.ChargeDuration) && _currentAmmo < _data.MaxAmmo)
                {
                    _lastChargeTime = Time.time;
                    _currentAmmo++;
                }
                
                await Task.Yield();
            }
        }
        
        #endregion
        
    }
}


