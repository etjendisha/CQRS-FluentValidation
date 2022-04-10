using Application.Interfaces.Repositories;
using DAL;
using Domain.Entities;
using Persistence.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ActivityRepositoryAsync : GenericRepositoryAsync<Activity, Guid>, IActivityRepositoryAsync
    {
        public ActivityRepositoryAsync(ReactivitiesContext dbContext) : base(dbContext)
        {
        }
    }
}
