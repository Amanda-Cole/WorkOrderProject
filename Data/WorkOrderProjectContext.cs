using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WorkOrderProject.Models;

namespace WorkOrderProject.Data
{
    public class WorkOrderProjectContext : DbContext
    {
        public WorkOrderProjectContext (DbContextOptions<WorkOrderProjectContext> options)
            : base(options)
        {
        }

        public DbSet<WorkOrderProject.Models.WorkOrder> WorkOrder { get; set; } = default!;
    }
}
