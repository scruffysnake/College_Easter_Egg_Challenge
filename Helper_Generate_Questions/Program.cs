class Program
{
    static void Main()
    {
        // Trial 1 (Caesar)
        {
            foreach (char c in "You're a good egg")
                Console.Write((char)(c + 5));
            Console.WriteLine();
            string key = "^tz,wj%f%ltti%jll";
            string output = "";
            foreach (char c in key)
                output += (char)(c - 5);
            Console.WriteLine(output);
            Console.WriteLine('b' == 'a' + 1);
        }

        // Trial 2 (Factorial Function)
        {
            for (int i = 1; i <= 10; i++) Console.WriteLine($"{i}\t:{Enumerable.Range(1, i).Aggregate(1, (a, b) => a * b)}");
        }

        // Trial 3 (Fib)
        {
            // Memoization
            Dictionary<int, int> Memo = new Dictionary<int, int> { {0, 1}, {1, 1} };
            int fib(int n)
            {
                if (Memo.ContainsKey(n)) return Memo[n];
                Memo.Add(n, fib(n - 1) + fib (n - 2));
                return Memo[n];
            }
            int n = 0;
            for (int i = 0; i != -1; i++)
            {
                n = fib(i);
                if (n.ToString().Length >= 10) break;
            }
            Console.WriteLine(n);
        }
    }
}