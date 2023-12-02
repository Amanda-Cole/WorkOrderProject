using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WorkOrderProject.Data;
using WorkOrderProject.Models;

namespace WorkOrderProject.Pages.WorkOrders
{
    public class CreateModel : PageModel
    {
        private readonly WorkOrderProject.Data.WorkOrderProjectContext _context;

        public CreateModel(WorkOrderProject.Data.WorkOrderProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public WorkOrder WorkOrder { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.WorkOrder == null || WorkOrder == null)
            {
                return Page();
            }

            _context.WorkOrder.Add(WorkOrder);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
