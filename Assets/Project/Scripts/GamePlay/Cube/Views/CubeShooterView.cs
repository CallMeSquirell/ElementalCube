using System.Collections;
using Framework.Extensions;
using Project.Scripts.GamePlay.Cube.Data.Faces;
using Project.Scripts.GamePlay.Cube.Data.Stats;
using Project.Scripts.GamePlay.Enemy.Data;
using Project.Scripts.GamePlay.Enemy.Views;
using Project.Scripts.GamePlay.Health.Hits;
using Project.Scripts.GamePlay.Health.Hits.Pool;
using Project.Scripts.GamePlay.Watcher;
using UnityEngine;

namespace Project.Scripts.GamePlay.Cube.Views
{
    public class CubeShooterView : MonoBehaviour
    {
        [SerializeField] private Collider _collider;
        [SerializeField] private LineRenderer _line;
        
        private IHitPool _hitPool;
        
        private EnemyView _currentAim;
        private Coroutine _shootingCoroutine;
        private IFaceBonusData _faceBonusData;
        
        private readonly InRangeWatcher<EnemyView> _slimeWatcher = new InRangeWatcher<EnemyView>();
        
        private ICubeInfo CubeInfo { get; set; }

        private float _shootRate;
        private float _timeToShot = 0;
        
        private void Awake()
        {
            _slimeWatcher.Entered += OnEnemyEntered;
            _slimeWatcher.Left += OnEnemyLeft;
        }

        public void SetData(ICubeInfo cubeInfo)
        {
            CubeInfo = cubeInfo;
            _shootRate = 1f / CubeInfo.ShotsPerSecond;
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

        private void OnEnemyEntered(EnemyView obj)
        {
            if (!_currentAim.NonNull())
            {
                SelectNextAim();
            }
        }

        private void OnEnemyLeft(EnemyView obj)
        {
            if (_currentAim == obj)
            {
                SelectNextAim();
            }
        }

        private void SelectNextAim()
        {
            if (_currentAim.NonNull())
            {
                _currentAim.Data.Died -= OnHealthDataLethalHitProcessed;
                _currentAim = null;
            }

            _currentAim = _slimeWatcher.InRangeList.First?.Value;
            _timeToShot = 0;

            if (_currentAim != null)
            {
                _currentAim.Data.Died += OnHealthDataLethalHitProcessed;
            }
        }
        
        private void OnHealthDataLethalHitProcessed(IEnemyData data)
        {
            _slimeWatcher.Exit(_currentAim.gameObject);
        }

        private void FixedUpdate()
        {
            if (!_currentAim.NonNull() || _faceBonusData == null)
            {
                return;
            }
            
            _timeToShot = Mathf.Clamp(_timeToShot - Time.fixedDeltaTime, 0, _shootRate);
            
            if (_timeToShot == 0)
            {
                RefreshCallDown();
                StartCoroutine(ShotAnimationCoroutine());
                _faceBonusData.Process(_currentAim.Data, CubeInfo);
            }
        }

        private IEnumerator ShotAnimationCoroutine()
        {
            _line.gameObject.SetActive(true);
            _line.SetPosition(0, transform.position);
            _line.SetPosition(1, _currentAim.Data.Transform.position);
            yield return new WaitForSeconds(0.3f);
            _line.gameObject.SetActive(false);
        }

        private void RefreshCallDown()
        {
            _timeToShot = _shootRate;
        }
        
        private void OnDestroy()
        {
            if (_currentAim.NonNull())
            {
                _currentAim.Data.Died -= OnHealthDataLethalHitProcessed;
            }
            _slimeWatcher.Entered -= OnEnemyEntered;
            _slimeWatcher.Left -= OnEnemyLeft;
        }
    }
}