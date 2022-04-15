using Application.Common.Wrappers;
using Application.DTOs.Activities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Activities.Queries.GetAllActivities
{
    public class GetAllActivitiesQuery : IRequest<PagedResponse<IEnumerable<GetAllActivitiesDto>>>
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
    }
}
