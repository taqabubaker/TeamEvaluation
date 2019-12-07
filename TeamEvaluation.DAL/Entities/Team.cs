using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeamEvaluation.DAL.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Members { get; set; }
        [Display(Name="Project")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
