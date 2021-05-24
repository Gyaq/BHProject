using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UX.Models;
using UX.ViewModels;
using Microsoft.Extensions.Configuration;
using UX.Repository;

namespace UX.Controllers
{
    public class ReasonsController : Controller
    {
        #region class variables
        private readonly ILogger<ReasonsController> _logger;
        IReasonRepository _reasonRepository;
        #endregion

        #region constructors
        public ReasonsController(ILogger<ReasonsController> logger, IReasonRepository rep)
        {
            _logger = logger;
            _reasonRepository = rep;
        }
        #endregion

        #region endpoints
        public async Task<IActionResult> Index()
        {
            var userReasonsViewModel = await _reasonRepository.GetReasonsWithUser();

            return View(userReasonsViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #endregion
    }
}
