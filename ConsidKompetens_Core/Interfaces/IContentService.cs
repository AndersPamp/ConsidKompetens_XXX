using System.Collections.Generic;
using System.Threading.Tasks;
using ConsidKompetens_Core.Models;

namespace ConsidKompetens_Core.Interfaces
{
    public interface IContentService
    {
        Task<SpaPageModel> SpaPage();
        Task<SettingsModel> Settings();
        Task<IDictionary<string, string>> Dictionary();
    }
}
