using System.Collections.Generic;
using Framework.Pool;
using Project.Scripts.Configs;
using Project.Scripts.GamePlay.Cube.Data.Stats;
using UnityEngine;

namespace Project.Scripts.GamePlay.UI.PlaceTile.Views
{
    public class FacesInfoContainer : MonoBehaviour
    {
        [SerializeField] private Transform _container;
        [SerializeField] private FaceInfoView _prefab;

        private readonly DefaultMonoBehaviourPool<FaceInfoView> _pool = new DefaultMonoBehaviourPool<FaceInfoView>();
        private readonly List<FaceInfoView> _placedInfoList = new List<FaceInfoView>();
        private ElementConfig _config;

        private void Awake()
        {
            _pool.Initialise(_prefab, _container);
        }

        public void SetConfig(ElementConfig config)
        {
            _config = config;
        }
        
        public void SetData(ICubeInfo cubeInfo)
        {
            Clear();
            foreach (var face in cubeInfo.Faces)
            {
                var info = _config.GetElementInfo(face.Element);
                var view = _pool.Get();
                view.SetInfo(info);
                _placedInfoList.Add(view);
            }
        }

        public void Clear()
        {
            foreach (var view in _placedInfoList)
            {
                view.Release();
            }            
            _placedInfoList.Clear();
        }
    }
}