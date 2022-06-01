using DevGamesAPI.Entities;

namespace DevGamesAPI.Context.Repositories;

public interface IPostRepository
{
    IEnumerable<Post> ObterTodosPorBoard(int boardId);
    Post ObterPorId(int id);
    void Adicionar(Post post);
    void PostarComentario(Comentario comentario);
    bool PostExiste(int postId);
}