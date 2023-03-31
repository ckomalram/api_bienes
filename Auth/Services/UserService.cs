using Auth.Context;
using Auth.Models;

namespace Auth.Services;

public class UserService: IUserService
{
    PersonContext context;

    public UserService(PersonContext dbcontext){
        context = dbcontext;
    }

    public IEnumerable<User> Get(){
        
        return context.Users;
        //TODO: Manejar cuandl no exista usuarios.

    }

    public User GetById(Guid id){
        
       return context.Users.Find(id);

        //TODO: Manejar cuandl no exista usuario.
    }

    public async Task Create(User user){
        // user.UserId = Guid.NewGuid();
        // user.FechaCreado = DateTime.Now;
        // Console.WriteLine(user.FechaCreado.ToShortDateString());
        context.Add(user);
        await context.SaveChangesAsync();
    }



    
}

public interface IUserService
{
    IEnumerable<User> Get();
    User GetById(Guid id);
    Task Create(User user);
}