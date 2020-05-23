using MediatR;

namespace MinInt.ModuloWeb.Personas.EventHandlers.Commands
{
    public class JefaturaCreateCommand : INotification
    {
        public string TITULO { get; set; }
        public int ID_JEFE { get; set; }
        public int ID_SUBROGANTE { get; set; }
        public int ID_EVALUADOR { get; set; }
    }
}