using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeamEvaluation.DAL.Entities
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        //[StringLength(255,MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public int Weight { get; set; }
        public int SemesterId { get; set; }        
        public Semester Semester { get; set; }
    }
}
