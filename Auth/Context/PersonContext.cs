using Microsoft.EntityFrameworkCore;
using Auth.Models;

namespace Auth.Context;

public class PersonContext : DbContext
{
    public DbSet<User> Usuarios { get; set; }
    public DbSet<Customer> Clientes { get; set; }

    //constructor with base values
    public PersonContext(DbContextOptions<PersonContext> options) : base(options) { }

    // Sobreescribiendo metodo de fluent api para crear tablas
    protected override void OnModelCreating(ModelBuilder modelbuilder)
    {

        //TODO: Datos initiales
        List<User> userInit = new List<User>();
        userInit.Add(new User()
        {
            Id = Guid.Parse("71c87875-4439-4d7c-ba96-f8ba9136dbaa"),
            Name = "Carlyle Komalram",
            Email = "ckomalram@gmail.com",
            Password = "12345",
            Identification = "8-873-387",
            FechaCreado = DateTime.Now,
            IdType = 0,
            Role = 0,
            Status = 0
        });

        userInit.Add(new User()
        {
            Id = Guid.Parse("71c87875-4439-4d7c-ba96-f8ba9136dba1"),
            Name = "Yoainaris Concepcion",
            Email = "yoainaris@gmail.com",
            Password = "12345",
            Identification = "8-920-953",
            FechaCreado = DateTime.Now,
            IdType = 0,
            Role = 0,
            Status = 0
        });

        // Builder Usuarios
        modelbuilder.Entity<User>(user =>
        {
            user.ToTable("Usuario");
            user.HasKey(p => p.Id);
            user.Property(p => p.Name).IsRequired().HasMaxLength(150);
            user.Property(p => p.Email).IsRequired().HasMaxLength(150);
            user.Property(p => p.Password).IsRequired().HasMaxLength(12);
            user.Property(p => p.Identification).IsRequired().HasMaxLength(12);
            user.Property(p => p.FechaCreado);

            user.Ignore(p => p.Resumen);

            user.HasData(userInit);
        });




        // TODO init data customer

        List<Customer> customerInit = new List<Customer>();
        customerInit.Add(new Customer()
        {
            Id = Guid.Parse("71c87875-4439-4d7c-ba96-f8ba9136dba2"),
            Name = "Alexander Agrazal",
            Email = "aagrzada@gmail.com",
            Phonenumber = "12345",
            Identification = "8-873-000",
            FechaCreado = DateTime.Now,
            IdType = 0,
            Status = 0
        });
        customerInit.Add(new Customer()
        {
            Id = Guid.Parse("71c87875-4439-4d7c-ba96-f8ba9136dba3"),
            Name = "Hector De Gracia",
            Email = "hdegracia@gmail.com",
            Phonenumber = "12345",
            Identification = "8-000-387",
            FechaCreado = DateTime.Now,
            IdType = 0,
            Status = 0
        });


        //Builder Clientes
        modelbuilder.Entity<Customer>(customer =>
            {
                customer.ToTable("Cliente");
                customer.HasKey(p => p.Id);
                customer.Property(p => p.Name).IsRequired().HasMaxLength(150);
                customer.Property(p => p.Email).IsRequired().HasMaxLength(150);
                customer.Property(p => p.Phonenumber).IsRequired().HasMaxLength(30);
                customer.Property(p => p.Identification).IsRequired().HasMaxLength(12);
                customer.Property(p => p.FechaCreado);

                customer.Ignore(p => p.Resumen);


                customer.HasData(customerInit);
            });
    }
}