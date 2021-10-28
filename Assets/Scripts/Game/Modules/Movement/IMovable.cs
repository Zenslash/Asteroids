
using UnityEngine;

namespace Game.Modules.Movement
{
    public interface IMovable
    {
        public void Move(Transform transform, Stats.Stats stats, Transform target = null);
    }
}


