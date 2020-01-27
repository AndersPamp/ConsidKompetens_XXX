using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.Interfaces;
using ConsidKompetens_Core.Models;

namespace ConsidKompetens_Services.Contentful
{
    public class ContentfulService : IContentService
    {
        public Task<SpaPageModel> SpaPage()
        {
            throw new System.NotImplementedException();
        }

        public Task<SettingsModel> Settings()
        {
            throw new System.NotImplementedException();
        }

        public Task<IDictionary<string, string>> Dictionary()
        {
            throw new System.NotImplementedException();
        }
    }
}