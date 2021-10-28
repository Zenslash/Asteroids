using UnityEngine;

namespace Game.Modules.IHit
{
    public struct HitInfo
    {
        public GameObject   Source;
        public int          Damage;
        public bool         ForceDestroy;

        public HitInfo(GameObject source, int damage, bool forceDestroy)
        {
            Source = source;
            Damage = damage;
            ForceDestroy = forceDestroy;
        }
    }
}


