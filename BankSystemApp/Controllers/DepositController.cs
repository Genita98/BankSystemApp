using BankSystem.DataAccess.Repository.IRepository;
using BankSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BankSystemApp.Controllers
{
    public class DepositController : Controller
    {
        private readonly IUnitOfWork _IUnitOFWork;

        public DepositController(IUnitOfWork unitOfWork)
        {
            _IUnitOFWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Deposit> deposits = _IUnitOFWork.Deposit.GetAll().Include(x => x.CurrentAccount).ToList();
            return View(deposits);
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
        public IActionResult Create(Deposit obj)
        {

            if (ModelState.IsValid)
            {
                _IUnitOFWork.Deposit.DepositAmount(obj.AccountId,obj.Amount);
                TempData["success"] = "Current account added successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
