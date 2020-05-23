using MediatR;

namespace MinInt.ModuloWeb.Personas.EventHandlers.Commands
{
    public class UpdateHeadquarterCommand : IRequest
    {
        public string Titulo { get; set; }

        public int IdJefe { get; set; }

        public int IdSubrogante { get; set; }

        public int IdJefatura { get; set; }
    }
}
