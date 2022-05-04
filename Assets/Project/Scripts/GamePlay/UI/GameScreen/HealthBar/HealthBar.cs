using Framework.UI.Utils.Lable;
using Project.Scripts.GamePlay.Enemy.Data;
using Project.Scripts.GamePlay.Health.Hits;
using UnityEngine;

namespace Project.Scripts.Framework.ResourceManagement.Game.GameScreen
{
    public class HealthBar : LeadingLabele
    {
        private IEnemyData _data;
        private Transform _container;
        private HitTextContainer _damageContainer;
        
        public void SetData(IEnemyData enemy, HitTextContainer damageContainer)
        {
            _data = enemy;
            _damageContainer = damageContainer;
            _data.Died += OnEnemyDied;
            _data.HealthData.HitProcessed += OnGetDamage;
        }

        private void OnGetDamage(IHit hit)
        {
           _damageContainer.PlaceHit(hit, SelfTransform.position);
        }

        private void OnEnemyDied(IEnemyData enemy)
        {
            _data.Died -= OnEnemyDied;
            Release();
        }
    }
}