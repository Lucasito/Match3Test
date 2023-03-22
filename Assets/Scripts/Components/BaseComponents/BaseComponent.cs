namespace Match3Test.Components.BaseComponents
{
    public abstract class BaseComponent : BaseMonoBehaviour
    {
        private void Awake()
        {
            Initialize();
        }

        private void Start()
        {
            Subscribe();
        }

        private void OnDestroy()
        {
            UnSubscribe();

            UnInitialize();
        }
    }
}