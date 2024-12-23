using CustomerRegistration.Models;
using CustomerRegistration.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomerRegistration.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddressRepository _addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public IActionResult List()
        {
            var addresses = _addressRepository.GetAll();
            return View(addresses);
        }
        public IActionResult Details(int id)
        {
            var address = _addressRepository.GetById(id);
            if (address == null)
            {
                return NotFound();
            }
            return View(address);
        }
        public IActionResult Create()
        {
            return View();
        }

        // POST: Address/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Address address)
        {
            if (ModelState.IsValid)
            {
                _addressRepository.Add(address);
                return RedirectToAction(nameof(List));
            }
            return View(address);
        }

        public IActionResult Edit(int id)
        {
            var address = _addressRepository.GetById(id);
            if (address == null)
            {
                return NotFound();
            }
            return View(address);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Address address)
        {
            if (ModelState.IsValid)
            {
                _addressRepository.Update(address);
                return RedirectToAction(nameof(List));
            }
            return View(address);
        }

        public IActionResult Delete(int id)
        {
            var address = _addressRepository.GetById(id);
            if (address == null)
            {
                return NotFound();
            }
            return View(address);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var address = _addressRepository.GetById(id);
            if (address != null)
            {
                _addressRepository.Delete(id);
            }
            return RedirectToAction(nameof(List));
        }
    }
}
