using System;
using UnityEngine;

namespace Project.Scripts.Framework.MVP.UI.Views
{
    [Serializable]
    public class ViewDefinition
    {
        [SerializeField] private WindowWindowView _prefab;

        public WindowWindowView Prefab => _prefab;
    }
}