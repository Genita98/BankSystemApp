using BankSystem.DataAccess.Repository;
using BankSystem.DataAccess.Repository.IRepository;
using BankSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BankSystemApp.Controllers
{
    public class WithdrawalController : Controller
    {
        private readonly IUnitOfWork _IUnitOFWork;

        public WithdrawalController (IUnitOfWork unitOfWork)
        {
            _IUnitOFWork= unitOfWork;
        }
        public IActionResult Index()
        {
            List<Withdrawal> withdrawal = _IUnitOFWork.Withdrawal.GetAll().Include(x => x.CurrentAccount).ToList();
            return View(withdrawal);
        }

        public IActionResult Create()
        {
            IQueryable<SelectListItem> CurrentAccountsList = _IUnitOFWork.CurrentAccount.GetAll().Select(u => new SelectListItem
            {
                Text = u.CurrentAccountNumber.ToString(),
                Value = u.AccountId.ToString()
            });
            ViewBag.CurrentAccountsList = CurrentAccountsList;
            return View();
        }


        [HttpPost]
        public IActionResult Create(Withdrawal obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _IUnitOFWork.Withdrawal.WithdrawalAmount(obj.AccountId, obj.Amount);
                    TempData["success"] = "Withdrawal successful!";
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch (InvalidOperationException ex)
            {
                // Handle the exception, you can add an error message to TempData
                TempData["error"] = ex.Message;
                return RedirectToAction("Create");

            }
        }
    }
}
