using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ConsidKompetens_Core.Models;

namespace ConsidKompetens_Core.Threats
{
    public class Status:BaseEntity
    {
        public Status()
        {

        }
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        [StringLength(250)] 
        public string Description { get; set; }

        public virtual ICollection<Threat> Threats{ get; set; }
    }
}
