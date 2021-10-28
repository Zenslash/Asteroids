using Core.ObjectPooling;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Game.Entity.Spawner
{
    public static class SpawnManager
    {
        #region Fields

        private static SpawnerData[]    _datas;
        private static float[]          _lastTimeDataUsed;
        private static int[]            _objectsOnScene;
        private static Transform[]      _spawnPoints;

        private static int              _currentSpawnIndex = 0;
        
        #endregion

        public static void Initialize(SpawnerData[] newData, Transform[] spawnPoints)
        {
            _datas = newData;
            _lastTimeDataUsed = new float[_datas.Length];
            _objectsOnScene = new int[_datas.Length];
            _spawnPoints = spawnPoints;
        }

        public static void Update()
        {
            if (_datas == null)
            {
                return;
            }
            
            for (int i = 0; i < _datas.Length; i++)
            {
                if (Time.time - _lastTimeDataUsed[i] >= _datas[i].Delay &&
                    (_objectsOnScene[i] < _datas[i].MaxObjectOnScene))
                {
                    //Spawn object
                    _lastTimeDataUsed[i] = Time.time;
                    _objectsOnScene[i]++;

                    GameObject go = PoolManager.GetObject(_datas[i].Prefab.name, Vector3.zero, Quaternion.identity);
                    if (_currentSpawnIndex >= _spawnPoints.Length)
                    {
                        _currentSpawnIndex = 0;
                    }
                    go.transform.position = _spawnPoints[_currentSpawnIndex++].position;
                }
            }
        }

        public static void FreeObject(string name)
        {
            if (_datas == null)
            {
                return;
            }

            for (int i = 0; i < _datas.Length; i++)
            {
                if (_datas[i].Prefab.name.Equals(name))
                {
                    if (_objectsOnScene[i] > 0)
                    {
                        _objectsOnScene[i]--;
                    }
                    
                    return;
                }
            }
        }
    }
}


