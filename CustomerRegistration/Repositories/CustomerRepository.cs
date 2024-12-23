using CustomerRegistration.Context;
using CustomerRegistration.Models;
using CustomerRegistration.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CustomerRegistration.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.Include(c => c.Addresses).ToList();
        }

        public Customer GetById(int id)
        {
            return _context.Customers.Include(c => c.Addresses).FirstOrDefault(c => c.Id == id);
        }

        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }

        public bool ExistsByEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }
    }
}
