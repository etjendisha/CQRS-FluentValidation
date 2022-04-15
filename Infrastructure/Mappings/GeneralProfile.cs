using Application.DTOs.Activities;
using Application.Features.Activities.Commands.CreateActivity;
using Application.Features.Activities.Queries.GetAllActivities;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region Activity
            CreateMap<Activity, CreateActivityCommand>().ReverseMap();

            CreateMap<GetAllActivitiesQuery, GetAllActivitiesParameter>().ReverseMap();
            CreateMap<Activity, GetAllActivitiesDto>().ReverseMap();
            #endregion
        }
    }
}
