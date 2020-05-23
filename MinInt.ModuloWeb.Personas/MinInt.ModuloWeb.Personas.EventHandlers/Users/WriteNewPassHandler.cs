using MediatR;
using MinInt.ModuloWeb.Personas.Persistence.Database;
using MinInt.ModuloWeb.Personas.Queries;
using MinInt.ModuloWeb.Personas.Queries.DTOs;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static MinInt.ModuloWeb.Personas.Utilities.TechnicalResponse;

namespace MinInt.ModuloWeb.Personas.EventHandlers
{
    public class WriteNewPassHandler : IRequestHandler<WriteNewPassQuery, WriteNewPassResponse>
    {
        private readonly ApplicationDbContext _context;


        public WriteNewPassHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<WriteNewPassResponse> Handle(WriteNewPassQuery request, CancellationToken cancellationToken)
        {
            var person = _context.Personas.FirstOrDefault(x => x.ID_PER == request.IdPer);
            var writeNewpassResponse = new WriteNewPassResponse();
            writeNewpassResponse.ERROR = ErrorCode.UsuarioNoResgistrado;

            if (person != null)
            {
                person.PASSWORD = request.Pass;
                _context.Personas.Update(person);
                _context.SaveChanges();

                writeNewpassResponse.CORREO_ELECTRONICO = person.CORREO_ELECTRONICO;
                writeNewpassResponse.NOMBRE_COMPLETO = person.NOMBRES + " " + person.AP_PATERNO + " " + person.AP_MATERNO;
                writeNewpassResponse.ID_PER = person.ID_PER;
                writeNewpassResponse.ERROR = ErrorCode.None;
            }

            return Task.FromResult(writeNewpassResponse);
        }
    }
}
