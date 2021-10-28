using UnityEngine;

namespace Game.Modules.Stats
{
    [CreateAssetMenu(menuName = "Asteroids/Stats/Stats")]
    public class Stats : ScriptableObject
    {
        public float Speed = 6f;
        public float RotationSpeed = 4f;
        public float MaxSpeed = 5f;
        public float Friction = 0.98f;
    }
}


