using MediatR;
using MinInt.ModuloWeb.Personas.Queries.DTOs;

namespace MinInt.ModuloWeb.Personas.Queries
{
    public class NewPassQuery : IRequest<NewPassResponse>
    {
        public int Rut { get; }

        public NewPassQuery(int rut)
        {
            Rut = rut;
        }
    }
}
