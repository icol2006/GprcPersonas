using AutoMapper;
using MinInt.ModuloWeb.Personas.Domain;
using MinInt.ModuloWeb.Personas.Queries.Common.Mapping;

namespace MinInt.ModuloWeb.Personas.Queries.DTOs
{
    public class UserPermissionDto : IMapFrom<PermisosUsuario>
    {
        public int ID_PERMISOS_USUARIOS { get; set; }
        public string DESCRIPCION { get; set; }

        public void Mapping(Profile profile) => profile.CreateMap<PermisosUsuario, UserPermissionDto>()
             .ForMember(x => x.ID_PERMISOS_USUARIOS, opt => opt.MapFrom(x => x.ID_PERMISOS_USUARIOS))
             .ForMember(x => x.DESCRIPCION, opt => opt.MapFrom(x => x.DESCRIPCION));
    }
}