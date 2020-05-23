using MediatR;
using MinInt.ModuloWeb.Personas.Queries.DTOs.Headquarters;

namespace MinInt.ModuloWeb.Personas.Queries.HeadQuarters
{
    public class SearchUsersQuery : IRequest<SearchUsersResponse>
    {
        public string ToSearch { get; set; }
    }
}
