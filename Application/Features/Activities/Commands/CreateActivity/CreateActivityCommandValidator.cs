using Application.DTOs.Activities;
using Application.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Activities.Commands.CreateActivity
{
    public class CreateActivityCommandValidator : AbstractValidator<CreateActivityCommand>
    {
        private readonly IActivityRepositoryAsync activityRepository;

        public CreateActivityCommandValidator(IActivityRepositoryAsync activityRepository)
        {
            this.activityRepository = activityRepository;

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");

        }
    }
}
