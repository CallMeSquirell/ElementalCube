using Project.Scripts.GamePlay.Cube.Data;
using Project.Scripts.GamePlay.Cube.Data.Stats;

namespace Project.Scripts.GameControl.Models
{
    public interface IPlaceModel
    {
        CubeStats SelectedCube { get; set; }
    }
}