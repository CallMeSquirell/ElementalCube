using Framework.MVVM;
using Project.Scripts.GamePlay.Cube.Data;
using Project.Scripts.GamePlay.Cube.Data.Faces;
using UnityEngine;

namespace Project.Scripts.GamePlay.Cube.Views
{
    public class CubeView : BaseView<ICubeData>
    {
        [SerializeField] private CubeShooterView _cubeShooterView;

        private FaceStateMachine _faceStateMachine;
        
        protected override void Initialize()
        {
            _cubeShooterView.SetData(Data.Stats);
            _faceStateMachine = Instantiator.Instantiate<FaceStateMachine>();
            Data.CurrentFace.BindAndInvoke(OnFaceChanged);
        }

        private void OnFaceChanged(FaceType type)
        {
            _cubeShooterView.SetFaceBonus(_faceStateMachine.UpdateFace(type));
        }
        
        protected override void UnBind()
        {
            Data.CurrentFace.UnBind(OnFaceChanged);
        }
    }
}