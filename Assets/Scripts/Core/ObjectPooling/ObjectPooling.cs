using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.ObjectPooling
{
    
    [AddComponentMenu("Pool/ObjectPooling")]
    public class ObjectPooling
    {
        
        #region Fields

        private List<PoolObject> _objects;
        private Transform _objectsParent;

        #endregion
        
        #region Methods

        public void AddObject(PoolObject sample, Transform objectsParent)
        {
            GameObject temp = GameObject.Instantiate(sample.gameObject);
            temp.name = sample.name;
            temp.transform.SetParent (objectsParent);
            _objects.Add(temp.GetComponent<PoolObject> ());
            temp.SetActive(false);
        }
        
        public void Initialize (int count, PoolObject sample, Transform objectsParent)
        {
            _objects = new List<PoolObject> ();
            _objectsParent = objectsParent; 
            for (int i = 0; i < count; i++)
            {
                AddObject(sample, objectsParent);
            }
        }
        
        public PoolObject GetObject ()
        {
            for (int i = 0; i < _objects.Count; i++)
            {
                if (_objects[i].gameObject.activeInHierarchy == false)
                {
                    return _objects[i];
                }
            }
            AddObject(_objects[0], _objectsParent);
            return _objects[_objects.Count - 1];
        }
        
        #endregion

    }
}


