using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ReasonsController : Controller
    {
        #region class variables
        private readonly DataContext _context;
        private readonly ILogger<ReasonsController> _logger;
        #endregion

        #region properties/public variables
        #endregion

        #region constructors
        public ReasonsController(ILogger<ReasonsController> logger, DataContext context)
        {
            _context = context;
            _logger = logger;
        }
        #endregion

        #region endpoints
        [HttpGet]
        public async Task<IEnumerable<AppReason>> GetReasons()
        {
            try
            {
                var appReasons = await _context.Reason.ToListAsync();
                return appReasons;
            }
            catch (Exception ex)
            {
                var error = new AppReason[] { new AppReason() };
                error[0].ErrorMessage = string.Format("There was an erorr getting reasons. ErrorMessage: {0}", ex.Message);
                _logger.LogError(string.Format("There was an erorr getting reasons. ErrorMessage: {0}", ex.Message));
                return error;
            }
        }

        [HttpGet("{id}")]
        public async Task<AppReason> GetReason(int id)
        {
            try
            {
                var appReason = await _context.Reason.FindAsync(id);
                return appReason;
            }
            catch (Exception ex)
            {
                var error = new AppReason();
                error.ErrorMessage = string.Format("There was an erorr getting reason ID:{0}. ErrorMessage: {1}", id, ex.Message);
                _logger.LogError(string.Format("There was an erorr getting reason ID:{0}. ErrorMessage: {1}", id, ex.Message));
                return error;
            }
        }

        [HttpPost]
        public async Task<AppReason> Create([Bind("Id,ReasonTitle,ReasonDescription,SortOrder,DateTime,CreatedBy")] AppReason appReason)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(appReason);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException dex)
                {
                    var error = new AppReason();
                    error.ErrorMessage = string.Format("The entry way not added to the database, there was an erorr. ErrorMessage: {0}", dex.Message);
                    _logger.LogError(string.Format("The entry way not added to the database, there was an erorr. ErrorMessage: {0}", dex.Message));
                    return error;
                }
            }
            return appReason;
        }

        [HttpGet("{id}")]
        public async Task<AppReason> Edit(int id)
        {
            try
            {
                var appReason = await _context.Reason.FindAsync(id);
                if (appReason == null)
                {
                    var error = new AppReason();
                    error.ErrorMessage = string.Format("ID: {0} not not found", id);
                    _logger.LogError(string.Format("ID: {0} not not found", id));
                    return error;
                }

                return appReason;
            }
            catch (Exception ex)
            {
                var error = new AppReason();
                error.ErrorMessage = string.Format("ID: {0} not updated, there was an erorr. ErrorMessage: {1}", id, ex.Message);
                _logger.LogError(string.Format("ID: {0} not updated, there was an erorr. ErrorMessage: {1}", id, ex.Message));
                return error;
            }
        }

        [HttpPost]
        public async Task<AppReason> Edit(int id, [Bind("Id,ReasonTitle,ReasonDescription,SortOrder,DateTime,CreatedBy")] AppReason appReason)
        {
            if (id != appReason.Id)
            {
                appReason.ErrorMessage = string.Format("ID: {0} not found.", id);
                _logger.LogError(string.Format("ID: {0} not found.", id));
                return appReason;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appReason);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    var error = new AppReason();
                    error.ErrorMessage = string.Format("ID: {0} not updated, there was an erorr. ErrorMessage: {1}", id, ex.Message);
                    _logger.LogError(string.Format("ID: {0} not updated, there was an erorr. ErrorMessage: {1}", id, ex.Message));
                    return error;
                }

            }
            return appReason;
        }

        [HttpPost("{id}"), ActionName("Delete")]
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
