using AutoMapper;
using MinInt.ModuloWeb.Personas.Queries.Common.Mapping;

namespace MinInt.ModuloWeb.Personas.Queries.DTOs.Headquarters
{
    public class GetCostCenterDto : IMapFrom<Domain.Personas>
    {
        public string PersonFullName { get; set; }
        public string CostCenter { get; set; }
        public int? RUT { get; set; }
        public int ID_PER { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<Domain.Personas, GetCostCenterDto>()
            .ForMember(x => x.CostCenter, opt => opt.MapFrom(x => x.CENTRO_COSTO.DESCRIPCION))
            .ForMember(x => x.PersonFullName, opt => opt.MapFrom(x => $"{x.NOMBRES} {x.AP_PATERNO} {x.AP_MATERNO}"));
    }
}