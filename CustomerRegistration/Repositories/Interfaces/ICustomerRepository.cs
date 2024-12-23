using CustomerRegistration.Models;

namespace CustomerRegistration.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(int id);
        bool ExistsByEmail(string email);
    }
}
