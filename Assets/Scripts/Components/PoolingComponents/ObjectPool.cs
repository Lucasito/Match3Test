using Match3Test.Components.BaseComponents;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Match3Test.Components.PoolingComponents
{
    public class ObjectPool : InitializableBaseComponent
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _initialSize;

        private readonly Stack<GameObject> _instances = new Stack<GameObject>();
        private readonly List<GameObject> _used = new List<GameObject>();

        protected override void Initialize()
        {
            Assert.IsNotNull(_prefab);
            for (var i = 0; i < _initialSize; i++)
            {
                var obj = CreateInstance();
                obj.SetActive(false);
                _instances.Push(obj);
            }
            IsInitialized = true;
        }

        protected override void UnInitialize()
        {
        }

        protected override void Subscribe()
        {
        }

        protected override void UnSubscribe()
        {
        }

        public GameObject GetObject()
        {
            var obj = _instances.Count > 0 ? _instances.Pop() : CreateInstance();
            _used.Add(obj);
            obj.SetActive(true);
            return obj;
        }

        public void ReturnObject(GameObject obj)
        {
            var pooledObject = obj.GetComponent<PooledObjectComponent>();
            Assert.IsNotNull(pooledObject);

            obj.SetActive(false);
            if (!_instances.Contains(obj))
            {
                _instances.Push(obj);
            }
            if (_used.Contains(obj))
            {
                _used.Remove(obj);
            }
        }

        public void Reset()
        {
            foreach (var instance in _used)
            {
                ReturnObject(instance);
            }
        }

        private GameObject CreateInstance()
        {
            var obj = Instantiate(_prefab);
            var pooledObject = obj.AddComponent<PooledObjectComponent>();
            pooledObject.SetPool(this);
            obj.transform.SetParent(transform);
            return obj;
        }
    }
}
