using MediatR;
using MinInt.ModuloWeb.Personas.Queries.DTOs;
using static MinInt.ModuloWeb.Personas.Utilities.TechnicalResponse;

namespace MinInt.ModuloWeb.Personas.Queries
{
    public class LoginQuery : IRequest<LoginResponse>
    {
        public int Rut { get; }
        public string Password { get; }

        public LoginQuery(int rut, string password)
        {
            Rut = rut;
            Password = password;
        }
    }
}