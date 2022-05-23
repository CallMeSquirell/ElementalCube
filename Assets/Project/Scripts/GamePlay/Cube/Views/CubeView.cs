using DG.Tweening;
using Framework.MVVM;
using Project.Scripts.GamePlay.Cube.Data;
using Project.Scripts.GamePlay.Cube.Data.Faces;
using UnityEngine;

namespace Project.Scripts.GamePlay.Cube.Views
{
    public class CubeView : BaseView<ICubeData>
    {
        [SerializeField] private CubeShooterView _cubeShooterView;
        [SerializeField] private Transform _cube;

        private FaceStateMachine _faceStateMachine;
        private Sequence _sequence;

        protected override void Initialize()
        {
            _cubeShooterView.SetData(Data.Info);
            _faceStateMachine = Instantiator.Instantiate<FaceStateMachine>();
            Data.CurrentFace.BindAndInvoke(OnFaceChanged);
        }

        private void OnFaceChanged(FaceType type)
        {
            _cubeShooterView.SetFaceBonus(null);
            Reroll();
        }
        
        private void Reroll()
        {
            Data.IsUntargetable = true;
            var endValue = _cube.rotation.eulerAngles + new Vector3(0,180,180);
            endValue = new Vector3(endValue.x, endValue.y % 360, endValue.z % 360);
            _sequence = DOTween.Sequence().Append(_cube.DOLocalRotate(endValue,0.5f ))
                .OnComplete(OnAnimationCompleted);
        }
        
        private void OnAnimationCompleted()
        {
            _cubeShooterView.SetFaceBonus(_faceStateMachine.UpdateFace(Data.CurrentFace.Value));
            Data.IsUntargetable = false;
        }
        
        protected override void UnBind()
        {
            Data.CurrentFace.UnBind(OnFaceChanged);
        }
    }
}