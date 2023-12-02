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
    public class DeleteModel : PageModel
    {
        private readonly WorkOrderProject.Data.WorkOrderProjectContext _context;

        public DeleteModel(WorkOrderProject.Data.WorkOrderProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public WorkOrder WorkOrder { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.WorkOrder == null)
            {
                return NotFound();
            }

            var workorder = await _context.WorkOrder.FirstOrDefaultAsync(m => m.Id == id);

            if (workorder == null)
            {
                return NotFound();
            }
            else 
            {
                WorkOrder = workorder;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.WorkOrder == null)
            {
                return NotFound();
            }
            var workorder = await _context.WorkOrder.FindAsync(id);

            if (workorder != null)
            {
                WorkOrder = workorder;
                _context.WorkOrder.Remove(WorkOrder);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
