using System;
using System.Collections.Generic;
using System.Text;

namespace TeamEvaluation.DAL.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int SemesterId { get; set; }        
        public Semester Semester { get; set; }
    }
}
