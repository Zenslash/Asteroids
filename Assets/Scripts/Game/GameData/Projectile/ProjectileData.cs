using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Modules.Item.Projectile
{
    
    [CreateAssetMenu(menuName = "Asteroids/ItemFramework/Projectile")]
    public class ProjectileData : ScriptableObject
    {
        public float Speed;
        public float MaxSpeed;
    }
}


