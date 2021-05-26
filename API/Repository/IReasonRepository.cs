using API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Repository
{
    public interface IReasonRepository
    {
        public Task<IEnumerable<AppReasonModel>> GetReasons();

        public Task<AppReasonModel> GetReason(int id);

        public Task<AppReasonModel> Create(AppReasonModel appReason);

        public Task<AppReasonModel> Edit(AppReasonModel appReason);

        public Task<int> DeleteReason(int id);
    }
}