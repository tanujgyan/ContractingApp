using ContractingApp.Models;
using ContractingApp.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;


namespace ContractingApp.Controllers
{
    public class ContractorController : Controller
    {
        private readonly IContractorService contractService;
        private readonly ILogger<ContractorController> logger;

        public ContractorController(IContractorService contractService, ILogger<ContractorController> logger)
        {
            this.contractService = contractService;
            this.logger = logger;
        }
        public IActionResult Index()
        {
            try
            {
                var contractors = contractService.GetContractors().Result;
                return View(contractors);
            }
            catch (Exception ex)
            {
                logger.LogInformation("An error occured. Please find below the error details.");
                logger.LogError("Stack Trace {0}", ex.StackTrace);
                logger.LogError("Error Message {0}", ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }
        [HttpPost]
        public IActionResult AddNewContractor(Contractor contractor)
        {
            try
            {
                var numberOfRecords = contractService.AddContractor(contractor);
                if (numberOfRecords > 0)
                {
                    TempData["message"] = "Success";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                logger.LogInformation("An error occured. Please find below the error details.");
                logger.LogError("Stack Trace {0}", ex.StackTrace);
                logger.LogError("Error Message {0}", ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }
        [HttpGet]
        public IActionResult GetContractorDetails(int Id)
        {
            try
            {
                var contractor = contractService.GetContractorDetails(Id).Result;
                return View(contractor);
            }
            catch (Exception ex)
            {
                logger.LogInformation("An error occured. Please find below the error details.");
                logger.LogError("Stack Trace {0}", ex.StackTrace);
                logger.LogError("Error Message {0}", ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }
        [HttpGet]
        public IActionResult AddNewContractor()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                logger.LogInformation("An error occured. Please find below the error details.");
                logger.LogError("Stack Trace {0}", ex.StackTrace);
                logger.LogError("Error Message {0}", ex.Message);
                return RedirectToAction("Index", "Error");
            }
        }
    }
}
