using System;
using System.Collections.Generic;
using System.Text;

namespace TeamEvaluation.DAL.Entities
{
    public class Criteria
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public virtual ICollection<ProjectCriteria> ProjectsCriterias { get; set; } = new List<ProjectCriteria>();
    }
}
