using AutoMapper;
using DevGamesAPI.Context;
using DevGamesAPI.Context.Repositories;
using DevGamesAPI.Entities;
using DevGamesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevGamesAPI.Controllers
{
    [Route("api/boards/{id}/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IPostRepository repository;
        public PostsController(IMapper mapper, IPostRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult ObterTodos(int id)
        {
            var posts = repository.ObterTodosPorBoard(id);

            return Ok(posts);
        }

        //GET api/boards/1/posts
        [HttpGet("{postId}")]
        public IActionResult ObterPorId(int id, int postId)
        {
            var post = repository.ObterPorId(postId);

            if (post == null)
                return NotFound();

            return Ok(post);
        }

        //POST api/boards/1
        [HttpPost]
        public IActionResult Adicionar(int id, AddPostsInputModel model)
        {
            var post = new Post(model.Titulo, model.Descricao, id);

            repository.Adicionar(post);

            return CreatedAtAction(nameof(ObterPorId), new { id = post.Id, postId = post.Id }, model);
        }

        //POST api/boards/1/posts/1/comments
        [HttpPost("{postId}/comments")]
        public IActionResult PostarComentario(int id, int postId, AddCommentInputModel model)
        {
            var postExiste = repository.PostExiste(postId);

            if (!postExiste) return NotFound();

            var comentario = new Comentario(model.Titulo, model.Descricao, model.Usuario, postId);

            repository.PostarComentario(comentario);

            return NoContent();
            
        }
    }
}