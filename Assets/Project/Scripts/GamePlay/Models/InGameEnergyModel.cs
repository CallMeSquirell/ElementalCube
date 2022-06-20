using Framework.BindableProperties;
using UnityEngine;

namespace Project.Scripts.GamePlay.Models
{
    public class InGameEnergyModel : IInGameEnergyModel
    {
        private int MaxCount = 100;
        private int MinCount = 0;
        
        private readonly BindableProperty<int> _count = new BindableProperty<int>();
        
        public IBindableProperty<int> Count => _count;

        public void FullFill()
        {
            _count.Value = MaxCount;
        }

        public void Reset()
        {
            _count.Value = 50;
        }

        public bool TryPay(int count)
        {
            if (_count.Value - count >= 0)
            {
                _count.Value -= count;
                return true;
            }

            return false;
        }

        public bool AddEnergy(int count)
        {
            if (count > 0  && count + _count.Value < MaxCount)
            {
                _count.Value = Mathf.Clamp(_count.Value + count, MinCount, MaxCount);
                return true;
            }
            return false;
        }
    }
}