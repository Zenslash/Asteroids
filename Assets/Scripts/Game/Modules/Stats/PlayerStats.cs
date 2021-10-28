using Game.Modules.Item;
using UnityEngine;

namespace Game.Modules.Stats
{
    
    [CreateAssetMenu(menuName = "Asteroids/Stats/PlayerStats")]
    public class PlayerStats : Stats
    {
        public WeaponData FirstWeapon;
        public WeaponData SecondWeapon;
    }
}


