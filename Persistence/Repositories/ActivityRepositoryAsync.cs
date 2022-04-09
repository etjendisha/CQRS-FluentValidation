using Application.Interfaces.Repositories;
using DAL;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ActivityRepositoryAsync : GenericRepositoryAsync<Activity>, IActivityRepositoryAsync
    {
        private readonly DbSet<Activity> _activities;

        public ActivityRepositoryAsync(ReactivitiesContext dbContext) : base(dbContext)
        {
            _activities = dbContext.Set<Activity>();
        }

        public Task<bool> IsUniqueBarcodeAsync(string barcode)
        {
            return _activities.
        }
    }
}
