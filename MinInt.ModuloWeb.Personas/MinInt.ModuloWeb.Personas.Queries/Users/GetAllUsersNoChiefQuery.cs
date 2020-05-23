using MediatR;
using System.Collections.Generic;

namespace MinInt.ModuloWeb.Personas.Queries.Users
{
    public class GetAllUsersNoChiefQuery : IRequest<IList<string>>
    {
    }
}
