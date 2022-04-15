using Application.Common.Exceptions;
using Application.Common.Wrappers;
using Application.DTOs.Activities;
using Application.Interfaces.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Activities.Commands.UpdateActivity
{
    public class UpdateActivityCommandHandler : IRequestHandler<UpdateActivityCommand, Response<Activity>>
    {
        private readonly IActivityRepositoryAsync _activityRepository;
        public UpdateActivityCommandHandler(IActivityRepositoryAsync activityRepository)
        {
            _activityRepository = activityRepository;
        }
        public async Task<Response<Activity>> Handle(UpdateActivityCommand command, CancellationToken cancellationToken)
        {
            var activity = await _activityRepository.GetByIdAsync(command.Id);

            if (activity == null)
            {
                throw new ApiException($"Activity Not Found.");
            }
            else
            {
                activity.Title = command.Title;
                activity.Category = command.Category;
                activity.Description = command.Description;
                activity.Venue = command.Venue;
                activity.City = command.City;

                await _activityRepository.UpdateAsync(activity);
                return new Response<Activity>(activity);
            }
        }
    }
}
