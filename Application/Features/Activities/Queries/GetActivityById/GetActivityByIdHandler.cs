using Application.Common.Exceptions;
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

namespace Application.Features.Activities.Queries.GetActivityById
{
    public class GetActivityByIdHandler : IRequestHandler<GetActivityByIdQuery, Response<Activity>>
    {
        private readonly IActivityRepositoryAsync _activityRepository;
        private readonly IMapper _mapper;

        public GetActivityByIdHandler(IActivityRepositoryAsync activityRepository, IMapper mapper)
        {
            _activityRepository = activityRepository;
            _mapper = mapper;
        }

        public async Task<Response<Activity>> Handle(GetActivityByIdQuery query, CancellationToken cancellationToken)
        {
            var activity = await _activityRepository.GetByIdAsync(query.Id);
            if (activity == null) throw new ApiException($"Activity Not Found.");
            return new Response<Activity>(activity);
        }
    }
}
