using AutoMapper;
using DevGamesAPI.Context;
using DevGamesAPI.Context.Repositories;
using DevGamesAPI.Entities;
using DevGamesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevGamesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IBoardRepository repository;

        public BoardsController(IMapper mapper, IBoardRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {   
            var boards = repository.ObterTodos();
            return Ok(boards);
        }

        //GET api/boards/1
        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var board = repository.ObterPorId(id);

            if(board == null)
                return NotFound();

            return Ok(board);
        }

        //POST api/boards/1
        [HttpPost]
        public IActionResult Adicionar(/* [FromServices] IMapper mapper, */ AddBoardsInputModel model)
        {
            //Mapeando um board para um obj de saída
            var board = mapper.Map<Board>(model);

            repository.Adicionar(board);
                      
            return CreatedAtAction(nameof(ObterPorId), new { id = board.Id }, model);
        }

        [HttpPut("{id}")]
        public IActionResult Editar(int id, AtualizarBoardsInputModel model)
        {
            var board = repository.ObterPorId(id);

            if(board == null)
                return NotFound();

            board.AtualizarBoard(model.Descricao, model.Regras);

            repository.AtualizarBoard(board);

            return NoContent();
        }
    }
}