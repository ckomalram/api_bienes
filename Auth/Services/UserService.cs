using Auth.Context;
using Auth.Models;

namespace Auth.Services;

public class UserService : IUserService
{
    PersonContext context;

    public UserService(PersonContext dbcontext)
    {
        context = dbcontext;
    }

    public IEnumerable<User> Get()
    {

        return context.Users.ToList();
        //TODO: Manejar cuandl no exista usuarios.

    }

    public async Task <User> GetById(Guid id)
    {

        return  await context.Users.FindAsync(id);

        //TODO: Manejar cuandl no exista usuario.
    }

    public async Task<User> Create(User user)
    {
        // user.UserId = Guid.NewGuid();
        user.FechaCreado = DateTime.Now;
        // user.Resumen = "";
        // Console.WriteLine(user.FechaCreado.ToShortDateString());
        context.Add(user);
        await context.SaveChangesAsync();
        return user;
        // return Results.Created("Creado exitosamente!", user);
    }

        public async Task Update(Guid id , User user)
    {
        var userRta = await context.Users.FindAsync(id);

        if (userRta != null)
        {
            userRta.Name = user.Name;
            userRta.Email = user.Email;
            userRta.Password = user.Password;
            userRta.Identification = user.Identification;
            userRta.TypeId = user.TypeId;
            userRta.Role = user.Role;
            userRta.Status = user.Status;
            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id){
        var userRta = await context.Users.FindAsync(id);

        if (userRta != null)
        {
            context.Remove(userRta);
            await context.SaveChangesAsync();
        }
    }

}

public interface IUserService
{
    IEnumerable<User> Get();
    Task <User> GetById(Guid id);
    Task<User> Create(User user);

    Task Update(Guid id , User user);
    Task Delete(Guid id);
}