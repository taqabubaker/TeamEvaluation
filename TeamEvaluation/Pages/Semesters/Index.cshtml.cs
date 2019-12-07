using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TeamEvaluation.DAL;
using TeamEvaluation.DAL.Entities;

namespace TeamEvaluation.Pages.Semesters
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly TeamEvaluation.DAL.ApplicationDbContext _context;

        public IndexModel(TeamEvaluation.DAL.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Semester> Semester { get;set; }

        public async Task OnGetAsync()
        {
            Semester = await _context.Semesters.ToListAsync();
        }
    }
}
