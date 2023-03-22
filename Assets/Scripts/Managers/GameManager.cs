using Cysharp.Threading.Tasks;
using Match3Test.Components.BaseComponents;
using UnityEngine;

namespace Match3Test.Managers
{
    public class GameManager : BaseManager<GameManager>
    {
        [SerializeField] private int _width;
        [SerializeField] private int _height;
        protected override async void Initialize()
        {
            await UniTask.WaitUntil(() => GameBoardManager.Instance != null &&
                                          GameBoardManager.Instance.IsInitialized);

            GameBoardManager.Instance.StartLevel(_width, _height);
            IsInitialized = true;
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
    }
}
