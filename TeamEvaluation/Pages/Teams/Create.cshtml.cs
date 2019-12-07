using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TeamEvaluation.DAL;
using TeamEvaluation.DAL.Entities;

namespace TeamEvaluation.Pages.Teams
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly TeamEvaluation.DAL.ApplicationDbContext _context;

        public CreateModel(TeamEvaluation.DAL.ApplicationDbContext context)
        {
            _context = context;
        }

        public int? ProjectId { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name", id);
            }
            else
            {
                ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name");
            }
                   
            return Page();
        }

        [BindProperty]
        public Team Team { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Teams.Add(Team);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
