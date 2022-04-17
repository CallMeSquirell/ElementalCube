using System.Collections;
using Project.Scripts.Framework.Extensions;
using Project.Scripts.GamePlay.Cube.Data.Faces;
using Project.Scripts.GamePlay.Enemy.Views;
using Project.Scripts.GamePlay.Health.Hits;
using Project.Scripts.GamePlay.Health.Hits.Pool;
using Project.Scripts.GamePlay.Watcher;
using UnityEngine;
using Zenject;

namespace Project.Scripts.GamePlay.Cube.Views
{
    public class CubeShooterView : MonoBehaviour
    {
        [SerializeField] private Collider _collider;
        
        private IHitPool _hitPool;
        
        private EnemyView _currentAim;
        private Coroutine _shootingCoroutine;
        private IFaceBonusData _faceBonusData;
        
        private InRangeWatcher<EnemyView> _slimeWatcher = new InRangeWatcher<EnemyView>();
        
        private IHitPool HitPool => _hitPool;

        private int ShotPerSecond { get; set; }
        private int Damage { get; set; }

        [Inject]
        public void Initialize(IHitPool hitPool)
        {
            _hitPool = hitPool;
        }

        private void Awake()
        {
            _slimeWatcher.Entered += OnEnemyEntered;
            _slimeWatcher.Left += OnEnemyLeft;
        }

        public void SetData(int damage, int shotPerSecond)
        {
            Damage = damage;
            ShotPerSecond = shotPerSecond;
        }

        public void SetFaceBonus(IFaceBonusData element)
        {
            _faceBonusData = element;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            _slimeWatcher.Enter(other.gameObject);
        }

        private void OnTriggerExit(Collider other)
        {
            _slimeWatcher.Exit(other.gameObject);
        }

        private  void OnEnemyEntered(EnemyView obj)
        {
            if (!_currentAim.NonNull())
            {
                SelectNextAim();
            }
        }

        private  void OnEnemyLeft(EnemyView obj)
        {
            if (_currentAim == obj)
            {
                SelectNextAim();
            }
        }

        private void SelectNextAim()
        {
            StopShooting();

            if (_currentAim != null)
            {
                _currentAim.Data.HealthData.LethalHitProcessed -= OnHealthDataLethalHitProcessed;
                _currentAim = null;
            }

            _currentAim = _slimeWatcher.InRangeList.First?.Value;

            if (_currentAim != null)
            {
                _currentAim.Data.HealthData.LethalHitProcessed += OnHealthDataLethalHitProcessed;
                _shootingCoroutine = StartCoroutine(ShootingCoroutine());
            }
        }

        private void StopShooting()
        {
            if (_shootingCoroutine != null)
            {
                StopCoroutine(_shootingCoroutine);
            }
        }

        private void OnHealthDataLethalHitProcessed(IHit obj)
        {
            SelectNextAim();
        }

        private IEnumerator ShootingCoroutine()
        {
            var waiter = new WaitForSeconds(1f / ShotPerSecond);
            while (true)
            {
                yield return waiter;
                _currentAim.Data.HealthData.AddHit(HitPool.Get(Damage), true);
            }
        }
        
        private void OnDestroy()
        {
            _slimeWatcher.Entered -= OnEnemyEntered;
            _slimeWatcher.Left -= OnEnemyLeft;
        }
    }
}