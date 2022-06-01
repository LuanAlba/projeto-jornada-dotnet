using DevGamesAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevGamesAPI.Context.Repositories;

public class PostRepository : IPostRepository
{
    private readonly DevGamesContext context;

    public PostRepository(DevGamesContext context)
    {
        this.context = context;
    }

    public void Adicionar(Post post)
    {
        context.Posts.Add(post);
        context.SaveChanges();
    }

    public Post ObterPorId(int id)
    {
        var post = context
                .Posts
                .Include(p => p.Comentarios)
                .SingleOrDefault(p => p.Id == id);

            return post;
    }

    public IEnumerable<Post> ObterTodosPorBoard(int boardId)
    {
        return context.Posts.Where(p => p.BoardId == boardId);
    }

    public void PostarComentario(Comentario comentario)
    {
        context.Comentarios.Add(comentario);
        context.SaveChanges();
    }

    public bool PostExiste(int postId)
    {
        return context.Posts.Any(p => p.Id == postId);
    }
}