using Project.Scripts.Framework.MVP;
using Project.Scripts.GamePlay.Cube.Data;
using UnityEngine;

namespace Project.Scripts.GamePlay.Cube.Views
{
    public class CubeView : BaseView<ICubeData>
    {
        [SerializeField] private CubeShooterView _cubeShooterView;
    }
}