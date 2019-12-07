using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TeamEvaluation.DAL;
using TeamEvaluation.DAL.Entities;

namespace TeamEvaluation.Pages.Criterias
{
    public class IndexModel : PageModel
    {
        private readonly TeamEvaluation.DAL.ApplicationDbContext _context;

        public IndexModel(TeamEvaluation.DAL.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Criteria> Criteria { get;set; }

        public async Task OnGetAsync()
        {
            Criteria = await _context.Criterias.ToListAsync();
        }
    }
}
