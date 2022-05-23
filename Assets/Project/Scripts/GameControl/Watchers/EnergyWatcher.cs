using System.Collections;
using Framework.CoroutineManager;
using Project.Scripts.GamePlay.Models;
using UnityEngine;

namespace Project.Scripts.GameControl.Watchers
{
    public class EnergyWatcher : IWatcher
    {
        private readonly ICoroutineManager _coroutineManager;
        private readonly IInGameEnergyModel _energyModel;
        private Coroutine _coroutine;

        public EnergyWatcher(ICoroutineManager coroutineManager, 
            IInGameEnergyModel energyModel)
        {
            _coroutineManager = coroutineManager;
            _energyModel = energyModel;
        }

        public void Initialise()
        {
            _coroutine = _coroutineManager.Start(AddEnergyCoroutine());
        }

        private IEnumerator AddEnergyCoroutine()
        {
            var waiter = new WaitForSeconds(3f);
            while (true)
            {
                yield return waiter;
                _energyModel.AddEnergy(5);
            }
        }
        
        public void Dispose()
        {
            _coroutineManager.Stop(_coroutine);
        }
    }
}