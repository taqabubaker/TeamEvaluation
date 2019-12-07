using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeamEvaluation.DAL;
using TeamEvaluation.DAL.Entities;

namespace TeamEvaluation.Pages.Projects
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly TeamEvaluation.DAL.ApplicationDbContext _context;

        public EditModel(TeamEvaluation.DAL.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Project Project { get; set; }

        public List<Criteria> Criterias { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Project = await _context.Projects
                .Include(p => p.Semester)
                .Include(pc => pc.ProjectsCriterias)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Project == null)
            {
                return NotFound();
            }
            ViewData["SemesterId"] = new SelectList(_context.Semesters, "Id", "Name");
            ViewData["Criterias"] = new MultiSelectList(_context.Criterias, "Id", "Name", Project.ProjectsCriterias.Select(pc => pc.CriteriaId));
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var selectedValues = Request.Form["Criterias"];
            var selectedCriterias = selectedValues.ToString().Split(',', StringSplitOptions.RemoveEmptyEntries);

            var projectsCriterias = new List<ProjectCriteria>();

            if (selectedCriterias?.Length > 0)
            {
                foreach (var criteria in selectedCriterias)
                {
                    projectsCriterias.Add(new ProjectCriteria()
                    {
                        CriteriaId = Convert.ToInt32(criteria)
                    });
                }
                Project.ProjectsCriterias = projectsCriterias;
            }

            _context.Attach(Project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(Project.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProjectExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}
