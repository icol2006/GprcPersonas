using static MinInt.ModuloWeb.Personas.Utilities.TechnicalResponse;
using MinInt.ModuloWeb.Personas.Persistence.Database;
using MinInt.ModuloWeb.Personas.Queries;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using MediatR;
using MinInt.ModuloWeb.Personas.Queries.DTOs;
using MinInt.ModuloWeb.Personas.Utilities;

namespace MinInt.ModuloWeb.Personas.EventHandlers
{
    public class LoginHandler : IRequestHandler<LoginQuery, LoginResponse>
    {
        private readonly ApplicationDbContext _context;

        public LoginHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<LoginResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var loginResponse = new LoginResponse();
            var error = ErrorCode.UsuarioNoResgistrado;
            var respuesta = (from A in _context.Personas where A.RUT == request.Rut select A).FirstOrDefault();
            
            if (respuesta != null)
            {
                if (EncryptExtension.DesEncriptar(request.Password) == EncryptExtension.DesEncriptar(respuesta.PASSWORD))
                {
                    loginResponse.Name = $"{respuesta.NOMBRES} {respuesta.AP_PATERNO} {respuesta.AP_MATERNO}";
                    loginResponse.IdPer = respuesta.ID_PER;
                    error = ErrorCode.None;
                }
                else
                {
                    error = ErrorCode.PasswordIncorrecta;
                }
            }
            
            loginResponse.ERROR = error;

            return Task.FromResult(loginResponse);
        }
    }
}
