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
        IUserRepository _userRepository;
        #endregion

        #region constructors
        public ReasonsController(ILogger<ReasonsController> logger, IReasonRepository reasonRep, IUserRepository userRep)
        {
            _logger = logger;
            _reasonRepository = reasonRep;
            _userRepository = userRep;
        }
        #endregion

        #region endpoints
        public async Task<IActionResult> Index()
        {
            var urvm = await _reasonRepository.GetReasonsWithUser();

            var reasons = urvm.UserReasonsViewModels;

            return View(reasons);
        }

        // GET: AppReasonModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var appReasonModel = await _reasonRepository.GetReason(id.Value);

            var urvm = await _reasonRepository.GetReasonsWithUser();

            var reasons = urvm.UserReasonsViewModels;

            var reasonWithUser = reasons.Where(x => x.appUserModel.Id == id.Value).FirstOrDefault();

            if (reasonWithUser == null)
            {
                return NotFound();
            }

            return View(reasonWithUser);
        }

        // GET: AppReasonModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AppReasonModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReasonTitle,ReasonDescription,SortOrder,DateTime,CreatedBy")] AppReasonModel appReasonModel)
        {
            if (ModelState.IsValid)
            {
                await _reasonRepository.Create(appReasonModel);
                return RedirectToAction(nameof(Index));
            }
            return View(appReasonModel);
        }

        // GET: AppReasonModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appReasonModel = await _reasonRepository.GetReason(id.Value);
            if (appReasonModel == null)
            {
                return NotFound();
            }
            return View(appReasonModel);
        }

        // POST: AppReasonModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReasonTitle,ReasonDescription,SortOrder,DateTime,CreatedBy")] AppReasonModel appReasonModel)
        {
            if (id != appReasonModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _reasonRepository.EditReason(appReasonModel);
                }
                catch
                {

                }
                return RedirectToAction(nameof(Index));
            }
            return View(appReasonModel);
        }

        // GET: AppReasonModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appReasonModel = await _reasonRepository.GetReason(id.Value);
            if (appReasonModel == null)
            {
                return NotFound();
            }

            return View(appReasonModel);
        }

        // POST: AppReasonModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appReasonModel = await _reasonRepository.GetReason(id);
            await _reasonRepository.DeleteReason(id);
            return RedirectToAction(nameof(Index));
        }       
        #endregion

        #region helpers
        

        #endregion
    }
}
