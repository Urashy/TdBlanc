using AutoMapper;
using TdBlanc.Models;
using TdBlanc.Models.DTO;

namespace TdBlanc.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // Mapping Animal → AnimalDTO
            CreateMap<Animal, AnimalDTO>()
                .ForMember(dest => dest.IdAnimal, opt => opt.MapFrom(src => src.IdAnimal))
                .ForMember(dest => dest.DisplayReference, opt => opt.MapFrom(src => src.DisplayReference))
                .ForMember(dest => dest.IsPrivate, opt => opt.MapFrom(src => src.IsPrivate));

            // Mapping AnimalDTO → Animal
            CreateMap<AnimalDTO, Animal>()
                .ForMember(dest => dest.IdAnimal, opt => opt.MapFrom(src => src.IdAnimal))
                .ForMember(dest => dest.IsPrivate, opt => opt.MapFrom(src => src.IsPrivate));
        }
    }
}