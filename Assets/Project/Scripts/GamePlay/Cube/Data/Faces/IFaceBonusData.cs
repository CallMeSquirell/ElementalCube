using Project.Scripts.GamePlay.Cube.Data.Stats;
using Project.Scripts.GamePlay.Enemy.Data;

namespace Project.Scripts.GamePlay.Cube.Data.Faces
{
    public interface IFaceBonusData
    {
        void Process(IEnemyData data, ICubeInfo info);
        void Clear();
    }
}