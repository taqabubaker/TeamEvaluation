using System;
using System.Collections.Generic;
using System.Text;

namespace TeamEvaluation.DAL.Entities
{
    public class Grade
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public int TeamId { get; set; }

        public int JudgeId { get; set; }

        public int CriteriaId { get; set; }

        public int Value { get; set; }


        public virtual Project Project { get; set; }

       // public virtual Team Team { get; set; }

        //public virtual Judge Judge { get; set; }

        public virtual Criteria Criteria { get; set; }
    }
}
