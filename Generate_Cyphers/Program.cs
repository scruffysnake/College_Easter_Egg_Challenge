class Program
{
    static void Main()
    {
        // Trial 1 (Caesar)
        foreach (char c in "You're a good egg")
            Console.Write((char)(c + 5));
        Console.WriteLine();
        string key = "^tz,wj%f%ltti%jll";
        string output = "";
        foreach (char c in key)
            output += (char)(c - 5);
        Console.WriteLine(output);
        Console.Write('b' == 'a' + 1);
    }
}