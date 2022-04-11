using UnityEngine;

namespace Project.Scripts.GameControl
{
    public class LevelConfig : ScriptableObject
    {
        [field:SerializeField] public MonoBehaviour Level { get; private set; }
    }
}