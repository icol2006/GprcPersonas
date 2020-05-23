using AutoMapper;
using MinInt.ModuloWeb.Personas.Queries.Common.Mapping;

namespace MinInt.ModuloWeb.Personas.Queries.DTOs.Users
{
    public class GetUserByIdDto : IMapFrom<Domain.Personas>
    {
		public int IdPer { get; set; }

		public string Nombre { get; set; }

		public int IdJefe { get; set; }

		public string NombreJefe { get; set; }

		public int IdCentroCosto { get; set; }

		public string CentroCosto { get; set; }

		public int IdSubrrogante { get; set; }

		public string NombreJefeSubrrogante { get; set; }

		public void Mapping(Profile profile) => profile.CreateMap<Domain.Personas, GetUserByIdDto>()
			.ForMember(x => x.IdPer, opt => opt.MapFrom(x => x.ID_PER))
			.ForMember(x => x.IdJefe, opt => opt.MapFrom(x => x.JEFATURA.ID_JEFE))
			.ForMember(x => x.IdSubrrogante, opt => opt.MapFrom(x => x.JEFATURA.ID_SUBROGANTE))
			.ForMember(x => x.IdCentroCosto, opt => opt.MapFrom(x => x.ID_CENTRO_COSTO))
			.ForMember(x => x.CentroCosto, opt => opt.MapFrom(x => x.CENTRO_COSTO.DESCRIPCION))
			.ForMember(x => x.Nombre, opt => opt.MapFrom(x => x.NOMBRES))
			.ForMember(x => x.NombreJefe, opt => opt.MapFrom(x => x.JEFATURA.JEFE.NOMBRES))
			.ForMember(x => x.NombreJefeSubrrogante, opt => opt.MapFrom(x => x.JEFATURA.SUBROGANTE.NOMBRES));
	}
}