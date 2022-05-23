using Framework.Extensions;
using Framework.Promises;
using Framework.ResourceManagement;
using Project.Scripts.GamePlay.LevelSystem;
using UnityEngine;
using Zenject;

namespace Project.Scripts.GameControl.Loader
{
    public class LevelLoader : ILevelLoader
    {
        private readonly string LevelPath = "Assets/Project/Prefabs/Levels/Level_{0}.prefab";
    
        private readonly IInstantiator _instantiator;
        private readonly Level _currentLevel;
        private readonly IAssetManager _assetManager;

        private Level _nextLevel;
        private Level _createdLevel;

        public Level CreatedLevel => _createdLevel;

        public LevelLoader(IInstantiator instantiator, IAssetManager assetManager)
        {
            _instantiator = instantiator;
            _assetManager = assetManager;
        }

        public IPromise LoadNextLevel(int levelIndex)
        {
            var promise = new Promise();
            _assetManager.LoadPrefabForComponent<Level>(string.Format(LevelPath, levelIndex)).Then(prefab =>
            {
                _nextLevel = prefab;
                promise.Dispatch();
            }).Fail(promise.Abort);
            return promise;
        }

        public void SetUpNextLevel()
        {
            if (_createdLevel.NonNull())
            {
                Object.Destroy(_createdLevel.gameObject);
            }
            
            if (_nextLevel.NonNull())
            {
                _createdLevel = _instantiator.InstantiatePrefabForComponent<Level>(_nextLevel);
            }
        }
    }
}