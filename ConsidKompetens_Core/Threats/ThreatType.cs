using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ConsidKompetens_Core.Models;

namespace ConsidKompetens_Core.Threats
{
    public class ThreatType:BaseEntity
    {
        public ThreatType()
        {
            
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Threat> Threats { get; set; }
    }
}
