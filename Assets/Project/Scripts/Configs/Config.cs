using System;
using System.Collections.Generic;
using Framework.Promises;
using Framework.ResourceManagement;
using UnityEngine;

namespace Project.Scripts.Configs
{
    public class Config : IConfig
    {
        private readonly Dictionary<Type, ScriptableObject> _configs = new Dictionary<Type, ScriptableObject>();

        private const string CubePath = "Assets/Project/Configs/CubeSetConfig.asset";        
        private const string EnemyPath = "Assets/Project/Configs/EnemyConfig.asset";        
        private const string LevelPath = "Assets/Project/Configs/LevelConfig.asset";
        private const string ElementPath = "Assets/Project/Configs/ElementConfig.asset";
        private const string PlayerConfig = "Assets/Project/Configs/PlayerConfig.asset";
        
        private readonly IAssetManager _assetManager;
        private PromiseActionQueue _queue;

        public Config(IAssetManager assetManager)
        {
            _assetManager = assetManager;
        }

        public IPromise Load()
        {
            _queue = new PromiseActionQueue(true);
            LoadConfig<CubeSetConfig>(CubePath);
            LoadConfig<LevelConfig>(LevelPath);
            LoadConfig<ElementConfig>(ElementPath);
            LoadConfig<EnemyConfig>(EnemyPath);
            LoadConfig<PlayerConfig>(PlayerConfig);
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