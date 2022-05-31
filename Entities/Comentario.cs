namespace DevGamesAPI.Entities
{
    public class Comentario
    {
        public int Id { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string Usuario { get; private set; }
        public DateTime Criacao { get; private set; }

        public Comentario(int id, string titulo, string descricao, string usuario)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Usuario = usuario;
            
            Criacao = DateTime.Now;
        }

    }
}