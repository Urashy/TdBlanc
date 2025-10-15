using AutoMapper;
using TdBlanc.Models;
using TdBlanc.Models.DTO;

namespace TdBlanc.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Commande, CommandeDTO>()
                .ForMember(dest => dest.UtilisateurNom,
                           opt => opt.MapFrom(src => src.CommandeUtlisateurNavigation != null
                               ? src.CommandeUtlisateurNavigation.Nom
                               : null))
                .ForMember(dest => dest.UtilisateurId,
                           opt => opt.MapFrom(src => src.UtilisateurId));

            CreateMap<CommandeDTO, Commande>()
                .ForMember(dest => dest.CommandeUtlisateurNavigation, opt => opt.Ignore());

            CreateMap<Utilisateur, UtilisateurDTO>().ReverseMap();
        }
    }
}