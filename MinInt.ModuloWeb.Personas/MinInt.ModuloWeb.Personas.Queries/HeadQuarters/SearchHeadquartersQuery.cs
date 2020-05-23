using MediatR;
using MinInt.ModuloWeb.Personas.Queries.DTOs.Headquarters;
using System.Collections.Generic;

namespace MinInt.ModuloWeb.Personas.Queries.HeadQuarters
{
    public class SearchHeadquartersQuery : IRequest<List<SearchHeadquartersResponse>>
    {
        public string Title { get; set; }
    }
}
