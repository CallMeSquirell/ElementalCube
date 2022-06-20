using System;
using DG.Tweening;
using Framework.MVVM;
using Project.Scripts.Configs;
using Project.Scripts.GamePlay.Cube.Data;
using Project.Scripts.GamePlay.Cube.Data.Faces;
using UnityEngine;

namespace Project.Scripts.GamePlay.Cube.Views
{
    public class CubeView : BaseView<ICubeData>
    {
        [SerializeField] private CubeShooterView _cubeShooterView;
        [SerializeField] private Transform _cube;
        [SerializeField] private MeshRenderer _renderer;

        private FaceStateMachine _faceStateMachine;
        private Sequence _sequence;

        protected override void Initialize()
        {
            _cubeShooterView.SetData(Data.Info);
            _faceStateMachine = Instantiator.Instantiate<FaceStateMachine>();
            Data.CurrentFace.BindAndInvoke(OnFaceChanged);
            SetFaces();
        }

        private void SetFaces()
        {
            var top = Config.Get<FaceListConfig>().GetConfig(Data.Faces[0]);
            var front = Config.Get<FaceListConfig>().GetConfig(Data.Faces[1]);
            var bottom = Config.Get<FaceListConfig>().GetConfig(Data.Faces[2]);
            var back = Config.Get<FaceListConfig>().GetConfig(Data.Faces[3]);
            var left = Config.Get<FaceListConfig>().GetConfig(Data.Faces[4]);
            var right = Config.Get<FaceListConfig>().GetConfig(Data.Faces[5]);
            _renderer.materials = new[]
            {
                right,
                bottom,
                _renderer.materials[2],
                top,
                front,
                left,
                back,
            };
        }

        private void OnFaceChanged(FaceType type)
        {
            _cubeShooterView.SetFaceBonus(null);
            Reroll();
        }
        
        private void Reroll()
        {
            Debug.Log("Reroll " + Data.CurrentFace.Value.Element);
            Data.IsUntargetable = true;
            _sequence = DOTween.Sequence().Append(_cube.DOLocalRotate(GetRoll(),0.5f ))
                .OnComplete(OnAnimationCompleted);
        }

        private Vector3 GetRoll()
        {
            for (int i = 0; i < Data.Faces.Count; i++)
            {
                if (Data.CurrentFace.Value.Element == Data.Faces[i].Element)
                {
                    switch (i)
                    {
                       case 0: return Vector3.zero;
                       case 3: return new Vector3(90, 0,0);
                       case 2: return new Vector3(180, 0,0);
                       case 1: return new Vector3(-90, 0,0);
                       case 4: return new Vector3(0, 0, 90);
                       case 5: return new Vector3(0, 0,-90);
                    }
                    break;
                }
            }
            return Vector3.zero;
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