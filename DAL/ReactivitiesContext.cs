using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReactivitiesContext : DbContext
    {
        public ReactivitiesContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; }
    }
}
