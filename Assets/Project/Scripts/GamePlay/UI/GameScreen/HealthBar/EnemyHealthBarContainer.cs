using Framework.Pool;
using Project.Scripts.Configs;
using Project.Scripts.GamePlay.Enemy.Data;
using UnityEngine;

namespace Project.Scripts.GamePlay.UI.GameScreen.HealthBar
{
    public class EnemyHealthBarContainer : MonoBehaviour
    {
        [SerializeField] private HealthBar _prefab;
        [SerializeField] private HitTextContainer _damageContainer;
        
        private readonly DefaultMonoBehaviourPool<HealthBar> _defaultMonoBehaviourPool 
            = new DefaultMonoBehaviourPool<HealthBar>();

        private ElementConfig _elementConfig;

        private void Awake()
        {
            _defaultMonoBehaviourPool.Initialise(_prefab, transform);
        }

        public void SetConfig(ElementConfig elementConfig)
        {
            _elementConfig = elementConfig;
            _damageContainer.SetConfig(_elementConfig);
        }
        
        public void AddBar(IEnemyData enemy)
        {
            var healthBar = _defaultMonoBehaviourPool.Get();
            healthBar.SetConfig(_elementConfig);
            healthBar.SetData(enemy, _damageContainer);
        }
    }
}