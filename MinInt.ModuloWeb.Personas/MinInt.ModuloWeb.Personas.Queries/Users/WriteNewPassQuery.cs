using MediatR;
using MinInt.ModuloWeb.Personas.Queries.DTOs;

namespace MinInt.ModuloWeb.Personas.Queries
{
    public class WriteNewPassQuery : IRequest<WriteNewPassResponse>
    {
        public string Pass { get; }
        public int IdPer { get; }

        public WriteNewPassQuery(string pass, int idPer)
        {
            Pass = pass;
            IdPer = idPer;
        }
    }
}
