using MediatR;
using MinInt.ModuloWeb.Personas.Queries.DTOs;

namespace MinInt.ModuloWeb.Personas.EventHandlers.Commands
{
    public class GetAccessSystemQuery : IRequest<GetAccessSystemResponse>
    {
        public int ID_PER { get; set; }
        public int ID_SISTEMA { get; set; }
    }
}