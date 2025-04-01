using System;
using System.Diagnostics;
using System.Linq;

public static class Easter
{
    // Constants
    public enum Trials
    {
        TRIAL1, 
        TRIAL2, 
        TRIAL3, 
        COMPLETE
    }
    // Trial 1 (Caesar)
    const string KEY1 = "^tz,wj%f%ltti%jll";
    const string SOL1 = "You're a good egg";

    // Trial 3 (First 10 digit fib)
    const int SOL3 = 1134903170; // Look at Helper_Generate_Questions for how this number was generated

    // Private variables
    static string KeyReal = KEY1;
    static Trials CurrentTrialReal = Trials.TRIAL1;

    // Private Functions
    // Trial 1 (Caesar)
    static void Trial1()
        => Console.WriteLine(@"
Trial 1:
I received an encrypted message from the easter bunny, but the key was never received!!!
I heard somewhere that the easter bunny is a fan of Caesar Ciphers, 
so I feel it's best to decipher it as a Caesar Cipher.

I've stored the encripted message within the Easter.Key variable
If you cannot access it for whatever reason, the message is the following string:
    ""^tz,wj%f%ltti%jll""

Using brute force might be a smart way to solve the message.
    ");
    static void HintTrial1()
        => Console.WriteLine(@"
Trial 1 hint:
You can offset a character by adding a number to it:
    ""'b' == 'a' + 1"" is true and valid syntax
    
So if you wanted to offset all the characters in a string you could:
    ""
    string OffsetBy2 = """";
    foreach (char c in EncriptedMessage)
    {
        OffsetBy2 += (char)(c + 2);
    }
    ""

You have to remeber to add the (char) or the number would be converted to a string:
    string s = """" + 65;       -> s would equal ""65""
    string s = """" + (char)65; -> s would equal the ascii value of 65 which is 'A'

The magnitude of the offset is below 10
    ");
    static bool SubmitTrial1(object ans)
    {
        if (!(ans is string s))
        {
            Console.WriteLine("Trial 1 only takes a string as an input");
            return false;
        }
        if (s != SOL1)
        {
            Console.WriteLine($"Trial 1: {s} is not the correct solution");
            return false;
        }
        Console.WriteLine($"\nTrial 1: {s} is the correct solution\nYou solved trial 1!\nWell done :)\n\nTrial 2 is now available; run Easter.Trial() for information about it\n");
        CurrentTrial = Trials.TRIAL2;
        return true;
    }
    // Trial 2 (Factorial)
    static void Trial2()
        => Console.WriteLine(@"
Trial 2:
Well done for completing trial 1, I can finally understand the message (tysm)

I now need your help figuring out all possible arangments of easter egg hiding locations!

Can you please submit a function that calculates the factorial of a given number?
This function needs to be able to take an integer as an argument and output a integer.

Heres an example of how to submit a function:
    bool isEven(int n)
    {
        return n % 2 == 0;
    }
    Easter.Submit(isEven);
                // ^ just need to write the same of the function as an argument
        ");
    static void HintTrial2()
        => Console.WriteLine(@"
Trial 2 hint:
Consider using recusion to create the factorial function.
And using this formula:
    n! = n * (n-1) * (n-2) .. 2 * 1
        ");
    static bool SubmitTrial2(Func<int, int> fn)
    {
        Console.WriteLine("Running trial 2 test cases");
        int Factorial(int n) => Enumerable.Range(1, n).Aggregate(1, (a, b) => a * b);
        for (int i = 1; i <= 10; i++)
        {
            int userAns = fn(i);
            int realAns = Factorial(i);
            if (userAns != realAns) 
            {
                Console.WriteLine($"Test {i} Failed! Got {userAns} instead of {realAns}");
                return false;
            }
            Console.WriteLine($"Test {i} valided successfully.");
        }
        Console.WriteLine("\nTrial 2: your function works!\nWell done :)\n\nTrial 3 is now available; run Easter.Trial() for information about it\n");
        CurrentTrial = Trials.TRIAL3;
        return true;
    }
    // Trial 3 (First 10 digit fib)
    static void Trial3()
        => Console.WriteLine(@"
Trial 3:
Well done for completing trial 2, now I know the number of possible permutations of easter egg hiding locations!!

Now the third and final trial, what is the first number within fibonacci sequence that contains 10 digits?
Please submit it as an integer
        ");
    static void HintTrial3()
        => Console.WriteLine(@"
Trial 3 hint:
The clasic fibonacci fomula is:
    F(1) = 1
    F(2) = 1
    F(n) = F(n - 1) + F(n - 2) where n is greater than 2

Brute forcing may be slow while using recursion.
You could consider using an iterative methord or searching up a formula

To get the number of digits within a number, 2 good methods include:
    converting the number to a string, and checking the length of the string
    calculating the log (base 10) of the number
        ");
    static bool SubmitTrial3(object ans)
    {
        int n = 1;
        try
        {
            n = Convert.ToInt32(ans);
        }
        catch
        {
            Console.WriteLine("You have to submit an integer");
            return false;
        }
        if (n.ToString().Length != 10) 
        {
            Console.WriteLine($"The number has to be 10 digits long: {n} is {n.ToString().Length} digits long");
            return false;
        }
        if (n == SOL3)
        {
            CurrentTrialReal = Trials.COMPLETE;
            Console.WriteLine($"\nTrial 3: you got the first 10 digit number in the fibonacci sequence {n}\n{CompletionText()}");
        }
        return n == SOL3;
    }
    // Idk why I made this a function instead of a constant, but not worth the effort to change it
    static string CompletionText()
        => "Well done for completing all the trials!\nHope you had a good time going to the programming enrichment\nThank you for attending :)";

    // Public variables
    public static string Key 
    { 
        get { return KeyReal; } 
        private set { KeyReal = value; } 
    }
    public static Trials CurrentTrial 
    { 
        get { return CurrentTrialReal; }
        private set { CurrentTrialReal = value; } 
    }

    // Public Functions
    public static void Help()
        => Console.WriteLine(@"
Help:
There are 3 trials to solve to find the secret message!
After solving each trial, the information for the next trial will be released.
    
Run Easter.Trial() to get information about the trial you currently on.

Once you think you have a solution to the trial, 
you can submit it to the function Easter.Submit 
and it'll return true/false depending if you got the solution correct.

If you need a hint, you can run the procedure Easter.Hint() 
and it will output some hints for the trial you are currently on.

Any values you need for a specific trial will be stored in the Easter.Key variable.
    
You can run Easter.Help() to get this message to appear
Note: you do not need to include Easter when running the functions
    ");
    public static void Trial()
    {
        switch(CurrentTrial)
        {
            case Trials.TRIAL1: Trial1(); return;
            case Trials.TRIAL2: Trial2(); return;
            case Trials.TRIAL3: Trial3(); return;
            case Trials.COMPLETE: Console.WriteLine(CompletionText()); return;
        }
    }
    public static void Hint()
    {
        switch(CurrentTrial)
        {
            case Trials.TRIAL1: HintTrial1(); return;
            case Trials.TRIAL2: HintTrial2(); return;
            case Trials.TRIAL3: HintTrial3(); return;
        }
        Console.WriteLine(CompletionText());
    }
    public static bool Submit(object answer)
    {
        switch(CurrentTrial)
        {
            case Trials.TRIAL1: return SubmitTrial1(answer);
            case Trials.TRIAL2: 
                Console.WriteLine("Trial 2 only takes a function (with an int param and output)\n\t(e.g.) int f(int x);");
                return false;
            case Trials.TRIAL3: return SubmitTrial3(answer);
        }
        Console.WriteLine(CompletionText());
        return false;
    }
    // Alias used as object cannot take function as argument 🤷‍♀️
    // Confuses me a bit as it seems to work in another part of the code
    // Eddited the code that uses that though
    public static bool Submit(Func<int, int> userFunc)
    {
        if (CurrentTrial != Trials.TRIAL2) 
        {
            Console.WriteLine("Only trial 2 expects a function to be submitted");
            return false;
        }
        return SubmitTrial2(userFunc);
    }
}
