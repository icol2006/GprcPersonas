using MinInt.ModuloWeb.Personas.Domain;
using System.Collections;
using System.Collections.Generic;

namespace MinInt.ModuloWeb.Personas.Queries.DTOs.Headquarters
{
    public class GetIdResponse
    {
        public IList<GetIdDto> Persons { get; set; }

        public IList<GetIdDto> PersonsNoChief { get; set; }

        public JefaturaDto Jefatura { get; set; }
    }
}
