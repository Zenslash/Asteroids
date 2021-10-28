using UnityEngine;

namespace Game.Entity.Spawner
{
    
    [CreateAssetMenu(menuName = "Asteroids/Spawner/SpawnerData")]
    public class SpawnerData : ScriptableObject
    {
        public GameObject   Prefab;
        public float        Delay;
        public int          MaxObjectOnScene;
    }
}


