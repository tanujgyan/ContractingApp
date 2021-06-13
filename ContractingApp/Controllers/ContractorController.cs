using ContractingApp.Models;
using ContractingApp.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ContractingApp.Controllers
{
    public class ContractorController : Controller
    {
        private readonly IContractorService contractService;

        public ContractorController(IContractorService contractService)
        {
            this.contractService = contractService;
        }
        public IActionResult Index()
        {
            var contractors = contractService.GetContractors().Result;
            return View(contractors);
        }
        [HttpPost]
        public IActionResult AddNewContractor(Contractor contractor)
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
        [HttpGet]
        public IActionResult GetContractorDetails(int Id)
        {
            var contractor = contractService.GetContractorDetails(Id).Result;
            return View(contractor);
        }
        [HttpGet]
        public IActionResult AddNewContractor()
        {
            return View();
        }
    }
}
