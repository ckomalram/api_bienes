using System.Text.Json.Serialization;

namespace Auth.Models;

    public class User
    {
        /**
        nombre, email, password, identificacion, idtype, role
        **/

        public Guid UserId { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Identification { get; set; }
        public IdentificationType TypeId { get; set; }
        public Role Role { get; set; }

        public StatusPerson Status { get; set; }
        public DateTime FechaCreado { get; set; }


        // [JsonIgnore]
        // public string Resumen { get; set; }

    }

    public enum IdentificationType
    {

        Idcard,
        Passport,
        License

    }

    public enum Role
    {

        Normal,
        Auditor,
        Aprover,
        Admin,
        Superadmin

    }

    public enum StatusPerson
    {
        Active,
        Inactive,
        Bloked

    }


