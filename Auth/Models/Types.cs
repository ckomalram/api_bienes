using System.Text.Json.Serialization;

namespace Auth.Models
{
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
}
