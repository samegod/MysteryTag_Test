﻿using UnityEngine;

namespace Additions.Pool
{
    public abstract class MonoBehaviourPoolObject : MonoBehaviour, IPoolObject
    {
        [SerializeField] private int preloadCount = 10;

        public int PreloadCount => preloadCount;

        public IPoolObject Origin { get; private set; }

        public IPoolObject LoadObject(IPoolObject origin)
        {
            var obj = Instantiate(this);
            obj.Origin = origin;
            obj.gameObject.SetActive(false);
            return obj;
        }

        public abstract void Push();

        public virtual void OnPop()
            => gameObject.SetActive(true);

        public virtual void OnPush()
            => gameObject.SetActive(false);
    }
}