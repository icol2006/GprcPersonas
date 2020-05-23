using System.Collections.Generic;

namespace MinInt.ModuloWeb.Personas.Queries.DTOs
{
    public class GetAccessUserResponse
    {
        public IList<UserPermissionDto> PermissionsAssigned { get; set; }
        public IList<UserPermissionDto> PermissionsNotAssigned { get; set; }
    }
}
