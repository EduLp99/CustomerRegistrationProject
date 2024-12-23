using CustomerRegistration.Models;
using CustomerRegistration.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomerRegistration.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IActionResult List()
        {
            var customers = _customerRepository.GetAll();
            return View(customers);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var customer = _customerRepository.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        public IActionResult Create(Customer customer, IFormFile logoFile)
        {
            if (ModelState.IsValid)
            {
                if (logoFile != null)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        logoFile.CopyTo(memoryStream);
                        customer.Logo = memoryStream.ToArray();
                    }
                }

                _customerRepository.Add(customer);
                return RedirectToAction(nameof(List));
            }
            return View(customer);
        }

        public IActionResult Edit(int id)
        {
            var customer = _customerRepository.GetById(id);
            if (customer == null) return NotFound();
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerRepository.Update(customer);
                return RedirectToAction(nameof(List));
            }
            return View(customer);
        }

        public IActionResult Delete(int id)
        {
            var customer = _customerRepository.GetById(id);
            if (customer == null) return NotFound();
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _customerRepository.Delete(id);
            return RedirectToAction(nameof(List));
        }
    }
}
