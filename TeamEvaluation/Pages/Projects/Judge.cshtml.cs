using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeamEvaluation.DAL;
using TeamEvaluation.DAL.Entities;

namespace TeamEvaluation.Pages.Projects
{
    public class JudgeModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public JudgeModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Project Project { get; set; }

        [BindProperty]
        public Judge Judge { get; set; }
        public void OnGet(int id)
        {
            Project = _context.Projects.Find(id);
            if (Project == null)
            {
                NotFound();
            }
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Judges.Add(Judge);
            await _context.SaveChangesAsync();

            return RedirectToPage($"./evaluate", new { jid = Judge.Id, pid = id });
        }
    }
}