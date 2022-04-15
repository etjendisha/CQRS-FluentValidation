using Application.Features.Activities.Commands.CreateActivity;
using Application.Features.Activities.Commands.DeleteActivity;
using Application.Features.Activities.Commands.UpdateActivity;
using Application.Features.Activities.Queries.GetActivityById;
using Application.Features.Activities.Queries.GetAllActivities;
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id , UpdateActivityCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            var updatedActivity = await Mediator.Send(command);
            return Ok(updatedActivity);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllActivitiesParameter filter)
        {
            var queryGetAllActivities = new GetAllActivitiesQuery() { pageSize = filter.pageSize, pageNumber = filter.pageNumber };
            var activity = await Mediator.Send(queryGetAllActivities);
            return Ok(activity);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var queryGetActivity = new GetActivityByIdQuery() { Id = id };
            var activity = await Mediator.Send(queryGetActivity);
            return Ok(activity);
        }
    }
}
