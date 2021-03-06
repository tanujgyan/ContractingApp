using ContractingApp.Models;
using ContractingApp.Services.Contracts;
using ContractingApp.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ContractingApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IContractorService contractService;

        public HomeController(ILogger<HomeController> logger, IContractorService contractService)
        {
            this.logger = logger;
            this.contractService = contractService;
        }

        public IActionResult Index()
        {
            var contractors = contractService.GetContractors().Result;
            return View(contractors);
        }
        //[HttpPost]
        //public IActionResult AddNewContractor(Contractor contractor)
        //{
        //    var numberOfRecords = contractService.AddContractor(contractor);
        //    if (numberOfRecords> 0)
        //    {
        //        TempData["message"] = "Success";
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
        //[HttpGet]
        //public IActionResult GetContractorDetails(int Id)
        //{
        //    var contractor = contractService.GetContractorDetails(Id).Result;
        //    return View(contractor);
        //}
        //[HttpGet]
        //public IActionResult DeleteRelatedContractors()
        //{
          
        //    ContractorRelationViewModelForDelete vm = null;
        //    if (TempData["vm"] == null)
        //        vm = CreateContractorRelationViewModelForDelete();
        //    else
        //    {
        //        var storedvm = TempData["vm"].ToString();
        //        vm = JsonConvert.DeserializeObject<ContractorRelationViewModelForDelete>(storedvm);
        //    }
        //    return View(vm);
        //}
        
       
        //[HttpGet]
        //public IActionResult AddNewContractor()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult AddNewContractRelation(ContractorRelationViewModel vm)
        //{
        //    if (vm.Contractor1Id == vm.Contractor2Id)
        //    {
        //        ModelState.AddModelError("Contractor1Id", "Contractor1 cannot be same as Contractor2");
        //    }
        //    else if (IsContractorAlreadyRelated(vm.Contractor1Id, vm.Contractor2Id))
        //    {
        //        ModelState.AddModelError("Contractor1Id", "Contractor1 is already related to Contractor2");
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        contractService.AddNewContractRelation(vm.Contractor1Id, vm.Contractor2Id);
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        vm = CreateContractorRelationViewModel();
        //        return View(vm);
        //    }
        //}
        //[HttpGet]
        //public IActionResult AddNewContractRelation()
        //{
        //    var vm = CreateContractorRelationViewModel();
        //    return View(vm);
        //}

        
        //[HttpPost]
        //public IActionResult FetchRelatedData(ContractorRelationViewModelForDelete vm)
        //{
        //    if (vm.Contractor1Id == 0)
        //    {
        //        ModelState.AddModelError("Contractor1Id", "Please select a valid contractor");
        //    }
        //    if(ModelState.IsValid)
        //    {
        //        TempData["selectedValue"] = vm.Contractor1Id;
        //        var relatedContractors = GetRelatedContractors(vm);
        //        vm = CreateDependentContractors(relatedContractors);
        //        TempData["vm"] = JsonConvert.SerializeObject(vm);
        //        return RedirectToAction("DeleteRelatedContractors");
        //    }
        //    else
        //    {
        //        return RedirectToAction("DeleteRelatedContractors");
        //    }
        //}
        //[HttpPost]
        //public IActionResult DeleteRelatedContractors(ContractorRelationViewModelForDelete vm)
        //{
        //    if(vm.Contractor1Id==0 || vm.Contractor2Id==0)
        //    {
        //        ModelState.AddModelError("Contractor2Id", "Please select proper values before proceeding");
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        contractService.TerminateContractorRelation(vm.Contractor1Id, vm.Contractor2Id);
        //        FetchRelatedData(vm);
        //    }
           
        //        vm = CreateContractorRelationViewModelForDelete();
            
        //    return View(vm);
        //}
        //private ContractorRelationViewModel CreateContractorRelationViewModel()
        //{
        //    var contractors = contractService.AddNewContractRelation().Result;
        //    var vm = new ContractorRelationViewModel();
        //    vm.ContractorList = new List<Contractor>();
        //    foreach (var contractor in contractors)
        //    {
        //        vm.ContractorList.Add(new Contractor()
        //        {
        //            Id = contractor.Id,
        //            Name = contractor.Name
        //        });
        //    }
        //    return vm;
        //}
        //private ContractorRelationViewModelForDelete CreateContractorRelationViewModelForDelete()
        //{
        //    var contractors = contractService.AddNewContractRelation().Result;
        //    var vm = new ContractorRelationViewModelForDelete();
        //    vm.ContractorList = new List<Contractor>();
        //    foreach (var contractor in contractors)
        //    {
        //        vm.ContractorList.Add(new Contractor()
        //        {
        //            Id = contractor.Id,
        //            Name = contractor.Name
        //        });
        //    }
        //    return vm;
        //}
        //private ContractorRelationViewModelForDelete CreateDependentContractors(List<int> relatedContractors)
        //{
        //    var contractors = contractService.AddNewContractRelation().Result;
        //    var vm = new ContractorRelationViewModelForDelete();
        //    vm.ContractorList = new List<Contractor>();
        //    vm.DependentContractorList = new List<Contractor>();
        //    foreach (var id in relatedContractors)
        //    {
        //        vm.DependentContractorList.Add(new Contractor()
        //        {
        //            Id = contractors.FirstOrDefault(x => x.Id == id).Id,
        //            Name = contractors.FirstOrDefault(x => x.Id == id).Name
        //        });
        //    }
        //    foreach (var contractor in contractors)
        //    {
        //        vm.ContractorList.Add(new Contractor()
        //        {
        //            Id = contractor.Id,
        //            Name = contractor.Name
        //        });
        //    }
        //    return vm;
        //}
        //private bool IsContractorAlreadyRelated(int contractor1Id, int contractor2Id)
        //{
        //    return contractService.IsContractorAlreadyRelated(contractor1Id, contractor2Id);
        //}
        //private List<int> GetRelatedContractors(ContractorRelationViewModelForDelete vm)
        //{
        //    return contractService.GetRelatedContractors(vm.Contractor1Id);
        //}
    }


}
