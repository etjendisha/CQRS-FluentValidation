using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Activity : BaseEntity
    {
        public Guid Id { get; set; }

        [StringLength(300)]
        public string? Title { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        [StringLength(300)]
        public string? Category { get; set; }

        [StringLength(300)]
        public string? City { get; set; }

        [StringLength(300)]
        public string? Venue { get; set; }
    }
}
