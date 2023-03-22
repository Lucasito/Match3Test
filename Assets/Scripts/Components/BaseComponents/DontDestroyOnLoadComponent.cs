namespace Match3Test.Components.BaseComponents
{
    public class DontDestroyOnLoadComponent : BaseComponent
    {
        protected override void Initialize()
        {
            DontDestroyOnLoad(gameObject);
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
    }
}
