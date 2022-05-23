using UnityEngine;

namespace Project.Scripts.Configs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Config/Player")]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private int _healthCount = 3;

        public int HealthCount => _healthCount;
    }
}