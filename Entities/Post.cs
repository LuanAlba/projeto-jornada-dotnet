namespace DevGamesAPI.Entities
{
    public class Post
    {
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime Criacao { get; private set; }
        public List<Comentario> Comentarios { get; private set; }

        public Post(int id, string titulo, string descricao)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            
            Criacao = DateTime.Now;
            Comentarios = new List<Comentario>();
        }

        public void AddComentario(Comentario comentario)
        {
            Comentarios.Add(comentario);
        }
    }
}