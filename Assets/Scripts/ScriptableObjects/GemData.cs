using Match3Test.Enums;
using UnityEngine;

namespace Match3Test.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "SO/GemData", order = 1)]
    public class GemData : ScriptableObject
    {
        public Sprite Icon;

        public GemType GemType;
    }
}