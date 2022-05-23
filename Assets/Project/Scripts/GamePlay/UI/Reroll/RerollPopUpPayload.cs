using Project.Scripts.GamePlay.Tile.Data;

namespace Project.Scripts.GamePlay.UI.Reroll
{
    public class RerollPopUpPayload
    {
        public ITileData TileData { get; }
        
        public RerollPopUpPayload(ITileData tileData)
        {
            TileData = tileData;
        }
    }
}