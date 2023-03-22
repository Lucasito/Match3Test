using Cysharp.Threading.Tasks;
using Match3Test.Components.BaseComponents;
using Match3Test.Components.GemComponents;
using Match3Test.ScriptableObjects;
using UnityEngine;

namespace Match3Test.Managers
{
    public class GameBoardManager : BaseManager<GameBoardManager>
    {
        [SerializeField] private RectTransform _boardRectTransform;

        [SerializeField] private float _paddingHorizontal;
        [SerializeField] private float _paddingVertical;

        [SerializeField] private GemData[] _gemData;

        private int _width;
        private int _height;

        protected override async void Initialize()
        {
            await UniTask.WaitUntil(() => PoolManager.Instance != null &&
                                          PoolManager.Instance.IsInitialized);

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

        internal void StartLevel(int width, int height)
        {
            _width = width;
            _height = height;

            Vector3[] corners = new Vector3[4];
            _boardRectTransform.GetWorldCorners(corners);

            float widthBoard = corners[3].x - corners[1].x - 2 * _paddingHorizontal;
            float heightBoard = corners[1].y - corners[3].y - 2 * _paddingVertical;

            float cellSize = Mathf.Min(heightBoard / _height, widthBoard / _width);

            var centerPosition = (corners[0] + corners[2]) / 2f;
            var startPosition = centerPosition - new Vector3(cellSize * (_width - 1) / 2f, cellSize * (_height - 1) / 2f, 0);

            GemComponent gem;
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    gem = PoolManager.Instance.GetGemPool();
                    gem.SetParameters(_gemData[UnityEngine.Random.Range(0, _gemData.Length)], startPosition, cellSize, new Vector2Int(i, j), _boardRectTransform);
                }
            }
        }

        public int GetBoardWidth()
        {
            return _width;
        }

        public int GetBoardHeight()
        {
            return _height;
        }
    }
}