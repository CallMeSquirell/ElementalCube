using Framework.UI.Utils.Lable;
using Project.Scripts.GameControl;
using Project.Scripts.GamePlay.Cube.Data.Faces;
using Project.Scripts.GamePlay.Enemy.Data;
using Project.Scripts.GamePlay.Health.Hits;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Framework.ResourceManagement.Game.GameScreen
{
    public class HealthBar : LeadingLabele
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Image _image;

        private IEnemyData _data;
        private Transform _container;
        private HitTextContainer _damageContainer;
        private ElementConfig _config;

        public void SetConfig(ElementConfig elementConfig)
        {
            _config = elementConfig;
        }

        public void SetData(IEnemyData enemy, HitTextContainer damageContainer)
        {
            UnSubscribe();
            _data = enemy;
            _damageContainer = damageContainer;
            Subscribe();
            UpdateBar();
        }

        public void Subscribe()
        {
            if (_data != null)
            {
                _data.Died += OnEnemyDied;
                _data.CurrentElement.BindAndInvoke(OnElementChanged);
                _data.HealthData.HitProcessed += OnGetDamage;
            }
        }

        private void OnElementChanged(Element obj)
        {
            _image.color = _config.GetElementColor(obj).Value;
        }

        private void OnGetDamage(IHit hit)
        {
            UpdateBar();
            _damageContainer.PlaceHit(hit, SelfTransform.position);
        }

        private void UpdateBar()
        {
            _slider.value = (float) _data.HealthData.HealthPercent;
        }

        private void UnSubscribe()
        {
            if (_data != null)
            {
                _data.CurrentElement.UnBind(OnElementChanged);
                _data.HealthData.HitProcessed -= OnGetDamage;
                _data.Died -= OnEnemyDied;
            }
        }

        private void OnEnemyDied(IEnemyData enemy)
        {
            UnSubscribe();
            Release();
        }
    }
}