using Application.Cqrs.Journey.Commands;
using Application.Cqrs.User.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Api.PruebaNewShore.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "Journeys")]
    public class JourneyController :  ApiControllerBase
    {
        /// <summary>
        /// Agrega un nuevo Journey en la base de datos
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostJourney([FromBody] PostJourneyCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Agrega un nuevo Journey en la base de datos
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetJourney([FromQuery] GetJourneyQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
