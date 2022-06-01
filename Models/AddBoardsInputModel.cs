namespace DevGamesAPI.Models
{
    //record pois é mais leve e mais simples para aceitar o construtor
    //Id no add pois por enquanto será tudo salvo em memória
    public record AddBoardsInputModel(string TituloJogo, string Descricao, string Regras)
    {      
    }
}