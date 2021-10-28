using System.Collections;
using System.Collections.Generic;
using Game.Modules.Input;
using Game.Modules.Item;
using Game.Modules.Stats;
using UnityEngine;

namespace Game.Player
{
    public class PlayerAttack
    {

        #region Fields
        
        private PlayerStats _stats;
        private Transform _transform;
        private Transform _weaponSocket;
        private WeaponRuntime _firstWeapon;
        private WeaponRuntime _secondWeapon;
        
        #endregion
        
        #region Constructor/Destructor
        
        public PlayerAttack(PlayerStats stats, Transform transform, Transform weaponSocket)
        {
            _stats = stats;
            _transform = transform;
            _weaponSocket = weaponSocket;

            if (_stats.FirstWeapon != null)
            {
                _firstWeapon = new WeaponRuntime(_stats.FirstWeapon, _transform, _weaponSocket);
            }
            if (_stats.SecondWeapon != null)
            {
                _secondWeapon = new WeaponRuntime(_stats.SecondWeapon, _transform, _weaponSocket);
            }
        }
        
        #endregion
        
        #region Properties

        public int CurrentAmmo
        {
            get
            {
                if (_stats.FirstWeapon != null && _stats.FirstWeapon.AmmoType == AmmunitionType.RELOAD)
                {
                    return _firstWeapon.CurrentAmmo;
                }
                if (_stats.SecondWeapon != null && _stats.SecondWeapon.AmmoType == AmmunitionType.RELOAD)
                {
                    return _secondWeapon.CurrentAmmo;
                }

                return 0;
            }
        }

        public int MaxAmmo
        {
            get
            {
                if (_stats.FirstWeapon != null && _stats.FirstWeapon.AmmoType == AmmunitionType.RELOAD)
                {
                    return _stats.FirstWeapon.MaxAmmo;
                }
                if (_stats.SecondWeapon != null && _stats.SecondWeapon.AmmoType == AmmunitionType.RELOAD)
                {
                    return _stats.SecondWeapon.MaxAmmo;
                }

                return 0;
            }
        }

        public float ChargeAmount
        {
            get
            {
                if (_stats.FirstWeapon != null && _stats.FirstWeapon.IsCharging)
                {
                    return _firstWeapon.ChargeAmount;
                }
                if (_stats.SecondWeapon != null && _stats.SecondWeapon.IsCharging)
                {
                    return _secondWeapon.ChargeAmount;
                }

                return 0;
            }
        }
        
        #endregion

        #region Callbacks
        
        public void Update(GameObject obj, InputVars vars)
        {
            if (vars.Fire < 0f && _firstWeapon != null)
            {
                _firstWeapon.Use();
            }
            else if (vars.Fire > 0f && _secondWeapon != null)
            {
                _secondWeapon.Use();
            }
        }
        
        #endregion
        
        #region Methods
        
        
        
        #endregion
    }
}


