
//********************************** start of file  **********************************//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10257503.PROG6221POEPart1
{
    internal class Program
    {/// <summary>
    /// Kashvir Sewpersad
    /// ST10257503
    /// 
    /// -ref
    /// 
    /// </summary>
    /// <param name="args"></param>
    /// 

        //******************** start of main method and entry to program ***********************// 

        /*
         The goal with my main method is to have a switch statement which will be used to control the actions based of user input
         This includes method calls and displaying a table 
         */
        static void Main(string[] args)
        {
            // Console.WriteLine("run test");

            FunctionalityClass fc = new FunctionalityClass();

            int choice;

            Console.WriteLine("Welcome to the recipe app ");

            Console.WriteLine("We just need some information and we can get started");

            while (true) {

                Console.WriteLine("Menu system");
             //   Console.WriteLine("\n");
                Console.WriteLine("1. Make new recipe");
              //  Console.WriteLine("\n");
                Console.WriteLine("2. Display a recipe");
               // Console.WriteLine("\n");
                Console.WriteLine("3. Scale up or down a recipe");
              //  Console.WriteLine("\n");
                Console.WriteLine("4. Reset");
             //   Console.WriteLine("\n");
                Console.WriteLine("5. Delete recipe");
              //  Console.WriteLine("\n");
                Console.WriteLine("6. Exit menu");

                

               try
                {
                    Console.WriteLine("Enter corresponding number ");
                     choice = int.Parse(Console.ReadLine());

                }
                catch(FormatException e)
                {
                    Console.WriteLine("Enter only numbers ");
                    //  return;
                    continue;

               }

                switch (choice) {
                    
                    case 1:
                        fc.Capture();
                        break;

                    case 2:
                        fc.Print(); 
                        break;

                    case 3:
                        fc.Scale();
                        break;

                    case 4:
                        fc.Reset();
                        break;

                    case 5:
                        fc.Clear();
                        break;

                    case 6:
                        Environment.Exit(0);
                        return; // this return is from the catch statement 
                        break;

                    default:
                        Console.WriteLine("Your input is out of bounds (1-6)");
                        break;

                       

                }


            }

           


        }

        //******************* end of main method ******************************************//

    }
}

//******************************** end of file ***************************************//