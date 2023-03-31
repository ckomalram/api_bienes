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
    }

    
}

public interface IUserService
{
    IEnumerable<User> Get();
}