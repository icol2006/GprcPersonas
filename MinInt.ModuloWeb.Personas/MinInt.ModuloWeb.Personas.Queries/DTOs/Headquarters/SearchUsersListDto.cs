using AutoMapper;
using MinInt.ModuloWeb.Personas.Domain;
using MinInt.ModuloWeb.Personas.Queries.Common.Mapping;

namespace MinInt.ModuloWeb.Personas.Queries.DTOs.Headquarters
{
    public class SearchUsersListDto : IMapFrom<Domain.Personas>
    {
        public int ID_PER { get; set; }

        public string Name { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<Domain.Personas, SearchUsersListDto>()
            .ForMember(x => x.Name, opt => opt.MapFrom(x => $"{x.ID_PER} {x.NOMBRES} {x.AP_PATERNO} {x.AP_MATERNO}"));
    }
}