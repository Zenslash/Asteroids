using UnityEngine;

namespace Game.Entity.Spawner
{
    public class SpawnSetup : MonoBehaviour
    {
        
        #region Fields

        [SerializeField] private SpawnerData[]  _spawnerDatas;
        [SerializeField] private Transform[]    _spawnPoints;

        #endregion

        #region Unity Callbacks

        // Start is called before the first frame update
        void Awake()
        {
            SpawnManager.Initialize(_spawnerDatas, _spawnPoints);
        }

        // Update is called once per frame
        void Update()
        {
            SpawnManager.Update();
        }

        #endregion
        
    }
}
