using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AutEmplAcc.Data;
using AutEmplAcc.Model;

namespace AutEmplAcc.Pages.Branch
{
    public class CreateModel : PageModel
    {
        private readonly AutEmplAcc.Data.AutEmplAccContext _context;

        public CreateModel(AutEmplAcc.Data.AutEmplAccContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Branches Branches { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Branches == null || Branches == null)
            {
                return Page();
            }

            _context.Branches.Add(Branches);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
