using MediatR;

namespace MinInt.ModuloWeb.Personas.EventHandlers.Commands
{
    public class SubstracAccessSystemCommand : IRequest
    {
        public int ID_PER { get; set; }
        public int ID_SISTEMA { get; set; }
        public int ID_PERMISOS_SISTEMA { get; set; }
    }
}