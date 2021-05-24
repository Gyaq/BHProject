using System.Collections.Generic;
using System.Threading.Tasks;
using UX.Models;
using UX.ViewModels;

namespace UX.Repository
{
    public interface IReasonRepository
    {
        public Task<UserReasonsViewModel> GetReasonsWithUser();

        public Task<List<AppReasonModel>> GetAllReasons();
        
        public Task<AppReasonModel> GetReason(int id);

        public Task<AppReasonModel> Create(AppReasonModel appReasonModel);

        public Task DeleteReason(int id);

        public Task<AppReasonModel> EditReason(AppReasonModel appReason);

    }
}
