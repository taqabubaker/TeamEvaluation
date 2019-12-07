using System;
using System.Collections.Generic;
using System.Text;

namespace TeamEvaluation.DAL.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Members { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
