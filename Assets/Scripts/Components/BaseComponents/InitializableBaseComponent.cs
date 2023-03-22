using Match3Test.Common;
using Match3Test.Helpers;
using System;
using UnityEngine;

namespace Match3Test.Components.BaseComponents
{
    public abstract class InitializableBaseComponent : BaseComponent, IInitializable
    {
        public event Action<bool> IsInitializedChanged = delegate { };
        public bool IsInitialized
        {
            get => _isInitialized;
            protected set
            {
                if (_isInitialized == value)
                {
                    return;
                }

                Debug.Log($"{this.GetType().Name}.{ReflectionHelper.GetCallerMemberName()}" +
                                     $"\n{_isInitialized}->{value}");
                _isInitialized = value;

                IsInitializedChanged.Invoke(_isInitialized);
            }
        }
        private bool _isInitialized;
    }
}