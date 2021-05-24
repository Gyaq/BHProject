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

namespace UX.Controllers
{
    public class UsersController : Controller
    {
        #region class variables
        private readonly ILogger<ReasonsController> _logger;
        private IConfiguration _config;
        private string _apiAddy;
        #endregion

        #region constructors
        public UsersController(ILogger<ReasonsController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            _apiAddy = _config["ApiUri"];
        }
        #endregion

        #region endpoints
        // GET: AppUsers
        public async Task<IActionResult> Index()
        {            
            List<AppUserModel> users = await GetUsersFromApi();

            return View(users);
        }        

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AppUserModel user;

            user = await GetUserFromApi(id);

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
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,ImageUrl,JoinDate")] AppUser appUser)
        {
            if (ModelState.IsValid)
            {

                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.PostAsJsonAsync(string.Format("{0}Users/Create", _apiAddy), appUser))
                    {
                        response.EnsureSuccessStatusCode();
                    }
                }

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

            var appUser = await GetUserFromApi(id);
            if (appUser == null)
            {
                return NotFound();
            }
            return View(appUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,ImageUrl,JoinDate")] AppUser appUser)
        {
            if (id != appUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    using (var httpClient = new HttpClient())
                    {
                        using (var response = await httpClient.PostAsJsonAsync(string.Format("{0}Users/Edit", _apiAddy), appUser))
                        {
                            response.EnsureSuccessStatusCode();
                        }
                    }
                }
                catch (Exception ex)
                {
                    if ((await AppUserExists(appUser.Id))!=true)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
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

            var appUser = await GetUserFromApi(id);
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
            var response = string.Empty;
            using (var client = new HttpClient())
            {
                var responseMessage = await client.DeleteAsync(string.Format("{0}Users/Delete/{1}", _apiAddy, id));
            }
           
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region helpers
        private async Task<bool> AppUserExists(int id)
        {
            var bob = await GetUserFromApi(id);
            return bob.Id == id;
        }

        private async Task<List<AppUserModel>> GetUsersFromApi()
        {
            List<AppUserModel> users = new List<AppUserModel>();
            using (var httpClient = new HttpClient())
            {
                using (var usersResponse = await httpClient.GetAsync(string.Format("{0}Users/GetUsers", _apiAddy)))
                {
                    string usersData = await usersResponse.Content.ReadAsStringAsync();
                    users = JsonConvert.DeserializeObject<List<AppUserModel>>(usersData);
                }
            }

            return users;
        }

        private async Task<AppUserModel> GetUserFromApi(int? id)
        {
            AppUserModel user = new AppUserModel();

            using (var httpClient = new HttpClient())
            {
                using (var usersResponse = await httpClient.GetAsync(string.Format("{0}Users/GetUser/{1}", _apiAddy, id)))
                {
                    string usersData = await usersResponse.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<AppUserModel>(usersData);
                }
            }

            return user;
        }
        #endregion
    }
}
