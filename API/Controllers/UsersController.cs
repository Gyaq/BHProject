using API.Entities;
using API.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http.Extensions;
using System;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UsersController : ControllerBase
    {
        #region class variables
        private readonly DataContext _context;
        private readonly ILogger<UsersController> _logger;
        #endregion

        #region constructors
        public UsersController(ILogger<UsersController> logger, DataContext context)
        {
            _context = context;
            _logger = logger;
        }
        #endregion

        #region endpoints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }

        [HttpGet("{id}")]
        public async Task<AppUser> Edit(int id)
        {
            try
            {
                var appUser = await _context.Users.FindAsync(id);
                if (appUser == null)
                {
                    var error = new AppUser
                    {
                        ErrorMessage = string.Format("ID: {0} not not found", id)
                    };

                    _logger.LogError(string.Format("ID: {0} not not found", id));
                    return error;
                }

                return appUser;
            }
            catch (Exception ex)
            {
                var error = new AppUser
                {
                    ErrorMessage = string.Format("ID: {0} not updated, there was an erorr. ErrorMessage: {1}", id, ex.Message)
                };

                _logger.LogError(string.Format("ID: {0} not updated, there was an erorr. ErrorMessage: {1}", id, ex.Message));
                return error;
            }
        }

        [HttpPost]
        public async Task<AppUser> Edit([Bind("Id,FirstName,LastName,ImageUrl,JoinDate")] AppUser appUser)
        { 
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appUser);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    var error = new AppUser();
                    error.ErrorMessage = string.Format("ID: {0} not updated, there was an erorr. ErrorMessage: {1}", appUser.Id, ex.Message);
                    _logger.LogError(string.Format("ID: {0} not updated, there was an erorr. ErrorMessage: {1}", appUser.Id, ex.Message));
                    return error;
                }
            }
            return appUser;
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,ImageUrl,JoinDate")] AppUser appUser)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(appUser);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    var error = new AppUser
                    {
                        ErrorMessage = string.Format("The entry was not added to the database, there was an erorr. ErrorMessage: {0}", ex.Message)
                    };

                    _logger.LogError(string.Format("The entry was not added to the database, there was an erorr. ErrorMessage: {0}", ex.Message));
                    return Problem(string.Format("The entry was not added to the database, there was an erorr. ErrorMessage: {0}", ex.Message));
                }
            }

            // I used this return method to show another way to get this done.
            return Created(new Uri(Request.GetEncodedUrl()+"/"+appUser.Id), appUser);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var appUser = await _context.Users.FindAsync(id);
            _context.Users.Remove(appUser);

            var numDel = await _context.SaveChangesAsync();

            if (numDel == 0)
            {
                _logger.LogError(string.Format("Delete failed for ID: {0}", id));
                return BadRequest();
            }
            else if (numDel > 1)
            {
                _logger.LogError(string.Format("{0} Rows delected for ID: {0}", numDel, id));
                return BadRequest();
            }

            return Ok();
        }
        #endregion

        #region helper functions    
        #endregion
    }
}
