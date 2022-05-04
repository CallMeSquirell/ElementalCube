

using System;
using System.Collections.Generic;
using Framework.Promises;
using Project.Scripts.GameControl;
using Project.Scripts.GamePlay.Cube.Configs;
using UnityEngine;

namespace Framework.ResourceManagement
{
    public class Config : IConfig
    {
        private readonly Dictionary<Type, ScriptableObject> _configs = new Dictionary<Type, ScriptableObject>();

        private const string CubePath = "Assets/Project/Configs/CubeConfig.asset";        
        private const string EnemyPath = "Assets/Project/Configs/EnemyConfig.asset";        
        private const string LevelPath = "Assets/Bundles/GamePlay/LevelConfig.asset";
        private const string ElementPath = "Assets/Bundles/GamePlay/LevelConfig.asset";
        
        private readonly IAssetManager _assetManager;
        private PromiseActionQueue _queue;

        public Config(IAssetManager assetManager)
        {
            _assetManager = assetManager;
        }

        public IPromise Load()
        {
            _queue = new PromiseActionQueue(true);
            LoadConfig<CubeConfig>(CubePath);
            LoadConfig<LevelConfig>(LevelPath);
            LoadConfig<ElementConfig>(ElementPath);
            //queue.Append(LoadConfig<EnemyConfig>(EnemyPath));
            return _queue;
        }

        private void LoadConfig<T>(string path) where T : ScriptableObject
        {
            if (_configs.ContainsKey(typeof(T)))
            {
                return;
            }
            
            _queue.Append(new PromiseAction(
                _assetManager.LoadAsset<T>(path)
                .Then(config => _configs.Add(typeof(T), config))
                ));
        }
        
        public T Get<T>() where T : ScriptableObject
        {
            if (_configs.TryGetValue(typeof(T), out ScriptableObject config))
            {
                return (T)config;
            }
            return null;
        }
    }

    public interface IConfig
    {
        IPromise Load();
        T Get<T>() where T : ScriptableObject;
    }
}