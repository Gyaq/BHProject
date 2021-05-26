using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class ReasonRepository:IReasonRepository
    {
        #region class variables
        private readonly DataContext _context;
        private readonly ILogger<ReasonRepository> _logger;
        #endregion

        #region properties/public variables
        #endregion

        #region constructors
        public ReasonRepository(ILogger<ReasonRepository> logger, DataContext context)
        {
            _context = context;
            _logger = logger;
        }
        #endregion

        #region endpoints
      
        public async Task<IEnumerable<AppReasonModel>> GetReasons()
        {
            try
            {
                var appReasons = await _context.Reason.ToListAsync();
                return appReasons;
            }
            catch (Exception ex)
            {
                var error = new AppReasonModel[] { new AppReasonModel() };
                error[0].ErrorMessage = string.Format("There was an erorr getting reasons. ErrorMessage: {0}", ex.Message);
                _logger.LogError(string.Format("There was an erorr getting reasons. ErrorMessage: {0}", ex.Message));
                return error;
            }
        }


        public async Task<AppReasonModel> GetReason(int id)
        {
            try
            {
                var appReason = await _context.Reason.FindAsync(id);
                return appReason;
            }
            catch (Exception ex)
            {
                var error = new AppReasonModel();
                error.ErrorMessage = string.Format("There was an erorr getting reason ID:{0}. ErrorMessage: {1}", id, ex.Message);
                _logger.LogError(string.Format("There was an erorr getting reason ID:{0}. ErrorMessage: {1}", id, ex.Message));
                return error;
            }
        }


        public async Task<AppReasonModel> Create(AppReasonModel appReason)
        {

            try
            {
                _context.Add(appReason);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var error = new AppReasonModel();
                error.ErrorMessage = string.Format("The entry way not added to the database, there was an erorr. ErrorMessage: {0}", ex.Message);
                _logger.LogError(string.Format("The entry way not added to the database, there was an erorr. ErrorMessage: {0}", ex.Message));
                return error;
            }

            return appReason;
        }

        public async Task<AppReasonModel> Edit(AppReasonModel appReason)
        {
            if (id != appReason.Id)
            {
                appReason.ErrorMessage = string.Format("ID: {0} not found.", id);
                _logger.LogError(string.Format("ID: {0} not found.", id));
                return appReason;
            }

            try
            {
                _context.Update(appReason);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var error = new AppReasonModel();
                error.ErrorMessage = string.Format("ID: {0} not updated, there was an erorr. ErrorMessage: {1}", id, ex.Message);
                _logger.LogError(string.Format("ID: {0} not updated, there was an erorr. ErrorMessage: {1}", id, ex.Message));
                return error;
            }

            return appReason;
        }

       
        public async Task<int> DeleteReason(int id)
        {
            var appReason = await _context.Reason.FindAsync(id);
            _context.Reason.Remove(appReason);
            var numDel = await _context.SaveChangesAsync();
            return numDel;
        }

        #endregion

        #region helper functions    
        #endregion
    }
}
