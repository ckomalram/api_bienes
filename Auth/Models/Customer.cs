using System.Text.Json.Serialization;

namespace Auth.Models
{
    public class Customer
    {
        /**
        nombre, email, password, identificacion, idtype, role
        **/

        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public string Identification { get; set; }
        public IdentificationType IdType { get; set; }
        public StatusPerson Status { get; set; }

        [JsonIgnore]
        public string Resumen { get; set; }

    }
}