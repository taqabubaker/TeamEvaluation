using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public List<Team> Teams { get; set; }


        public virtual ICollection<Judge> Judges { get; set; }


        [NotMapped]
        public int JudgesCount
        {
            get
            {
                return Judges?.Count ?? 0;
            }
        }

        [NotMapped]
        public Dictionary<string, decimal> Averages
        {
            get
            {
                var avgTeams = new Dictionary<string, decimal>();

                avgTeams.Add("team 1", 87.3M);
                avgTeams.Add("team 2", 74.8M);
                avgTeams.Add("team 3", 98M);
                return avgTeams;
            }
        }
    }
}
