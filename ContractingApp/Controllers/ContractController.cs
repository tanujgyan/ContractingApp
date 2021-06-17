using ContractingApp.Models;
using ContractingApp.Services.Contracts;
using ContractingApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContractingApp.Controllers
{
    public class ContractController : Controller
    {
        private readonly IContractorService contractService;
        private readonly ILogger<ContractController> logger;

        public ContractController(IContractorService contractService, ILogger<ContractController> logger)
        {
            this.contractService = contractService;
            this.logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult DeleteRelatedContractors()
        {
            ContractorRelationViewModelForDelete vm = null;
            
            try
            {
                if (TempData["vm"] == null)
                    vm = CreateContractorRelationViewModelForDelete();
                else
                {
                    var storedvm = TempData["vm"].ToString();
                    vm = JsonConvert.DeserializeObject<ContractorRelationViewModelForDelete>(storedvm);
                }
            }
            catch(Exception ex)
            {
                logger.LogInformation("An error occured while terminating contracts. Please find below the error details.");
                logger.LogError("Stack Trace {0}", ex.StackTrace);
                logger.LogError("Error Message {0}", ex.Message);
                return RedirectToAction("Index", "Error");
            }
            return View(vm);
        }
        [HttpPost]
        public IActionResult AddNewContractRelation(ContractorRelationViewModel vm)
        {
            try
            {
                if (vm.Contractor1Id == vm.Contractor2Id)
                {
                    ModelState.AddModelError("Contractor1Id", "Contractor1 cannot be same as Contractor2");
                }
                else if (IsContractorAlreadyRelated(vm.Contractor1Id, vm.Contractor2Id))
                {
                    ModelState.AddModelError("Contractor1Id", "Contractor1 is already related to Contractor2");
                }
                if (ModelState.IsValid)
                {
                    var rows = contractService.AddNewContractRelation(vm.Contractor1Id, vm.Contractor2Id);
                    if (rows > 0)
                    {
                        TempData["message"] = "success";
                    }

                }

                vm = CreateContractorRelationViewModel();
                return View(vm);
            }
            catch (Exception ex)
            {
                logger.LogInformation("An error occured while adding contracts. Please find below the error details.");
                logger.LogError("Stack Trace {0}", ex.StackTrace);
                logger.LogError("Error Message {0}", ex.Message);
                return RedirectToAction("Index", "Error");
            }

        }
        [HttpGet]
        public IActionResult AddNewContractRelation()
        {
            try
            {
                var vm = CreateContractorRelationViewModel();
                return View(vm);
            }
            catch (Exception ex)
            {
                logger.LogInformation("An error occured while loading add contracts. Please find below the error details.");
                logger.LogError("Stack Trace {0}", ex.StackTrace);
                logger.LogError("Error Message {0}", ex.Message);
                return RedirectToAction("Index", "Error");
            }

        }
        [HttpPost]
        public IActionResult FetchRelatedData(ContractorRelationViewModelForDelete vm)
        {
            try
            {
                if (vm.Contractor1Id == 0)
                {
                    ModelState.AddModelError("Contractor1Id", "Please select a valid contractor");
                }
                if (ModelState.IsValid)
                {
                    TempData["selectedValue"] = vm.Contractor1Id;
                    var relatedContractors = GetRelatedContractors(vm);
                    vm = CreateDependentContractors(relatedContractors);
                    TempData["vm"] = JsonConvert.SerializeObject(vm);
                    return RedirectToAction("DeleteRelatedContractors");
                }
                else
                {
                    return RedirectToAction("DeleteRelatedContractors");
                }
            }
            catch (Exception ex)
            {
                logger.LogInformation("An error occured while fetching related contracts. Please find below the error details.");
                logger.LogError("Stack Trace {0}", ex.StackTrace);
                logger.LogError("Error Message {0}", ex.Message);
                return RedirectToAction("Index", "Error");
            }

        }
        [HttpPost]
        public IActionResult DeleteRelatedContractors(ContractorRelationViewModelForDelete vm)
        {
            try
            {
                if (vm.Contractor1Id == 0 || vm.Contractor2Id == 0)
                {
                    ModelState.AddModelError("Contractor2Id", "Please select proper values before proceeding");
                }
                if (ModelState.IsValid)
                {
                    var rows = contractService.TerminateContractorRelation(vm.Contractor1Id, vm.Contractor2Id);
                    FetchRelatedData(vm);
                    if (rows > 0)
                    {
                        TempData["message"] = "success";
                    }
                }

                vm = CreateContractorRelationViewModelForDelete();

                return View(vm);
            }
            catch (Exception ex)
            {
                logger.LogInformation("An error occured while terminating contracts. Please find below the error details.");
                logger.LogError("Stack Trace {0}", ex.StackTrace);
                logger.LogError("Error Message {0}", ex.Message);
                return RedirectToAction("Index", "Error");
            }

        }
        [HttpGet]
        public IActionResult GetShortestContractingChain()
        {
            try
            {
                var vm = CreateContractorRelationViewModel();
                return View(vm);
            }
            catch (Exception ex)
            {
                logger.LogInformation("An error occured while getting shortest contract chain. Please find below the error details.");
                logger.LogError("Stack Trace {0}", ex.StackTrace);
                logger.LogError("Error Message {0}", ex.Message);
                return RedirectToAction("Index", "Error");
            }

        }
        [HttpPost]
        public IActionResult GetShortestContractingChain(ContractorRelationViewModel vm)
        {
            try
            {
                int contractor1Id = vm.Contractor1Id;
                int contractor2Id = vm.Contractor2Id;
                if (vm.Contractor1Id == vm.Contractor2Id)
                {
                    ModelState.AddModelError("Contractor1Id", "Contractor1 cannot be same as Contractor2");
                }

                vm = CreateContractorRelationViewModel();
                if (ModelState.IsValid)
                {
                    vm.ShortestContractingChain = contractService.GetShortestContractingChain(contractor1Id, contractor2Id);
                    vm.IsShortestChainCalculated = true;
                }

                return View(vm);
            }
            catch (Exception ex)
            {
                logger.LogInformation("An error occured while getting results for shortest contract chain. Please find below the error details.");
                logger.LogError("Stack Trace {0}", ex.StackTrace);
                logger.LogError("Error Message {0}", ex.Message);
                return RedirectToAction("Index", "Error");
            }


        }
        private ContractorRelationViewModel CreateContractorRelationViewModel()
        {
            var vm = new ContractorRelationViewModel();
            try
            {
                var contractors = contractService.AddNewContractRelation().Result;
                
                vm.ContractorList = new List<Contractor>();
                foreach (var contractor in contractors)
                {
                    vm.ContractorList.Add(new Contractor()
                    {
                        Id = contractor.Id,
                        Name = contractor.Name
                    });
                }
                
            }
            catch (Exception ex)
            {
                logger.LogInformation("An error occured. Please find below the error details.");
                logger.LogError("Stack Trace {0}", ex.StackTrace);
                logger.LogError("Error Message {0}", ex.Message);
            }
            return vm;
        }
        private ContractorRelationViewModelForDelete CreateContractorRelationViewModelForDelete()
        {
            var vm = new ContractorRelationViewModelForDelete();
            try
            {
                var contractors = contractService.AddNewContractRelation().Result;
                vm.ContractorList = new List<Contractor>();
                foreach (var contractor in contractors)
                {
                    vm.ContractorList.Add(new Contractor()
                    {
                        Id = contractor.Id,
                        Name = contractor.Name
                    });
                }
            }
            catch (Exception ex)
            {
                logger.LogInformation("An error occured. Please find below the error details.");
                logger.LogError("Stack Trace {0}", ex.StackTrace);
                logger.LogError("Error Message {0}", ex.Message);
            }
            return vm;
        }
        private ContractorRelationViewModelForDelete CreateDependentContractors(List<int> relatedContractors)
        {
            var vm = new ContractorRelationViewModelForDelete();
            try
            {
                var contractors = contractService.AddNewContractRelation().Result;
                vm.ContractorList = new List<Contractor>();
                vm.DependentContractorList = new List<Contractor>();
                foreach (var id in relatedContractors)
                {
                    vm.DependentContractorList.Add(new Contractor()
                    {
                        Id = contractors.FirstOrDefault(x => x.Id == id).Id,
                        Name = contractors.FirstOrDefault(x => x.Id == id).Name
                    });
                }
                foreach (var contractor in contractors)
                {
                    vm.ContractorList.Add(new Contractor()
                    {
                        Id = contractor.Id,
                        Name = contractor.Name
                    });
                }
            }
            catch (Exception ex)
            {
                logger.LogInformation("An error occured. Please find below the error details.");
                logger.LogError("Stack Trace {0}", ex.StackTrace);
                logger.LogError("Error Message {0}", ex.Message);
            }
            return vm;
        }
        private bool IsContractorAlreadyRelated(int contractor1Id, int contractor2Id)
        {
            try
            {
                return contractService.IsContractorAlreadyRelated(contractor1Id, contractor2Id);
            }
            catch (Exception ex)
            {
                logger.LogInformation("An error occured. Please find below the error details.");
                logger.LogError("Stack Trace {0}", ex.StackTrace);
                logger.LogError("Error Message {0}", ex.Message);
                return false;
            }
        }
        private List<int> GetRelatedContractors(ContractorRelationViewModelForDelete vm)
        {
            try
            {
                return contractService.GetRelatedContractors(vm.Contractor1Id);
            }
            catch (Exception ex)
            {
                logger.LogInformation("An error occured. Please find below the error details.");
                logger.LogError("Stack Trace {0}", ex.StackTrace);
                logger.LogError("Error Message {0}", ex.Message);
                return null;
            }
        }
    }
}
