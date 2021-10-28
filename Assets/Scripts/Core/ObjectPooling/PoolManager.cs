using UnityEngine;

namespace Core.ObjectPooling
{
    public static class PoolManager
    {
        private static PoolPart[] _pools;
        private static GameObject _objectsParent;

        [System.Serializable]
        public struct PoolPart
        {
            public string Name; 
            public PoolObject Prefab;
            public int Count;
            public ObjectPooling Pool;
        }
        
        public static void Initialize(PoolPart[] newPools)
        {
            _pools = newPools; //Fill info
            _objectsParent = new GameObject ();
            _objectsParent.name = "Pool"; //Create object "Pool" to avoid cluttering the scene 
            for (int i = 0; i< _pools.Length; i++)
            {
                if(_pools[i].Prefab != null)
                {  
                    _pools[i].Pool = new ObjectPooling(); //Create pool for each object
                    _pools[i].Pool.Initialize(_pools[i].Count, _pools[i].Prefab, _objectsParent.transform);
                }
            }
        }
        
        public static GameObject GetObject (string name, Vector3 position, Quaternion rotation)
        {
            GameObject result = null;
            if (_pools != null)
            {
                for (int i = 0; i < _pools.Length; i++)
                {
                    if (string.Compare (_pools[i].Name, name) == 0)
                    { //If names are matched
                        result = _pools[i].Pool.GetObject ().gameObject; //Get object from pool
                        result.transform.position = position;
                        result.transform.rotation = rotation; 
                        result.SetActive (true); //Set coords and activate object
                        return result;
                    }
                }
            } 
            return result; //Returns null if object not in pool
        }
    }
}


