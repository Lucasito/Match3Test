namespace Match3Test.Components.BaseComponents
{
    public abstract class BaseManager<T> : InitializableBaseComponent where T : InitializableBaseComponent
    {
        public static T Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this.gameObject.GetComponent<T>();
            }
            else
            {
                if (Instance != this)
                {
                    Destroy(this.gameObject);
                }
            }

            Initialize();

            Subscribe();
        }
        private void OnDestroy()
        {
            UnSubscribe();

            UnInitialize();
        }
    }
}