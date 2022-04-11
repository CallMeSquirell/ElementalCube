using UnityEngine;

namespace Project.Scripts.Framework.ResourceManagement
{
    public interface IConfig
    {
        T Get<T>() where T : ScriptableObject;
    }
}