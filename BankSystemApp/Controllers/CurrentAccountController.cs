﻿using BankSystem.DataAccess.Repository.IRepository;
using BankSystem.Models;
using BankSystemApp.DataAcces.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BankSystemApp.Controllers
{
    public class CurrentAccountController : Controller
    {

        private readonly IUnitOfWork _IUnitOFWork;

        public CurrentAccountController(IUnitOfWork unitOfWork)
        {
            _IUnitOFWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<CurrentAccount> currentAccounts = _IUnitOFWork.CurrentAccount.GetAll().Include(x => x.Client).ToList();


            return View(currentAccounts); 
        }
        public IActionResult Create()
        {
            IQueryable<SelectListItem> ClientList = _IUnitOFWork.Client.GetAll().Select(u => new SelectListItem
            {
                Text = u.IdCardClient.ToString(),
                Value = u.ClientId.ToString()
            });
            ViewBag.ClientList = ClientList;
            return View();
        }

        [HttpPost]
        public IActionResult Create(CurrentAccount obj)
        {
           
            if (ModelState.IsValid)
            {
                _IUnitOFWork.CurrentAccount.Add(obj);
                _IUnitOFWork.Save();
                TempData["success"] = "Current account added successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }






        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            IQueryable<SelectListItem> ClientList = _IUnitOFWork.Client.GetAll().Select(u => new SelectListItem
            {
                Text = u.IdCardClient.ToString(),
                Value = u.ClientId.ToString()
            });
            ViewBag.ClientList = ClientList;

            CurrentAccount currentAccountFromDb = _IUnitOFWork.CurrentAccount.Get(u => u.AccountId == Id);
            if (currentAccountFromDb == null)
            {
                return NotFound();
            }
            return View(currentAccountFromDb);
        }

        [HttpPost]

        public IActionResult Edit(CurrentAccount obj)
        {
            if (ModelState.IsValid)
            {
                _IUnitOFWork.CurrentAccount.Update(obj);
                _IUnitOFWork.Save();
                TempData["success"] = "Current account updated successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);



        }





        //delete part


        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            IQueryable<SelectListItem> ClientList = _IUnitOFWork.Client.GetAll().Select(u => new SelectListItem
            {
                Text = u.IdCardClient.ToString(),
                Value = u.ClientId.ToString()
            });
            ViewBag.ClientList = ClientList;
            CurrentAccount currentAccount = _IUnitOFWork.CurrentAccount.Get(u => u.AccountId == Id);
            if (currentAccount == null)
            {
                return NotFound();
            }
            return View(currentAccount);
        }

        [HttpPost, ActionName("Delete")]

        public IActionResult DeletePOST(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            CurrentAccount currentAccount = _IUnitOFWork.CurrentAccount.Get(u => u.AccountId == Id);

            if (currentAccount == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _IUnitOFWork.CurrentAccount.Remove(currentAccount);
                _IUnitOFWork.Save();
                TempData["success"] = "Current account deleted successfully!";
                return RedirectToAction("Index");
            }
            return View(currentAccount);
        }





        // end of delete part

    }
}
