using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public IActionResult OnGet(int id)
        {
            Project = _context.Projects.Find(id);
            if (Project == null)
            {
                NotFound();
            }

            return Page();
        }
    }
}