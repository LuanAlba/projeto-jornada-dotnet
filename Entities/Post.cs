namespace DevGamesAPI.Entities
{
    public class Post
    {
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime Criacao { get; private set; }

        //relação um post pertence a um board
        public int BoardId { get; private set; }

        public List<Comentario> Comentarios { get; private set; }

        public Post(string titulo, string descricao, int boardId)
        {
            Titulo = titulo;
            Descricao = descricao;
            BoardId = boardId;

            Criacao = DateTime.Now;
            Comentarios = new List<Comentario>();
        }

        public void AddComentario(Comentario comentario)
        {
            Comentarios.Add(comentario);
        }
    }
}