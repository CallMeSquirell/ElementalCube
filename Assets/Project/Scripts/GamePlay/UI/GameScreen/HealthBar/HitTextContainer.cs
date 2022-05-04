using System;
using Project.Scripts.GameControl;
using Project.Scripts.GamePlay.Cube.Data.Faces;
using Project.Scripts.GamePlay.Health.Hits;
using TMPro;
using UnityEngine;

namespace Project.Scripts.Framework.ResourceManagement.Game.GameScreen
{
    public class HitTextContainer : MonoBehaviour
    {
        [SerializeField] private FloatingText _prefab;

        private readonly DefaultMonoBehaviourPool<FloatingText> _pool = new DefaultMonoBehaviourPool<FloatingText>();
        
        private ElementConfig _elementConfig;

        private void Awake()
        {
            _pool.Initialise(_prefab, transform);
        }

        public void PlaceHit(IHit hit, Vector3 position)
        {
            var color = _elementConfig.GetElementColor(hit.Element).Value;
            var text = _pool.Get();
            text.SetData(hit.Damage.ToString(), color, hit.Element == Element.Empty ? 0 : 1f);
            text.Play(position);
        }


        public void SetConfig(ElementConfig elementConfig)
        {
            _elementConfig = elementConfig;
        }
    }
}