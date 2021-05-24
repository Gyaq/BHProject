using System.Threading.Tasks;
using UX.ViewModels;

namespace UX.Repository
{
    public interface IReasonRepository
    {
        public Task<UserReasonsViewModel> GetReasonsWithUser();
    }
}
