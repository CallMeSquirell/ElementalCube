using System;
using System.Collections.Generic;

namespace Project.Scripts.GamePlay.Cube.Data.Faces.Provider
{
    public interface IFaceDataProvider
    {
        IReadOnlyList<IFaceBonusData> Provide(IReadOnlyList<Type> types);
    }
}