using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UX.Models;
using UX.Repository;
using UX.ViewModels;

namespace UX.Controllers
{    
    public class HomeController : Controller
    {
        #region class variables
        private readonly ILogger<ReasonsController> _logger;
        IReasonRepository _reasonRepository;
        IConfiguration _configuration;
        #endregion

        #region constructors
        public HomeController(ILogger<ReasonsController> logger, IReasonRepository rep, IConfiguration config)
        {
            _logger = logger;
            _reasonRepository = rep;
            _configuration = config;
        }
        #endregion

        public async Task<IActionResult> Index()
        {
            var userReasonsViewModel = await _reasonRepository.GetReasonsWithUser();

            return View(userReasonsViewModel);
        }

        public async Task<IActionResult> ReasonListRazor()
        {
            var userReasonsViewModel = await _reasonRepository.GetReasonsWithUser();

            return View(userReasonsViewModel);
        }

        public ActionResult ReasonListJquery()
        {
            var rlvm = new ReasonListJqueryViewModel();

            rlvm.ApiUri = string.Format("https://{0}",Request.Host.Value);

            return View(rlvm);
        } 

        public ActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
