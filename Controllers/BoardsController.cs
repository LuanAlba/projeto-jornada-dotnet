using AutoMapper;
using DevGamesAPI.Context;
using DevGamesAPI.Entities;
using DevGamesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevGamesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly DevGamesContext context;
        public BoardsController(DevGamesContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(context.Boards);
        }

        //GET api/boards/1
        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
        // usando o context para armazenar os dados em memória
        // primeiro pesquisar se no board (o.id) existe um board (id) e guardar elas na variavel
            var board = context.Boards.SingleOrDefault(o => o.Id == id);

        // se nao encontrar, not found
            if(board == null)
                return NotFound();

        // se encontrar retornar OK com o board
            return Ok(board);
        }

        //POST api/boards/1
        [HttpPost]
        public IActionResult Adicionar(/* [FromServices] IMapper mapper, */ AddBoardsInputModel model)
        {
            //Mapeando um board para um obj de saída
            var board = mapper.Map<Board>(model);

            // var board = new Board(model.Id, model.TituloJogo, model.Descricao, model.Regras);

            context.Boards.Add(board);

            return CreatedAtAction(nameof(ObterPorId), new { id = model.Id }, model);
        }

        [HttpPut("{id}")]
        public IActionResult Editar(int id, AtualizarBoardsInputModel model)
        {
            var board = context.Boards.SingleOrDefault(o => o.Id == id);

            if(board == null)
                return NotFound();

            board.AtualizarBoard(model.Descricao, model.Regras);
            return NoContent();
        }
    }
}