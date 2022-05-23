namespace Project.Scripts.GamePlay.UI.Result
{
    public class ResultScreenPayload
    {
        public bool IsWon { get; }
        
        public ResultScreenPayload(bool isWon)
        {
            IsWon = isWon;
        }
    }
}