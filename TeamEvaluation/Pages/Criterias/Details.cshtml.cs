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
    public class DetailsModel : PageModel
    {
        private readonly TeamEvaluation.DAL.ApplicationDbContext _context;

        public DetailsModel(TeamEvaluation.DAL.ApplicationDbContext context)
        {
            _context = context;
        }

        public Criteria Criteria { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Criteria = await _context.Criterias.FirstOrDefaultAsync(m => m.Id == id);

            if (Criteria == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
