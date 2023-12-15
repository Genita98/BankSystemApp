using BankSystem.DataAccess.Repository;
using BankSystem.DataAccess.Repository.IRepository;
using BankSystem.Models;
using BankSystemApp.DataAcces.Data;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace BankSystemApp.Controllers
{
    public class ClientController : Controller
    {
        private readonly IUnitOfWork _IUnitOFWork;
        public ClientController(IUnitOfWork unitOfWork)
        {
            _IUnitOFWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Client> clientsContext = _IUnitOFWork.Client.GetAll().ToList();
            return View(clientsContext);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Client obj)
        {
            if (ModelState.IsValid)
            {
                _IUnitOFWork.Client.Add(obj);
                _IUnitOFWork.Save();
                TempData["success"] = "Client added successfully!";
                return RedirectToAction("Index");
            }
            return View();
        }






        //edit part


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Client clientFromDb = _IUnitOFWork.Client.Get(u => u.IdCardClient == id);
            if(clientFromDb == null)
            {
                return NotFound();
            } 
            return View(clientFromDb);
        }

        [HttpPost]

        public IActionResult Edit(Client obj)
        {
            if (ModelState.IsValid)
            {
                _IUnitOFWork.Client.Update(obj);
                _IUnitOFWork.Save();
                TempData["success"] = "Client updated successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }





        // end of edit part









        //delete part


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Client clientFromDb = _IUnitOFWork.Client.Get(u => u.IdCardClient == id);
            if (clientFromDb == null)
            {
                return NotFound();
            }
            return View(clientFromDb);
        }

        [HttpPost,ActionName("Delete")]

        public IActionResult DeletePOST(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Client clientFromDb = _IUnitOFWork.Client.Get(u => u.IdCardClient == id);

            if (clientFromDb == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _IUnitOFWork.Client.Remove(clientFromDb);
                _IUnitOFWork.Save();
                TempData["success"] = "Client deleted successfully!";
                return RedirectToAction("Index");
            }
            return View(clientFromDb);
        }





        // end of delete part
    }
}
