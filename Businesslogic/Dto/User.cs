using Core.BusinessObjects;

namespace Businesslogic.Dto;

public class User
{
    public User(string name, string email, string gender, string status)
    {
        this.name = name;
        this.email = email;
        this.gender = gender;
        this.status = status;
    }
    public string name { get; set; }
    public string email { get; set; }
    public string gender { get; set; }
    public string status { get; set; }
}