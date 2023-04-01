using Auth.Context;
using Auth.Models;

namespace Auth.Services;

public class CustomerService : ICustomerService
{
    PersonContext context;

    public CustomerService(PersonContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<Customer> Get()
    {

        return context.Customers.ToList();
        //TODO: Manejar cuandl no exista clientes.

    }

    public async Task <Customer> GetById(Guid id)
    {

        return  await context.Customers.FindAsync(id);

        //TODO: Manejar cuandl no exista cliente.
    }

    public async Task<Customer> Create(Customer customer)
    {
        customer.FechaCreado = DateTime.Now;
        context.Add(customer);
        await context.SaveChangesAsync();
        return customer;
    }

        public async Task Update(Guid id , Customer customer)
    {
        var customerRta = await context.Customers.FindAsync(id);

        if (customerRta != null)
        {
            customerRta.Name = customer.Name;
            customerRta.Email = customer.Email;
            customerRta.Phonenumber = customer.Phonenumber;
            customerRta.Identification = customer.Identification;
            customerRta.TypeId = customer.TypeId;
            customerRta.Status = customer.Status;
            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id){
        var customerRta = await context.Customers.FindAsync(id);

        if (customerRta != null)
        {
            context.Remove(customerRta);
            await context.SaveChangesAsync();
        }
    }

}

public interface ICustomerService
{
    IEnumerable<Customer> Get();
    Task <Customer> GetById(Guid id);
    Task<Customer> Create(Customer customer);

    Task Update(Guid id , Customer customer);
    Task Delete(Guid id);
}