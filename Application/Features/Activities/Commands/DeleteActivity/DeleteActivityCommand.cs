using Application.Common.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Activities.Commands.DeleteActivity
{
    public class DeleteActivityCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
    }
}
