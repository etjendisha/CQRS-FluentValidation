using Application.Common.Wrappers;
using Application.DTOs.Activities;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Activities.Commands.CreateActivity
{
    public class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommand, Response<Activity>>
    {
        private readonly IActivityRepositoryAsync _activityRepository;
        private readonly IMapper _mapper;

        public CreateActivityCommandHandler(IActivityRepositoryAsync activityRepository, IMapper mapper)
        {
            _activityRepository = activityRepository;
            _mapper = mapper;
        }

        public async Task<Response<Activity>> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
        {
            var activity = _mapper.Map<Activity>(request);
            await _activityRepository.AddAsync(activity);
            return new Response<Activity>(activity);
        }
    }
}
