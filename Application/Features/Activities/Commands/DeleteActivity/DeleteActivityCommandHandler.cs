using Application.Common.Exceptions;
using Application.Common.Wrappers;
using Application.DTOs.Activities;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Activities.Commands.DeleteActivity
{
    public class DeleteActivityCommandHandler : IRequestHandler<DeleteActivityCommand, Response<Guid>>
    {
        private readonly IActivityRepositoryAsync _activityRepository;
        private readonly IMapper _mapper;

        public DeleteActivityCommandHandler(IActivityRepositoryAsync activityRepository, IMapper mapper)
        {
            _activityRepository = activityRepository;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(DeleteActivityCommand command, CancellationToken cancellationToken)
        {
            var activity = await _activityRepository.GetByIdAsync(command.Id);
            if (activity == null) throw new ApiException($"Activity Not Found.");
            await _activityRepository.RemoveAsync(activity);
            return new Response<Guid>(activity.Id);
        }
    }
}
