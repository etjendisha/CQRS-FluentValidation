using Application.Common.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Activities.Commands.CreateActivity
{
    public partial class CreateActivityCommand : IRequest<Response<Activity>>
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public string? City { get; set; }
        public string? Venue { get; set; }
        public DateTime? Created { get; set; }
    }
}
