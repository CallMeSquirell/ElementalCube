using System.Collections;
using Project.Scripts.Framework.MVP;
using Project.Scripts.GamePlay.Slime.Data;
using UnityEngine;
using UnityEngine.AI;

namespace Project.Scripts.GamePlay.Slime.Views
{
    public class SlimeView : BaseView<ISlimeData>
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;

        public override void SetData(ISlimeData data)
        {
            base.SetData(data);
            StartMove();
        }

        private void StartMove()
        {
            
        }
    }
}