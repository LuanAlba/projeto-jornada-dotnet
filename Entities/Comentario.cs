namespace DevGamesAPI.Entities
{
    public class Comentario
    {
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string Usuario { get; private set; }

        //relação um comentario pertence a um post
        public int PostId { get; private set; }
        public DateTime Criacao { get; private set; }

        public Comentario(string titulo, string descricao, string usuario, int postId)
        {
            Titulo = titulo;
            Descricao = descricao;
            Usuario = usuario;
            PostId = postId;
            
            Criacao = DateTime.Now;
        }

    }
}