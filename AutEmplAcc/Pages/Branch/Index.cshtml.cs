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
    public class IndexModel : PageModel
    {
        private readonly AutEmplAcc.Data.AutEmplAccContext _context;

        public IndexModel(AutEmplAcc.Data.AutEmplAccContext context)
        {
            _context = context;
        }

        public IList<Branches> Branches { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Branches != null)
            {
                Branches = await _context.Branches.ToListAsync();
            }
        }
    }
}
