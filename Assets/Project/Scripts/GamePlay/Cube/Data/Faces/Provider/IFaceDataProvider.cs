using System;
using System.Collections.Generic;

namespace Project.Scripts.GamePlay.Cube.Data.Face.Provider
{
    public interface IFaceDataProvider
    {
        IReadOnlyList<IFaceBonusData> Provide(IReadOnlyList<Type> types);
    }
}