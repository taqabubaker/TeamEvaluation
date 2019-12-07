using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeamEvaluation.DAL.Entities
{
    public class Judge
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int ProjectId { get; set; }

        public decimal Evaluation { get; set; }
        public virtual Project Project { get; set; }


    }
}
