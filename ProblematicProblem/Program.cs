using System;
using System.Collections.Generic;
using System.Threading;


public class ProblematicProblem
{
    class Program
    {
        static bool cont = true;
        static List<string> activities = new List<string>()
        { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static void Main(string[] args)
        {
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            bool cont = Console.ReadLine().Equals("yes", StringComparison.OrdinalIgnoreCase);
            Console.WriteLine();
            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("What is your age? ");
            int userAge = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
            bool seeList = Console.ReadLine().Equals("sure", StringComparison.OrdinalIgnoreCase);

            if (seeList)
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }
                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                bool addToList = Console.ReadLine().Equals("yes", StringComparison.OrdinalIgnoreCase);
                Console.WriteLine();
                while (addToList)
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Would you like to add more? yes/no: ");
                    addToList = Console.ReadLine().Equals("yes", StringComparison.OrdinalIgnoreCase);
                }
            }

            while (cont)
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                Console.WriteLine("Choosing your random activity");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                var rng = new Random();
                int randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber];


                if (userAge > 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");
                    activities.Remove(randomActivity);


                }
                Console.Write($"Ah got it! {randomActivity}, your random activity is: {userName}!" +
                    $" Is this ok or do you want to grab another activity? Keep/Redo: ");

                Console.WriteLine();
                cont = Console.ReadLine().Equals("yes", StringComparison.OrdinalIgnoreCase);
            }
        }
    }
}