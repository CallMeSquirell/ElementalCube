using System;
using System.Collections;
using Framework.MVVM;
using Project.Scripts.GamePlay.Cube.Data.Faces;
using Project.Scripts.GamePlay.Enemy.Data;
using Project.Scripts.GamePlay.Health;
using Project.Scripts.GamePlay.Health.Hits;
using UnityEngine;
using UnityEngine.AI;

namespace Project.Scripts.GamePlay.Enemy.Views
{
    public class EnemyView : BaseView<IEnemyData>
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private Transform _childTransform;
        private IAttackTarget _target;
        private Transform _transform;
        private Coroutine _coroutine;
        
        private void Awake()
        {
            _transform = transform;
        }

        protected override void Initialize()
        {
            Data.Died += OnDied;
        }
        
        protected override void UnBind()
        {
            Data.Died -= OnDied;
        }

        private void OnDied(IEnemyData died)
        {
            _coroutine = _coroutine ?? (_coroutine = StartCoroutine(DestroyCoroutine()));
        }

        private IEnumerator DestroyCoroutine()
        {
            yield return null;
            Destroy(gameObject);
        }

        private void FixedUpdate()
        {
            var position = _navMeshAgent.velocity.normalized;
            position.y = 0;
            _childTransform.LookAt(_transform.position + position); 
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IAttackTarget target) && target == _target)
            {
                _target.HealthData.AddHit(new Hit(1, Element.Empty), true);
                Data.Kill();
            }
        }

        public void Attack(IAttackTarget target)
        {
            _target = target; 
            _navMeshAgent.SetDestination(target.Position);
        }
    }
}