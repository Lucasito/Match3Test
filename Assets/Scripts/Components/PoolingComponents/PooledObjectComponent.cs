using Match3Test.Components.BaseComponents;

namespace Match3Test.Components.PoolingComponents
{
    public class PooledObjectComponent : BaseComponent
    {
        private ObjectPool _pool;

        protected override void Initialize()
        {
        }

        protected override void Subscribe()
        {
        }

        protected override void UnInitialize()
        {
        }

        protected override void UnSubscribe()
        {
        }

        public void SetPool(ObjectPool pool)
        {
            _pool = pool;
        }
    }
}