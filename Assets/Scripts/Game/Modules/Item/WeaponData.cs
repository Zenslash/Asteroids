using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Modules.Item
{
    public enum AmmunitionType : byte
    {
        INFINITE = 0,
        RELOAD = 1
    }

    public enum AttackType : byte
    {
        SHOOT = 0,
        CONTINUOUS = 1
    }

    [CreateAssetMenu(menuName = "Asteroids/ItemFramework/Weapon")]
    public class WeaponData : ItemData
    {
        public GameObject       ProjectilePrefab;
        public GameObject       ShootVFX;
        public AudioClip        ShootFX;

        public int              Damage;
        
        public float            FireRate;
        public AmmunitionType   AmmoType;
        public int              MaxAmmo;
        public bool             IsCharging;
        public float            ChargeDuration;

        public AttackType       AttackType;
        
        [Header("Continuous Attack Type")]
        /**
         * Used only for CONTINUOUS attacks
         * Leave it 0 if you're using SHOOT type
         */
        public float            AttackDuration;
        /**
         * Used only for CONTINUOUS attacks
         * Leave it 0 if you're using SHOOT type
         */
        public float            AttackLength;

        public LayerMask        AttackLayerMask;
    }
}


