using DevGamesAPI.Entities;

namespace DevGamesAPI.Context.Repositories;

public class BoardRepository : IBoardRepository
{
    private readonly DevGamesContext context;

    public BoardRepository(DevGamesContext context)
    {
        this.context = context;
    }

    public void Adicionar(Board board)
    {
        context.Boards.AddAsync(board);
        context.SaveChangesAsync();  
    }

    public void AtualizarBoard(Board board)
    {
        // bom contar que as vezes o board pode não estar no contexto então um update
        context.Boards.Update(board);
        context.SaveChanges();
    }

    public Board ObterPorId(int id)
    {
        // primeiro pesquisar se no board (o.id) existe um board (id) e guardar elas na variavel
        return context.Boards.SingleOrDefault(o => o.Id == id);
    }

    public IEnumerable<Board> ObterTodos()
    {
        return context.Boards.ToList();
    }

    
}