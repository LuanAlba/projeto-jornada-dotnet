using AutoMapper;
using DevGamesAPI.Entities;
using DevGamesAPI.Models;

namespace DevGamesAPI.Mappers
{
    public class BoardMapper : Profile
    {
        public BoardMapper()
        {
            CreateMap<AddBoardsInputModel, Board>();
        }
    }
}