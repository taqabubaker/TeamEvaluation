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

        [Display(Name = "Judge Name")]
        public string Name { get; set; }

    }
}
