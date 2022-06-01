namespace DevGamesAPI.Entities
{
    public class Board
    {
        public int Id { get; private set; }
        public string TituloJogo { get; private set; }
        public string Descricao { get; private set; }
        public string Regras { get; private set; }
        public DateTime Criacao { get; private set; }
        public List<Post> Posts { get; private set; }

        public Board(string tituloJogo, string descricao, string regras)
        {
            TituloJogo = tituloJogo;
            Descricao = descricao;
            Regras = regras;

            Criacao = DateTime.Now; 
            Posts = new List<Post>();
        }

        public void AtualizarBoard(string descricao, string regras)
        {
            Descricao = descricao;
            Regras = regras;
        }

// add com ele adicionando ele mesmo
        public void AddPost(Post post)
        {
            Posts.Add(post);
        }
    }
}