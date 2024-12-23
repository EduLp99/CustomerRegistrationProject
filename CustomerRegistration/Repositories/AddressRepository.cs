using CustomerRegistration.Context;
using CustomerRegistration.Models;
using CustomerRegistration.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CustomerRegistration.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDbContext _context;

        public AddressRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Address> GetAll()
        {
            return _context.Addresses.Include(a => a.Customer).ToList();
        }

        public Address GetById(int id)
        {
            return _context.Addresses.Include(a => a.Customer).FirstOrDefault(a => a.Id == id);
        }

        public void Add(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
        }

        public void Update(Address address)
        {
            _context.Addresses.Update(address);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var address = _context.Addresses.Find(id);
            if (address != null)
            {
                _context.Addresses.Remove(address);
                _context.SaveChanges();
            }
        }
    }
}
