using System;
using System.Collections.Generic;
using System.Text;

namespace TeamEvaluation.DAL.Entities
{
    public class ProjectCriteria
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int CriteriaId { get; set; }
    }
}
