using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeamEvaluation.DAL;
using TeamEvaluation.DAL.Entities;

namespace TeamEvaluation.Pages.Semesters
{
    [Authorize]
    public class AddProjectModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AddProjectModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Project> Projects { get; set; }

        
        [Display(Name ="Project")]
        [BindProperty]
        public Project Project{ get; set; }

        public Semester Semester { get; set; }

        public void OnGet(int id)
        {
            Semester = _context.Semesters.Find(id);
            if (Semester == null)
            {
                NotFound();
            }
            Projects = _context.Projects.ToList();
        }

        public void OnPost(int id,int projectId)
        {
            Semester = _context.Semesters.Find(id);
            if (Semester == null)
            {
                NotFound();
            }
        }
    }
}