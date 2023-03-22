using DG.Tweening;
using Match3Test.Components.BaseComponents;
using Match3Test.Components.GemComponents;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Match3Test.Managers
{
    public class InputManager : BaseManager<InputManager>
    {
        [SerializeField] private GraphicRaycaster _graphicRaycaster;
        [SerializeField] private EventSystem _eventSystem;
        [SerializeField] private float _moveTime;
        private bool _currentlySwapping;
        private bool _drag;
        private GemComponent _selectedGem;

        protected override void Initialize()
        {
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

        private void Update()
        {
            if (_currentlySwapping)
            {
                return;
            }

            if (Input.GetMouseButtonDown(0))
            {
                _drag = true;

                var pointerEventData = new PointerEventData(_eventSystem) { position = Input.mousePosition };
                var raycastResults = new List<RaycastResult>();
                EventSystem.current.RaycastAll(pointerEventData, raycastResults);

                foreach (var element in raycastResults)
                {
                    if (element.gameObject.CompareTag("Gem"))
                    {
                        _selectedGem = element.gameObject.GetComponent<GemComponent>();
                    }
                }

            }

            if (Input.GetMouseButtonUp(0))
            {
                _drag = false;
            }

            if (_drag && _selectedGem != null)
            {
                var pointerEventData = new PointerEventData(_eventSystem) { position = Input.mousePosition };
                var raycastResults = new List<RaycastResult>();
                EventSystem.current.RaycastAll(pointerEventData, raycastResults);

                GemComponent newGem = null;

                foreach (var element in raycastResults)
                {
                    if (element.gameObject.CompareTag("Gem"))
                    {
                        newGem = element.gameObject.GetComponent<GemComponent>();
                    }
                }

                if (newGem != null && newGem != _selectedGem)
                {
                    if ((_selectedGem.Position - newGem.Position).magnitude > 1)
                    {
                        return;
                    }

                    _currentlySwapping = true;
                    _selectedGem.transform.DOMove(newGem.transform.position, _moveTime).OnComplete(
                        () =>
                        {
                            _currentlySwapping = false;
                        });
                    newGem.transform.DOMove(_selectedGem.transform.position, _moveTime).OnComplete(
                        () =>
                        {
                            _currentlySwapping = false;
                        });
                    var tempPosition = _selectedGem.Position;
                    _selectedGem.Position = newGem.Position;
                    newGem.Position = tempPosition;

                    _selectedGem = null;
                }
            }
        }
    }
}