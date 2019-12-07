﻿using System;
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
        [Display(Name = "Semester")]
        public int SemesterId { get; set; }
        public Semester Semester { get; set; }
        public List<Team> Teams { get; set; }
        public virtual ICollection<ProjectCriteria> ProjectsCriterias { get; set; } = new List<ProjectCriteria>();


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
        public Dictionary<string, Dictionary<string, decimal>> Averages
        {
            get
            {
                var criterias = new Dictionary<string, Dictionary<string, decimal>>();
                for (var x = 0; x < 4; x++)
                {
                    var avgTeams = new Dictionary<string, decimal>();

                    avgTeams.Add("team 1", 87.3M);
                    avgTeams.Add("team 2", 74.8M);
                    avgTeams.Add("team 3", 98M);
                    criterias.Add($"criteria_{x }", avgTeams);
                }
                return criterias;
            }
        }
    }
}
