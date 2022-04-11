using System.Collections;
using Project.Scripts.Framework.Extensions;
using Project.Scripts.GamePlay.Health.Hits;
using Project.Scripts.GamePlay.Slime;
using Project.Scripts.GamePlay.Slime.Views;
using UnityEngine;

namespace Project.Scripts.GamePlay.Cube.Views
{
    public class ElementalCubeShooterView : CubeShooterView
    {
        private SlimeView _currentAim;

        private Coroutine _shootingCoroutine;

        protected override void OnEnemyEntered(SlimeView obj)
        {
            if (!_currentAim.NonNull())
            {
                SelectNextAim();
            }
        }

        protected override void OnEnemyLeft(SlimeView obj)
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
            
            _currentAim = SlimeWatcher.InRangeList.First?.Value;
            
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
    }
}