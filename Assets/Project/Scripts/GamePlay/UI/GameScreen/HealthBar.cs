using Framework.UI.Utils.Lable;
using Project.Scripts.GamePlay.Enemy.Data;
using Project.Scripts.GamePlay.Health.Hits;

namespace Project.Scripts.Framework.ResourceManagement.Game.GameScreen
{
    public class HealthBar : LeadingLabele
    {
        private IEnemyData _data;
        
        public void SetData(IEnemyData enemy)
        {
            _data = enemy;
            _data.HealthData.LethalHitProcessed += OnEnemyDied;
        }

        private void OnEnemyDied(IHit obj)
        {
            _data.HealthData.LethalHitProcessed -= OnEnemyDied;
            Release();
        }
    }
}