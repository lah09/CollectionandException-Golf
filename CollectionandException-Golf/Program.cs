using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace golf
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int shotCounter = 0;
                int cup = 500;
                double startingPoint = 0;
                double gravity = 9.8;
                List<double> gameStroke = new List<double>();

                for (int i = 0; i < 10; i++) //or while(true)
                {
                    if (shotCounter > 3) //better to place here otherwise you must enter angle and velocity before it'll inform that try is over
                    {
                        Console.WriteLine("\nGame is over .. you have used all of your tries!\n");
                        Console.WriteLine("Here is the result of your shots: ");
                        Console.WriteLine();

                        foreach (int result in gameStroke)
                        {
                            Console.WriteLine("\tShot = {0}m", result);
                        }
                        break;
                    }

                    Console.Write("Enter angle: ");
                    int angle = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter velocity: ");
                    int velocity = Convert.ToInt32(Console.ReadLine());

                    double angleInRadians = (Math.PI / 180) * angle;
                    double distance = Math.Pow(velocity, 2) / gravity * Math.Sin(2 * angleInRadians);
                    distance = Math.Round(distance);
                    startingPoint += distance;
                    shotCounter++;

                    // Add the distance to the list
                    gameStroke.Add(distance);

                    //if (shotCounter > 3)
                    //{
                    //    Console.WriteLine("\nGame is over .. you have used all of your tries!");
                    //    Console.WriteLine("Here is the results of your shots: ");
                    //    Console.WriteLine();

                    //    foreach (int result in gameStroke)
                    //    {
                    //        Console.WriteLine("Shot = {0}m", result);
                    //    }
                    //    break;
                    //}

                    if (distance < cup)
                    {
                        Console.WriteLine("Your ball landed {0}m away from the starting point. Try Again!", distance);

                        distance = Math.Abs(cup - startingPoint);
                        distance = Math.Round(distance);
                        Console.WriteLine("It is now {0}m away from the cup\n", distance);
                    }
                    else if (distance > cup)
                    {
                        Console.WriteLine("You landed beyond the target! Try Again!");

                        distance = Math.Abs(cup - startingPoint);
                        distance = Math.Round(distance);

                        Console.WriteLine("It is now {0}m away from the cup\n", distance);
                    }
                    else if (distance == cup)
                    {
                        Console.WriteLine("Got it!");
                        Console.WriteLine("Here is the results of your shots: ");

                        foreach (int result in gameStroke)
                        {
                            Console.WriteLine("{0}m\n", result);
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nGame is over .. ");
                        Console.WriteLine("Here is the results of your shots: ");

                        foreach (int result in gameStroke)
                        {
                            Console.WriteLine("{0}m\n", result);
                        }
                        break;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong input!");
            }

            Console.ReadKey();
        }
    }
}