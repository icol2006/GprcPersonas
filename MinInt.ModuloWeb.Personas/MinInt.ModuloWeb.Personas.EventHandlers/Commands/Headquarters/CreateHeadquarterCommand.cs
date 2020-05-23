using MediatR;

namespace MinInt.ModuloWeb.Personas.EventHandlers.Commands
{
    public class CreateHeadquarterCommand : IRequest<long>
    {
        public string Titulo { get; set; }

        public int IdJefe { get; set; }

        public int IdSubrogante { get; set; }
    }
}
