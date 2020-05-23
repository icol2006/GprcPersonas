using MediatR;

namespace MinInt.ModuloWeb.Personas.EventHandlers.Commands
{
    public class SubstracAccessUserCommand : IRequest<int>
    {
        public int ID_PER { get; set; }
        public int ID_PERMISOS_USUARIOS { get; set; }
    }
}