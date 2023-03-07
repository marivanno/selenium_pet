namespace Core.BusinessObjects;

public class Email
{
    private string _email;
    private string _subject;
    private string _bodyOfEmail;

    public Email(String email, String subject, string bodyOfEmail)
    {
        _email = email;
        _subject = subject;
        _bodyOfEmail = bodyOfEmail;
    }

    public string emailAddress
    {
        get => _email;
        set => _email = value;
    }

    public string subject
    {
        get => _subject;
        set => _subject = value;
    }
    
    
    public string body
    {
        get => _bodyOfEmail;
        set => _bodyOfEmail = value;
    }
}