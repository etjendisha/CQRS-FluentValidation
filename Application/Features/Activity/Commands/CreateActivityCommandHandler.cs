using Application.Common.Wrappers;
using Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Activity.Commands
{
    public class CreateActivityCommandHandler : IRequestHandler<CreateActivityCommand, Response<Guid>>
    {
        private readonly IActivityRepositoryAsync _activityRepository;
    }
}
