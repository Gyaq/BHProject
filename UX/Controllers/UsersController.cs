using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DomainObjects.Entities;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using UX.Models;
using System.Net.Http.Json;
using UX.Repository;

namespace UX.Controllers
{
    public class UsersController : Controller
    {
        #region class variables
        private readonly ILogger<ReasonsController> _logger;
        private readonly IUserRepository _userRep;
        #endregion

        #region constructors
        public UsersController(ILogger<ReasonsController> logger, IUserRepository rep)
        {
            _logger = logger;
            _userRep = rep;
        }
        #endregion

        #region endpoints
        // GET: AppUsers
        public async Task<IActionResult> Index()
        {            
            List<AppUserModel> users = await _userRep.GetAllUsers();

            return View(users);
        }        

        /// <summary>
        /// endpoint to retreive a single user that is displayed on the details page.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AppUserModel user;

            user = await _userRep.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }        

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,ImageUrl,JoinDate")] AppUserModel appUser)
        {
            if (ModelState.IsValid)
            {

                await _userRep.CreateUser(appUser);

                return RedirectToAction(nameof(Index));
            }
            return View(appUser);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUser = await _userRep.GetUser(id);
            if (appUser == null)
            {
                return NotFound();
            }
            return View(appUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,ImageUrl,JoinDate")] AppUserModel appUser)
        {
            if (id != appUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    appUser = await _userRep.EditUser(appUser);
                }
                catch (Exception ex)
                {
                    if ((await AppUserExists(appUser.Id))!=true)
                    {
                        return NotFound();
                    }
                    else
                    {
                        _logger.LogError(string.Format("There was an error editing ID:{0}, Error message is:{1}",appUser.Id, ex.Message));
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(appUser);
        }

        // GET: AppUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appUser = await _userRep.GetUser(id);
            if (appUser == null)
            {
                return NotFound();
            }

            return View(appUser);
        }

        // POST: AppUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _userRep.DeleteUser(id);
           
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region helpers
        private async Task<bool> AppUserExists(int id)
        {
            var user = await _userRep.GetUser(id);
            return user.Id == id;
        }
        #endregion
    }
}
