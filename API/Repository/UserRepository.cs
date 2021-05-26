using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class UserRepository:IUserRepository
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

        public async Task<ActionResult<IEnumerable<AppUserModel>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<ActionResult<AppUserModel>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }

        public async Task<AppUserModel> Edit([Bind("Id,FirstName,LastName,ImageUrl,JoinDate")] AppUserModel appUser)
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
                    var error = new AppUserModel();
                    error.ErrorMessage = string.Format("ID: {0} not updated, there was an erorr. ErrorMessage: {1}", appUser.Id, ex.Message);
                    _logger.LogError(string.Format("ID: {0} not updated, there was an erorr. ErrorMessage: {1}", appUser.Id, ex.Message));
                    return error;
                }
            }
            return appUser;
        }


        public async Task<AppUserModel> Create(AppUserModel appUser)
        {
                try
                {
                    _context.Add(appUser);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    var error = new AppUserModel
                    {
                        ErrorMessage = string.Format("The entry was not added to the database, there was an erorr. ErrorMessage: {0}", ex.Message)
                    };

                    _logger.LogError(string.Format("The entry was not added to the database, there was an erorr. ErrorMessage: {0}", ex.Message));
                    return Problem(string.Format("The entry was not added to the database, there was an erorr. ErrorMessage: {0}", ex.Message));
                }
           

            // I used this return method to show another way to get this done.
            return Created(new Uri(Request.GetEncodedUrl() + "/" + appUser.Id), appUser);
        }

        public async Task<int> Delete(int id)
        {
            var appUser = await _context.Users.FindAsync(id);
            _context.Users.Remove(appUser);

            return await _context.SaveChangesAsync();            
        }
        #endregion

        #region helper functions    
        #endregion
    }
}
