using AutoMapper;

namespace MinInt.ModuloWeb.Personas.Queries.Common.Mapping
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
