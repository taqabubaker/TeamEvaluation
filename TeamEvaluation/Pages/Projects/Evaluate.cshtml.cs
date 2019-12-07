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
    public class EvaluateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EvaluateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Project Project { get; set; }

        public Judge Judge { get; set; }

        public void OnGet(int jid, int pid)
        {
            Project = _context.Projects
                .Include(i => i.Teams)
                .SingleOrDefault(i => i.Id == pid);

            Judge = _context.Judges.Find(jid);

            if (Judge == null || Project == null)
            {
                NotFound();
            }


        }
    }
}