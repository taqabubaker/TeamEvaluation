using System;
using System.Collections.Generic;
using System.Text;

namespace TeamEvaluation.DAL.Entities
{
    public class ProjectCriteria
    {
        public int ProjectId { get; set; }
        public int CriteriaId { get; set; }
        public Project Project { get; set; }
        public Criteria Criteria { get; set; }
    }
}
