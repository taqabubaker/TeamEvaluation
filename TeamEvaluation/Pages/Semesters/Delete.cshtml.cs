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
    public class DeleteModel : PageModel
    {
        private readonly TeamEvaluation.DAL.ApplicationDbContext _context;

        public DeleteModel(TeamEvaluation.DAL.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Semester Semester { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Semester = await _context.Semesters.FirstOrDefaultAsync(m => m.Id == id);

            if (Semester == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Semester = await _context.Semesters.FindAsync(id);

            if (Semester != null)
            {
                _context.Semesters.Remove(Semester);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
