using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TeamEvaluation.DAL;
using TeamEvaluation.DAL.Entities;

namespace TeamEvaluation.Pages.Projects
{
    public class GradesModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public GradesModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Project Project { get; set; }

        public Judge Judge { get; set; }
        public void OnGet(int jid, int pid, int tid)
        {
            Project = _context.Projects
                .Include(i => i.Teams)
                .Include("ProjectsCriterias.Criteria")
                .SingleOrDefault(i => i.Id == pid);

            Judge = _context.Judges.Find(jid);
            if (Judge == null || Project == null)
            {
                NotFound();
            }
        }

        public async Task<IActionResult> OnPostAsync(int jid, int pid, int tid)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Project = _context.Projects
               .Include(i => i.Teams)
               .Include("ProjectsCriterias.Criteria")
               .SingleOrDefault(i => i.Id == pid);
            try
            {
                //var grades = Request.Form.Keys.Any(i => i.StartsWith("txt_"));
                var grades = new List<Grade>();
                foreach (var criteria in Project.ProjectsCriterias.Select(i => i.Criteria))
                {
                    grades.Add(new Grade()
                    {
                        CriteriaId = criteria.Id,
                        JudgeId = jid,
                        ProjectId = pid,
                        TeamId = tid,
                        Value = Convert.ToInt32(Request.Form[$"txt_{criteria.Id}"])
                    });

                }


                _context.Grades.AddRange(grades);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToPage("./evaluate", new { jid, pid });
        }
    }
}