using CustomerRegistration.Models;

namespace CustomerRegistration.Repositories.Interfaces
{
    public interface IAddressRepository
    {
        IEnumerable<Address> GetAll();
        Address GetById(int id);
        void Add(Address address);
        void Update(Address address);
        void Delete(int id);
    }
}
