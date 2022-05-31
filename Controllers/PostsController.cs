using DevGamesAPI.Context;
using DevGamesAPI.Entities;
using DevGamesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevGamesAPI.Controllers
{
    [Route("api/boards/{id}/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        // private readonly IMapper mapper;
        private readonly DevGamesContext context;
        public PostsController(DevGamesContext context)
        {
            // this.mapper = mapper;
            this.context = context;
        }

        [HttpGet]
        public IActionResult ObterTodos(int id)
        {
            //obter todos os POSTS de TAL BOARD
            var boards = context.Boards.SingleOrDefault(o => o.Id == id);

            if(boards == null)
                return NotFound();

            // retornar todos os POSTS de BOARD
            return Ok(boards.Posts);
        }

        //GET api/boards/1/posts
        [HttpGet("{postId}")]
        public IActionResult ObterPorId(int id, int postId)
        {
            var board = context.Boards.SingleOrDefault(o => o.Id == id);
            if(board == null)
                return NotFound();

            var post = board.Posts.SingleOrDefault(i => i.Id == postId);
            if(post == null)
                return NotFound();

            return Ok(post);
        }

        //POST api/boards/1
        [HttpPost]
        public IActionResult Adicionar(int id, AddPostsInputModel model)
        {
            var board = context.Boards.SingleOrDefault(o => o.Id == id);
            if(board == null)
                return NotFound();

            var post = new Post(model.Id, model.Titulo, model.Descricao);
            board.AddPost(post);

             return CreatedAtAction(nameof(ObterPorId), new { id = id, postId = post.Id }, post);
        }

        //POST api/boards/1/posts/1/comments
        [HttpPost("{postId}/comments")]
        public IActionResult PostarComentario(int id, int postId, AddCommentInputModel model)
        {
            var board = context.Boards.SingleOrDefault(o => o.Id == id);
            if(board == null)
                return NotFound();

            var post = board.Posts.SingleOrDefault(i => i.Id == postId);
            if(post == null)
                return NotFound();

            var comentario = new Comentario(model.Id, model.Titulo, model.Descricao, model.Usuario);
            post.AddComentario(comentario);
            
            return NoContent();
        }
    }
}