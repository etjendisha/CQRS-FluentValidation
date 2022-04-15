using Application.DTOs.Activities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestApp.Controllers.BaseController;

namespace TestApp.Controllers
{
    public class ActivityController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post(CreateActivityCommand command)
        {
            var activity = await Mediator.Send(command);
            return Ok(activity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteCommand = new DeleteActivityCommand { Id = id };
            var activity = await Mediator.Send(deleteCommand);
            return Ok(activity);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateActivityCommand command)
        {
            if (command.Id == null)
                return BadRequest();

            var updateCommand = await Mediator.Send(command);
            return Ok(updateCommand);
        }

    }
}
