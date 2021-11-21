using F3Lib.Patterns.Factory;

using System.Collections.Generic;
using System.Linq;

namespace F3Lib.Patterns.Pools
{

    public class ObjectPool<Object> where Object : class, new()
    {
        protected List<Object> _pool;
        protected readonly IFactory<Object> _creator;

        protected readonly int _capacity;

        public ObjectPool(IFactory<Object> creator, int capacity)
        {
            _creator = creator;
            _capacity = capacity;
            CreatePool();
        }

        public int Capacity => _capacity;
        public int Count => _pool.Count;

        public virtual Object Take()
        {
            if (_pool.Count == 0) throw new System.Exception("Pool is empty.");

            Object result = _pool.First();
            _pool.Remove(result);
            return result;
        }

        public virtual void Return(Object obj)
        {
            if (_pool.Count >= _capacity) throw new System.InvalidOperationException("Pool is full");
            if (_pool.Contains(obj)) throw new System.ArgumentException("Pool already contains this object");

            _pool.Add(obj);
        }

        protected virtual void CreatePool()
        {
            _pool = new List<Object>(_capacity);

            for (int i = 0; i < _pool.Capacity; i++)
            {
                _pool.Add(_creator.Create());
            }
        }
    }
}