using AutoMapper;
using MinInt.ModuloWeb.Personas.Queries.Common.Mapping;

namespace MinInt.ModuloWeb.Personas.Queries.DTOs.Headquarters
{
    public class GetIdDto : IMapFrom<Domain.Personas>
    {
        public int IdPer { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<Domain.Personas, GetIdDto>()
            .ForMember(x => x.IdPer, opt => opt.MapFrom(x => x.ID_PER))
            .ForMember(x => x.Name, opt => opt.MapFrom(x => $"{x.NOMBRES} {x.AP_PATERNO} {x.AP_MATERNO}"));
    }
}