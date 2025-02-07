﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AutEmplAcc.Data;
using AutEmplAcc.Model;

namespace AutEmplAcc.Pages.Emp
{
    public class IndexModel : PageModel
    {
        public Branches SelectedBranch { get; set; }
        private readonly AutEmplAccContext _context;

        public IndexModel(AutEmplAccContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get; set; } = default!;
        public List<Branches> Branches { get; set; }

        public async Task OnGetAsync()
        {

            if (_context.Employees != null)
            {
                Employee = await _context.Employees.ToListAsync();
            }
            Branches = await _context.Branches.ToListAsync();

        }

        public async Task<IActionResult> OnPostShowEmployeesAsync(int branchId)
        {

            var branch = await _context.Branches
        .Include(b => b.Employees)
        .FirstOrDefaultAsync(b => b.BranchId == branchId);
            if (branch != null)
            {
                return Partial("_EmployeeListPartial", branch.Employees);
            }
            return NotFound();

        }

        //public async Task<IActionResult> OnPostShowBranchesAsync(int branchId)
        //{
        //    var branch = await _context.Branches
        //.FirstOrDefaultAsync(b => b.BranchId == branchId);
        //    if (branch != null)
        //    {
        //        return Partial("_BranchListPartial", branch.Employees);
        //    }
        //    return NotFound();
        //}
    }
}