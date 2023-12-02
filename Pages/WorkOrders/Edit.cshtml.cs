using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkOrderProject.Data;
using WorkOrderProject.Models;

namespace WorkOrderProject.Pages.WorkOrders
{
    public class EditModel : PageModel
    {
        private readonly WorkOrderProject.Data.WorkOrderProjectContext _context;

        public EditModel(WorkOrderProject.Data.WorkOrderProjectContext context)
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

            var workorder =  await _context.WorkOrder.FirstOrDefaultAsync(m => m.Id == id);
            if (workorder == null)
            {
                return NotFound();
            }
            WorkOrder = workorder;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(WorkOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkOrderExists(WorkOrder.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WorkOrderExists(int id)
        {
          return (_context.WorkOrder?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
