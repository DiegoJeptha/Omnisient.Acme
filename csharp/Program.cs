using System;
using System.Collections.Generic;
using System.Linq;
namespace csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            int country = 0;
            double value = 0;
            double paid = 0;
            try
            {
                Console.WriteLine("Hello!");
                Console.WriteLine("Please select a currency by typing in a number:");


                Console.WriteLine("1) US Dollar");
                Console.WriteLine("2) British Pound");

                if (Int32.TryParse(Console.ReadLine(), out int j))
                {
                    if (j > 0 && j < 3)
                    {
                        country = j;
                    }
                    else
                    {
                        Console.WriteLine("Error! Please read next time goodbye ;)!");
                        Console.WriteLine("Press ENTER and restart the application!");
                        Console.ReadLine();
                        Environment.Exit(0);
                    }

                }
                else
                {
                    Console.WriteLine("Error! Please read next time goodbye ;)!");
                    Console.WriteLine("Press ENTER and restart the application!");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                Console.WriteLine();
                Console.WriteLine("Insert the value of the item:");
                if (double.TryParse(Console.ReadLine().Replace('.', ','), out double i))
                {
                    value = i;
                }
                Console.WriteLine();
                Console.WriteLine("Insert the value of how much you paid:");
                if (double.TryParse(Console.ReadLine().Replace('.', ','), out double p))
                {
                    paid = p;
                }

                Checker(paid, value, country);
            }
            catch
            {
                new Exception();
            }



        }

        private static void Checker(double paid, double value, int country)
        {
            double sum;
            if (paid >= value)
            {
                sum = paid - value;
                Calculate(sum, country);
            }
            else
            {
                Console.WriteLine("Error! I'm not giving a discount!");
                Console.WriteLine("Press ENTER and restart the application!");
                Console.ReadLine();

            }


        }

        private static void Calculate(double change, int country)
        {
            List<int> coins;
            // USA
            if (country == 1)
            {
                coins = new List<int>() { 1, 5, 10, 25 };
            }
            else
            {
                coins = new List<int>() { 1, 2, 10, 25 };
            }

            List<int> sendBack = new List<int>() { };
            //Converts to cents
            var remainder = (int)Math.Truncate(change * 100);

            coins.Reverse();
            //Reverse for loop
            for (int i = 0; i < coins.Count; i++)
            {
                int coin = coins[i];
                //removes the decimal when dividing and only equals the whole number
                var coinTypeAmount = (int)((remainder / coin) * 100) / 100;
                for (int j = 0; j < coinTypeAmount; j++)
                {
                    remainder = remainder - coin;
                    sendBack.Add(coin);
                }

            }
            Console.WriteLine("This is how many coins you have");
            for (int i = 0; i < sendBack.Count; i++)
            {

                Console.WriteLine("change[{0}] = {1}", i, sendBack[i]);
            }
        }
    }
}
