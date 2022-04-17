using Project.Scripts.Framework.MVP;
using Project.Scripts.GamePlay.Enemy.Data;
using Project.Scripts.GamePlay.Health;
using UnityEngine;
using UnityEngine.AI;

namespace Project.Scripts.GamePlay.Enemy.Views
{
    public class EnemyView : BaseView<IEnemyData>
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        
        public void Attack(IAttackTarget target)
        {
            _navMeshAgent.SetDestination(target.Position);
        }
    }
}