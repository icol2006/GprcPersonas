using MediatR;
using System.Collections.Generic;

namespace MinInt.ModuloWeb.Personas.EventHandlers.Commands.Headquarters
{
    public class AssignCommand : IRequest
    {
        public int IdJefatura { get; set; }
        public IList<int> IdPer { get; set; }
    }
}
