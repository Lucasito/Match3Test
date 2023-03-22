using Cysharp.Threading.Tasks;
using Match3Test.Components.BaseComponents;
using Match3Test.Components.GemComponents;
using Match3Test.Components.PoolingComponents;
using UnityEngine;
using UnityEngine.Assertions;

namespace Match3Test.Managers
{
    public class PoolManager : BaseManager<PoolManager>
    {
        [SerializeField] private ObjectPool _gemPool;

        protected override async void Initialize()
        {
            Assert.IsNotNull(_gemPool);

            await UniTask.WaitUntil(() => _gemPool.IsInitialized);

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


        public GemComponent GetGemPool()
        {
            return _gemPool.GetObject().GetComponent<GemComponent>();
        }
    }
}