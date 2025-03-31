using System;

public static class Easter
{
    // Constants
    public enum Trials
    {
        TRIAL1, 
        TRIAL2, 
        TRIAL3, 
        TRIAL4,
    }
    // Trial 1 (Caesar)
    const string KEY1 = "^tz,wj%f%ltti%jll";
    const string SOL1 = "You're a good egg";

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
        }
    }
    public static void Hint()
    {
        switch(CurrentTrial)
        {
            case Trials.TRIAL1: HintTrial1(); return;
        }
    }
    public static bool Submit(object answer)
    {
        switch(CurrentTrial)
        {
            case Trials.TRIAL1: return SubmitTrial1(answer);
        }
        return false;
    }
}
