namespace Core.BusinessObjects;

public static class DataFactory
{
    public static User ValidUser => new("vapire@internet.ru", "1257741589Aa1");
    public static User InvalidUser => new("chuchuchu@gmail.com", "123123123");

    public static Email Email
    {
        get
        {
            var uniqGuid = Guid.NewGuid().ToString();
            return new Email($"{uniqGuid}@gmail.com", uniqGuid, uniqGuid);
        }
    }
}