namespace Core;

public class TextEditor
{
    public static string ParseNameOfTestFromContext(string str)
    {
        var result = str.Split('.');
        return result[^1];
    }
}