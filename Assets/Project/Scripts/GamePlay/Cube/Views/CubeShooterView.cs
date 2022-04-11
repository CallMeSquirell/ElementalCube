using Project.Scripts.Framework.MVP;
using Project.Scripts.GamePlay.Cube.Data;
using Project.Scripts.GamePlay.Health.Hits.Pool;
using Project.Scripts.GamePlay.Slime;
using Project.Scripts.GamePlay.Slime.Views;
using Project.Scripts.GamePlay.Watcher;
using UnityEngine;
using Zenject;

namespace Project.Scripts.GamePlay.Cube.Views
{
    public class CubeShooterView : MonoBehaviour
    {
        [SerializeField] private Collider _collider;
        protected InRangeWatcher<SlimeView> SlimeWatcher { get; }  = new InRangeWatcher<SlimeView>();

        private IHitPool _hitPool;

        protected IHitPool HitPool => _hitPool;
        protected Collider Collider => _collider;
        
        protected int ShotPerSecond { get; private set; }
        protected int Damage { get; private set; }

        [Inject]
        public void Initialize(IHitPool hitPool)
        {
            _hitPool = hitPool;
        }
        
        private void Awake()
        {
            SlimeWatcher.Entered += OnEnemyEntered;
            SlimeWatcher.Left += OnEnemyLeft;
        }

        public void SetData(int damage, int shotPerSecond)
        {
            Damage = damage;
            ShotPerSecond = shotPerSecond;
        }

        protected virtual void OnEnemyEntered(SlimeView obj)
        {
        }

        protected virtual void OnEnemyLeft(SlimeView obj)
        {
        }

        private void OnTriggerEnter(Collider other)
        {
            SlimeWatcher.Enter(other.gameObject);
        }

        private void OnTriggerExit(Collider other)
        {
            SlimeWatcher.Exit(other.gameObject);
        }

        private void OnDestroy()
        {
            SlimeWatcher.Entered -= OnEnemyEntered;
            SlimeWatcher.Left -= OnEnemyLeft;
        }
    }
}