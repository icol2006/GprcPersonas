using MediatR;
using Microsoft.AspNetCore.Mvc;
using MinInt.ModuloWeb.Personas.EventHandlers.Commands;
using MinInt.ModuloWeb.Personas.EventHandlers.Commands.Headquarters;
using MinInt.ModuloWeb.Personas.Queries.DTOs.Headquarters;
using MinInt.ModuloWeb.Personas.Queries.HeadQuarters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinInt.ModuloWeb.Personas.Api.Controllers
{
    [Route("Jefaturas")]
    [ApiController]
    public class JefaturasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JefaturasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Assign")]
        public async Task<IActionResult> Assign(AssignCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpGet("GetAssign")]
        public async Task<ActionResult<GetAssignQueryResponse>> GetAssign(int idJefatura, int numberPage, int pageSize)
        {
            return await _mediator.Send(new GetAssignQuery { IdJefatura = idJefatura, NumberPage = numberPage, PageSize = pageSize });
        }

        [HttpGet("GetCostCenter")]
        public async Task<ActionResult<GetCostCenterQueryResponse>> GetCostCenter(string centroCosto, int numberPage, int pageSize)
        {
            return await _mediator.Send(new GetCostCenterQuery { CentroCosto = centroCosto, NumberPage = numberPage, PageSize = pageSize });
        }

        [HttpGet("GetAllHeadQuarters")]
        public async Task<GetAllHeadQuartersResponse> GetAllHeadQuarters(int numberPage, int pageSize)
        {
            return await _mediator.Send(new GetAllHeadQuartersQuery { NumberPage = numberPage, PageSize = pageSize });
        }

        [HttpGet("SearchHeadquarters ")]
        public async Task<IList<SearchHeadquartersResponse>> SearchHeadquarters(string title)
        {
            return await _mediator.Send(new SearchHeadquartersQuery { Title = title });
        }

        [HttpGet("SearchUsers")]
        public async Task<SearchUsersResponse> SearchUsers(string toSearch)
        {
            return await _mediator.Send(new SearchUsersQuery { ToSearch = toSearch });
        }

        [HttpPost("Create")]
        public async Task<ActionResult<long>> Create(CreateHeadquarterCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut("Update")]
        public async Task<ActionResult<long>> Update(UpdateHeadquarterCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpGet("GetId")]
        public async Task<GetIdResponse> GetId(int idJefatura)
        {
            return await _mediator.Send(new GetIdQuery { IdJefatura = idJefatura });
        }
    }
}
