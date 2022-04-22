using Project.Scripts.GamePlay.Cube.Data;
using Project.Scripts.GamePlay.Cube.Data.Stats;

namespace Project.Scripts.GameControl.Models
{
    public class PlaceModel : IPlaceModel
    {
        public ICubeData SelectedCube { get; set; }
    }
}