using System.Collections.Generic;
using Project.Scripts.Framework.BindableProperties;
using Project.Scripts.GamePlay.Cube.Data.Face;
using Project.Scripts.GamePlay.Cube.Data.State;
using Project.Scripts.GamePlay.Cube.Data.Stats;

namespace Project.Scripts.GamePlay.Cube.Data
{
    public interface ICubeData
    {
        IReadOnlyList<IFaceBonusData> Faces { get; }
        IBindableProperty<IFaceBonusData> CurrentFace { get; }
        CubeState State { get; }
        ICubeStatsData Stats { get; }
        void Reroll();
    }
}