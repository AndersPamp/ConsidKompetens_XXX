using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsidKompetens_Core.Models;
using ConsidKompetens_Web.Models;

namespace ConsidKompetens_Web.Data
{
    public interface IDataProvider
    {
        Task<SpaPageModel> GetSpaPage();
    }
}
