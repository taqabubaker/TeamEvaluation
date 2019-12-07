﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamEvaluation.DAL;
using TeamEvaluation.DAL.Entities;

namespace TeamEvaluation.Pages.Projects
{
    public class ReportModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ReportModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Project Project { get; set; }

        public List<Grade> Grades { get; set; }

        public IActionResult OnGet(int id, int? teamId)
        {
            Project = _context.Projects
                .Include(t => t.Teams)
                .Include(g => g.Grades)
                .Include("ProjectsCriterias.Criteria")
                .Where(p => p.Id == id)
                .FirstOrDefault();

            if (Project == null)
            {
                NotFound();
            }

            Grades = new List<Grade>();

            if (teamId.HasValue)
            {
                Grades = _context.Grades
                    .Include(c => c.Criteria)
                    .Where(g => g.TeamId == teamId && g.ProjectId == Project.Id)
                    .ToList();
            }
            else
            {
                Grades = _context.Grades
                    .Where(g => g.ProjectId == Project.Id)
                    .ToList();
            }

            return Page();
        }

        public IActionResult OnStates(int? teamId)
        {
            Grades = new List<Grade>();

            if (teamId.HasValue)
            {
                Grades = _context.Grades
                    .Include(c => c.Criteria)
                    .Where(g => g.TeamId == teamId && g.ProjectId == Project.Id)
                    .ToList();
            }
            else
            {
                Grades = _context.Grades
                    .Where(g => g.ProjectId == Project.Id)
                    .ToList();
            }

            return Page();
        }
    }
}