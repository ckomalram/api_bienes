using Microsoft.EntityFrameworkCore;
using Auth.Models;

namespace Auth.Context;

public class PersonContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Customer> Customers { get; set; }

    //constructor with base values
    public PersonContext(DbContextOptions<PersonContext> options) : base(options) { }

    // Sobreescribiendo metodo de fluent api para crear tablas
    protected override void OnModelCreating(ModelBuilder modelbuilder)
    {

        //TODO: Datos initiales
        List<User> userInit = new List<User>();
        userInit.Add(new User(){
            UserId = Guid.Parse("71c87875-4439-4d7c-ba96-f8ba9136dbaa"),
            Name = "Carlyle Komalram",
            Email= "ckomalram@bandelta.com",
            Password="12345",
            Identification="8-888-888",
            TypeId= IdentificationType.Idcard,
            Role = Role.Admin,
            Status = StatusPerson.Active,
            FechaCreado = DateTime.Now            
            });
 

        // Builder Usuarios
        modelbuilder.Entity<User>(user =>
        {
            user.ToTable("User");
            user.HasKey(p => p.UserId);
            user.Property(p => p.Name).IsRequired();
            user.Property(p => p.Email).IsRequired().HasMaxLength(150);
            user.Property(p => p.Password).IsRequired().HasMaxLength(12);
            user.Property(p => p.Identification).IsRequired().HasMaxLength(12);
            user.Property(p => p.TypeId);
            user.Property(p => p.Role);
            user.Property(p => p.Status);
            user.Property(p => p.FechaCreado);

            // user.Ignore(p => p.Resumen);

            user.HasData(userInit);
        });


                // TODO init data customer

        List<Customer> customerInit = new List<Customer>();
        customerInit.Add(new Customer()
        {
            CustomerId = Guid.Parse("71c87875-4439-4d7c-ba96-f8ba9136d333"),
            Name = "Alexander Agrazal",
            Email = "aagrzada@gmail.com",
            Phonenumber = "12345",
            Identification = "8-873-000",
            FechaCreado = DateTime.Now,
            TypeId = IdentificationType.License,
            Status = StatusPerson.Active
        });
        // customerInit.Add(new Customer()
        // {
        //     IdCustomer = Guid.Parse("71c87875-4439-4d7c-ba96-f8ba9136dba3"),
        //     Name = "Hector De Gracia",
        //     Email = "hdegracia@gmail.com",
        //     Phonenumber = "12345",
        //     Identification = "8-000-387",
        //     FechaCreado = DateTime.Now,
        //     IdType = IdentificationType.Idcard,
        //     Status = StatusPerson.Active
        // });


        //Builder Clientes
        modelbuilder.Entity<Customer>(customer =>
            {
                customer.ToTable("Cliente");
                customer.HasKey(p => p.CustomerId);
                customer.Property(p => p.Name).IsRequired().HasMaxLength(150);
                customer.Property(p => p.Email).IsRequired().HasMaxLength(150);
                customer.Property(p => p.Phonenumber).IsRequired().HasMaxLength(30);
                customer.Property(p => p.Identification).IsRequired().HasMaxLength(12);
                customer.Property(p => p.TypeId);
                customer.Property(p => p.Status);
                customer.Property(p => p.FechaCreado);

                customer.HasData(customerInit);
            });
        
    }
}