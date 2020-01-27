using System.Collections.Generic;

namespace ConsidKompetens_Core.Models
{
    public class EmployeeUserModel:BaseEntity
    {
        public string AboutMe { get; set; }
        public ImageModel ProfileImage { get; set; }
        public List<CompetenceModel> Competences { get; set; }
    }
}
