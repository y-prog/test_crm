using server.Enums;
using System.Text.Json.Serialization;
namespace server.Classes;

public class User
{
    private string _username;
    private string _company;
    private Role _role;

    public int Id { get; set; }
    
    public string Username
    { 
        get => _username;
        set
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Username should not be empty.");
            _username = value;
        }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Role Role
    {
        get => _role;
        set
        {
            if (!Enum.IsDefined(typeof(Role), value)) throw new ArgumentOutOfRangeException(nameof(value), "Invalid role.");
            _role = value;
        }
    }

    public int CompanyId { get; set; }

    public string Company 
    { 
        get => _company;
        set
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Company name should not be empty.");
            _company = value;
        }
    }

    public User(int id, string username, Role role, int companyId, string company)
    {
        Id = id;

        if (string.IsNullOrWhiteSpace(username))
            throw new ArgumentException("Username should not be empty.");
        Username = username;

        if (!Enum.IsDefined(typeof(Role), role))
            throw new ArgumentOutOfRangeException(nameof(role), "Invalid role specified.");
        Role = role;

        CompanyId = companyId;

        if (string.IsNullOrWhiteSpace(company))
            throw new ArgumentException("Company name should not be empty.");
        Company = company;
    }


}
