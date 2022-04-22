using Project.Scripts.Framework.MVP;
using Project.Scripts.Framework.MVVM;
using Project.Scripts.GamePlay.Cube.Data;
using UnityEngine;

namespace Project.Scripts.GamePlay.Cube.Views
{
    public class CubeView : BaseView<ICubeData>
    {
        [SerializeField] private CubeShooterView _cubeShooterView;

        protected override void Initialize()
        {
            _cubeShooterView.SetData(Data.Stats.Damage, Data.Stats.ShotsPerSecond);
            Data.CurrentFace.BindAndInvoke(_cubeShooterView.SetFaceBonus);
        }

        protected override void UnBind()
        {
            Data.CurrentFace.UnBind(_cubeShooterView.SetFaceBonus);
        }
    }
}