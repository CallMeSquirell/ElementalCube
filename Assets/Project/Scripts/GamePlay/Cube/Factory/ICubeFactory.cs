using Project.Scripts.Framework.Factory;
using Project.Scripts.GamePlay.Cube.Views;
using UnityEngine;

namespace Project.Scripts.GamePlay.Cube.Factory
{
    public interface ICubeFactory : IFactory<CubeView>
    {
        CubeView Create(Transform parent);
    }
}