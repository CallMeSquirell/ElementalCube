using UnityEngine;

namespace Project.Scripts.GameControl
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Config/Level")]
    public class LevelConfig : ScriptableObject
    {
        [field:SerializeField] public MonoBehaviour Level { get; private set; }
    }
}