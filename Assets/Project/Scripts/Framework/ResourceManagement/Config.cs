using System;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Scripts.Framework.ResourceManagement
{
    public static class Config
    {
        private const string DefaultPath = "Config/";
        
        private static readonly Dictionary<Type, ScriptableObject> Configs = new Dictionary<Type, ScriptableObject>();
   
        public static T Get<T>() where T : ScriptableObject
        {
            var type = typeof(T);
            if (!Configs.TryGetValue(type, out var config))
            {
                config = Resources.Load<T>(DefaultPath + type);
                Configs.Add(type,config);
            }
            return (T) config;
        }
    }
}