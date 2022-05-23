using Framework.BindableProperties;

namespace Project.Scripts.GamePlay.Models
{
    public interface IInGameEnergyModel
    {
        IBindableProperty<int> Count { get; }
        bool TryPay(int count);
        bool AddEnergy(int count);

        void FullFill();
        
        void Reset();
    }
}