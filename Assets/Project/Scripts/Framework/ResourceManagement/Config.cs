using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Framework.ResourceManagement
{
    public class Config : IConfig
    {
        private const string DefaultPath = "Config/";
        
        private readonly Dictionary<Type, ScriptableObject> _configs = new Dictionary<Type, ScriptableObject>();
   
        public T Get<T>() where T : ScriptableObject
        {
            var type = typeof(T);
            if (!_configs.TryGetValue(type, out var config))
            {
                config = Resources.Load<T>(DefaultPath + type);
                _configs.Add(type,config);
            }
            return (T) config;
        }
    }
}