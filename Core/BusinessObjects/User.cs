namespace Core.BusinessObjects;

public class User
{
    private string _userName;
    private string _password;

    public User(String userName, String password)
    {
        _userName = userName;
        _password = password;
    }

    public string UserName
    {
        get => _userName;
        set => _userName = value;
    }

    public string Password
    {
        get => _password;
        set => _password = value;
    }
}