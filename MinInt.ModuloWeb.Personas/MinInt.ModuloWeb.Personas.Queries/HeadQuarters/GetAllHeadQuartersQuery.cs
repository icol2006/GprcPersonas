using MediatR;

namespace MinInt.ModuloWeb.Personas.Api.Controllers
{
    public class GetAllHeadQuartersQuery : IRequest<GetAllHeadQuartersResponse>
    {
        public int PageSize { get; set; }
        public int NumberPage { get; set; }
    }
}