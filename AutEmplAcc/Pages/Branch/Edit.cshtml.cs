using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutEmplAcc.Data;
using AutEmplAcc.Model;

namespace AutEmplAcc.Pages.Branch
{
    public class EditModel : PageModel
    {
        private readonly AutEmplAcc.Data.AutEmplAccContext _context;

        public EditModel(AutEmplAcc.Data.AutEmplAccContext context)
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

            var branches =  await _context.Branches.FirstOrDefaultAsync(m => m.BranchId == id);
            if (branches == null)
            {
                return NotFound();
            }
            Branches = branches;
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

            _context.Attach(Branches).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BranchesExists(Branches.BranchId))
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

        private bool BranchesExists(int? id)
        {
          return (_context.Branches?.Any(e => e.BranchId == id)).GetValueOrDefault();
        }
    }
}
