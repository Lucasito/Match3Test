using Match3Test.Components.BaseComponents;
using Match3Test.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Match3Test.Components.GemComponents
{
    public class GemComponent : BaseComponent
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Image _iconImage;

        public Vector2Int Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }
        private Vector2Int _position;
        private float _cellSize;
        private GemData _gemData;
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

        public void SetParameters(GemData gemData, Vector3 startPosition, float cellSize, Vector2Int position, Transform parent)
        {
            _gemData = gemData;
            _position = position;
            _cellSize = cellSize;

            _iconImage.sprite = _gemData.Icon;

            _rectTransform.SetParent(parent);
            _rectTransform.position = startPosition + new Vector3(_position.x * cellSize, _position.y * cellSize, 0);
            _rectTransform.sizeDelta = cellSize * Vector2.one;

        }
    }
}