using DevGamesAPI.Entities;

namespace DevGamesAPI.Context
{
    public class DevGamesContext
    {
        public List<Board> Boards { get; set; }

        public DevGamesContext()
        {
            Boards = new List<Board>();
        }
    }
}
