
int lenght = Methods.GetTextLenght("    test    ");
Console.WriteLine(lenght);





public static class Methods
{
    public static int GetTextLenght (string text, bool includeLeadSpace = false, int x=0)
    {
        if (!includeLeadSpace)
        {
            return text.Trim ().Length; 
        }
        return text.Length;
        

    }


}
