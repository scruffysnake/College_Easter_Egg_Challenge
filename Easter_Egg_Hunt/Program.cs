using System;
using System.Linq;
using static Easter;

/*
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
*/
namespace EASTER_EGG_HUNT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Funny solution for trial 1 (remove before giving to people in college)
            Trial();
            var n = -10;
            while (!Submit(string.Join("", Key.Select(c => (char)(c + n))))) n++;
        }
    }
}