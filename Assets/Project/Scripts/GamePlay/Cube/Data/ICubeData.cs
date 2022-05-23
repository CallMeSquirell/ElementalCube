using System.Collections.Generic;
using Framework.BindableProperties;
using Project.Scripts.GamePlay.Cube.Data.Faces;
using Project.Scripts.GamePlay.Cube.Data.State;
using Project.Scripts.GamePlay.Cube.Data.Stats;

namespace Project.Scripts.GamePlay.Cube.Data
{
    public interface ICubeData
    {
        IReadOnlyList<Faces.FaceType> Faces { get; }
        IBindableProperty<FaceType> CurrentFace { get; }
        CubeState State { get; }
        ICubeInfo Info { get; }
        bool IsUntargetable { get; set; }
        void Reroll();
    }
}