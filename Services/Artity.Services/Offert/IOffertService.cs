using Artity.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Artity.Services.Offert
{
    public interface IOffertService
    {
         IEnumerable<OffertTypeServiceModel> GetAllOffertTypes();

         Task<bool> CreateOffert(string title, int type, string message, string features, bool contract, string userId, string tel, decimal price, string town);
    }
}
