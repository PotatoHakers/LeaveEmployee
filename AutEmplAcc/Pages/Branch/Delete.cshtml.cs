using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutEmplAcc.Data;
using AutEmplAcc.Model;

namespace AutEmplAcc.Pages.Branch
{
    public class DeleteModel : PageModel
    {
        private readonly AutEmplAcc.Data.AutEmplAccContext _context;

        public DeleteModel(AutEmplAcc.Data.AutEmplAccContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Branches Branches { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Branches == null)
            {
                return NotFound();
            }

            var branches = await _context.Branches.FirstOrDefaultAsync(m => m.BranchId == id);

            if (branches == null)
            {
                return NotFound();
            }
            else 
            {
                Branches = branches;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Branches == null)
            {
                return NotFound();
            }
            var branches = await _context.Branches.FindAsync(id);

            if (branches != null)
            {
                Branches = branches;
                _context.Branches.Remove(Branches);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
