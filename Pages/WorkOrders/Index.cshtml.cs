using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkOrderProject.Data;
using WorkOrderProject.Models;

namespace WorkOrderProject.Pages.WorkOrders
{
    public class IndexModel : PageModel
    {
        private readonly WorkOrderProject.Data.WorkOrderProjectContext _context;

        public IndexModel(WorkOrderProject.Data.WorkOrderProjectContext context)
        {
            _context = context;
        }

        public IList<WorkOrder> WorkOrder { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.WorkOrder != null)
            {
                WorkOrder = await _context.WorkOrder.ToListAsync();
            }
        }
    }
}
