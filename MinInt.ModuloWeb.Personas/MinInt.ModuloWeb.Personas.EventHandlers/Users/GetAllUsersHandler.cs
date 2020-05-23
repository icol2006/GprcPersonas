using MediatR;
using MinInt.ModuloWeb.Personas.Persistence.Database;
using MinInt.ModuloWeb.Personas.Queries;
using MinInt.ModuloWeb.Personas.Queries.DTOs;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using static MinInt.ModuloWeb.Personas.Utilities.TechnicalResponse;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MinInt.ModuloWeb.Personas.EventHandlers.Commons.Helpers;

namespace MinInt.ModuloWeb.Personas.EventHandlers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, GetAllUsersResponse>
    {

        private readonly ApplicationDbContext _context;

        public GetAllUsersHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GetAllUsersResponse> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var persons = (from A in _context.Personas
                           where A.ESTADOPERSONA.ID_ESTADO_PERSONA == 1
                           join B in _context.EstadoPersonas on A.ESTADO equals B.ID_ESTADO_PERSONA
                           select new Usuarios
                           {
                               ID_PER = A.ID_PER,
                               NOMBRES = A.NOMBRES,
                               AP_PATERNO = A.AP_PATERNO,
                               AP_MATERNO = A.AP_MATERNO,
                               RUT = A.RUT,
                               DIG_VER = A.DIG_VER,
                               CORREO_ELECTRONICO = A.CORREO_ELECTRONICO,
                               ESTADO = B.DESCRIPCION
                           })
                                .Skip((request.PageNumber - 1) * request.PageSize)
                                .Take(request.PageSize).ToList();

            var users = new GetAllUsersResponse();

            var totalUsers = await _context.Personas
                .CountAsync(cancellationToken)
                .ConfigureAwait(false);

            users.TotalPages = Paging.GetTotalPages(totalUsers, request.PageSize);

            if (persons != null)
            {
                users.usuarios = persons;
                users.ERROR = ErrorCode.None;
            }
            else
            {
                users.ERROR = ErrorCode.UsuarioNoResgistrado;
            }
            return users;
        }
    }
}
