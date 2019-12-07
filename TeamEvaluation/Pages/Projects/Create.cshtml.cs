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

namespace TeamEvaluation.Pages.Projects
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public int? SemesterId { get; set; }
        public List<Criteria> Criterias { get; set; }

        public IActionResult OnGet(int? id)
        {
            SemesterId = id;
            if (id.HasValue)
            {
                ViewData["SemesterId"] = new SelectList(_context.Semesters, "Id", "Name", id);
            }
            else
            {
                ViewData["SemesterId"] = new SelectList(_context.Semesters, "Id", "Name");
            }

            ViewData["Criterias"] = new MultiSelectList(_context.Criterias, "Id", "Name");

            return Page();
        }

        [BindProperty]
        public Project Project { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var selectedValues = Request.Form["Criterias"];
                var selectedCriterias = selectedValues.ToString().Split(',',StringSplitOptions.RemoveEmptyEntries);

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
                
                _context.Projects.Add(Project);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToPage("./Index");
        }
    }
}
