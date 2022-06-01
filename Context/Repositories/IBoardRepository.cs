using DevGamesAPI.Entities;

namespace DevGamesAPI.Context.Repositories;

public interface IBoardRepository
{
    IEnumerable<Board> ObterTodos();
    Board ObterPorId(int id);
    void Adicionar(Board board);
    void AtualizarBoard(Board board);
}