using AutoMapper;
using TdBlanc.Models;
using TdBlanc.Models.DTO;

namespace TdBlanc.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
        

            CreateMap<Animal, AnimalDTO>().ReverseMap();
        }
    }
}