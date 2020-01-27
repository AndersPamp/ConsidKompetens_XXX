using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace ConsidKompetens_Core.Models
{
    public class CompetenceModel:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ImageModel Icon { get; set; }
    }
}
