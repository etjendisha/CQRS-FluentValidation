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
            
    }
}
