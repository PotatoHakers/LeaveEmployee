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
    public class DetailsModel : PageModel
    {
        private readonly AutEmplAcc.Data.AutEmplAccContext _context;

        public DetailsModel(AutEmplAcc.Data.AutEmplAccContext context)
        {
            _context = context;
        }

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
    }
}
