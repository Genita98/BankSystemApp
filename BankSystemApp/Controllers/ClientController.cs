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
        private readonly IClientRepository _ClientRepo;
        public ClientController(IClientRepository db)
        {
            _ClientRepo = db;
        }
        public IActionResult Index()
        {
            List<Client> clientsContext = _ClientRepo.GetAll().ToList();
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
                _ClientRepo.Add(obj);
                _ClientRepo.Save();
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

            Client clientFromDb = _ClientRepo.Get(u => u.Id == id);
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
                _ClientRepo.Update(obj);
                _ClientRepo.Save();
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

            Client clientFromDb = _ClientRepo.Get(u => u.Id == id);
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

            Client clientFromDb = _ClientRepo.Get(u => u.Id == id);

            if (clientFromDb == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _ClientRepo.Remove(clientFromDb);
                _ClientRepo.Save();
                TempData["success"] = "Client deleted successfully!";
                return RedirectToAction("Index");
            }
            return View(clientFromDb);
        }





        // end of delete part
    }
}
