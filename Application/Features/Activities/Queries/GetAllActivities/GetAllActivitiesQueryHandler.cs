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

namespace Application.Features.Activities.Queries.GetAllActivities
{
    public class GetAllActivitiesQueryHandler : IRequestHandler<GetAllActivitiesQuery, PagedResponse<IEnumerable<GetAllActivitiesDto>>>
    {
        private readonly IActivityRepositoryAsync _activityRepository;
        private readonly IMapper _mapper;

        public GetAllActivitiesQueryHandler(IActivityRepositoryAsync activityRepository, IMapper mapper)
        {
            _activityRepository = activityRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllActivitiesDto>>> Handle(GetAllActivitiesQuery request, CancellationToken cancellationToken)
        {
            var allActivities = await _activityRepository.GetAllAsync();

            var queryParams = _mapper.Map<GetAllActivitiesParameter>(request);
            var activity = await _activityRepository.GetPagedReponseAsync(queryParams.pageNumber, queryParams.pageSize);
            var activityViewModel = _mapper.Map<IEnumerable<GetAllActivitiesDto>>(activity);

            var data = activityViewModel;
            var pageNumber = queryParams.pageNumber;
            var pageSize = queryParams.pageSize;
            var totalItems = allActivities.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)queryParams.pageSize);

            return new PagedResponse<IEnumerable<GetAllActivitiesDto>>(data, pageNumber, pageSize, totalItems, totalPages);
        }
    }
}
