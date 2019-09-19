namespace Artity.Services.Data.Offert
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Artity.Services.ServiceModels;

    public interface IOffertService
    {
        IEnumerable<OffertTypeServiceModel> GetAllOffertTypes();

        IEnumerable<TViewModel> GetAllOfferts<TViewModel>(string artistid);

        TViewModel GetOffert<TViewModel>(string artistid);

        Task<bool> CreateOffert(string title, int type, string message, string features, bool contract, string userId, string tel, decimal price, string town);

        Task<bool> EditOffert(string id, string title, int type, string message, string features, bool contract, string userId, string tel, decimal price, string town);

        Task<bool> DeleteOffert(string id);
    }
}
