using Application.Common.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Activities.Queries.GetActivityById
{
    public class GetActivityByIdQuery : IRequest<Response<Activity>>
    {
        public Guid Id { get; set; }
    }
}
