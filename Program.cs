
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
     /// Name : Kashvir Sewpersad
     /// Student number : ST10257503
     /// Group : Group 1
     /// 
     /// ------------ complete README can be found on github : https://github.com/Kashvir-Sewpersad/ST10257503.PROG6221POEPart1.git
     /// 
     /// B. C. (2021, July 3). C# exception handling ⚠️. YouTube. https://www.youtube.com/watch?v=QqWfw_CFR6Q
     /// T. (2018, February 5). C# - Arrays. YouTube. https://www.youtube.com/watch?v=daFdTssjm3w
     /// E. T. (2018, November 28). 22. C# - ArrayLists. YouTube. https://www.youtube.com/watch?v=1zQLRK_YCt8
     /// G. A. (2017, November 8). Switch Statements | C# | Tutorial 17. YouTube. https://www.youtube.com/watch?v=Te43aPhxycs
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

            FunctionalityClass fc = new FunctionalityClass(); // created a object of the functionality class

            fc.Mesasge();


            // Subscribe to the event
            fc.OnCaloriesExceeded += (recipeName) =>
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Warning: The recipe '{recipeName}' exceeds 300 calories.");
                    Console.ResetColor();
                    Console.WriteLine("You may want to reduce portion size or remove item");
                };



            ///////////////// start of field declerations ////////////////////////

            int choice; //choice variable created to be used for user input


            //////////////// end of field declerations //////////////////////////

            Console.WriteLine("\n");

            Console.WriteLine(" Welcome to the Recipe App !!! ");

            Console.WriteLine("View the Menu below and choose an option");

            Console.WriteLine(" \n ");

            /*
          -   created a while loop to allow itteration through the menu system

          -   This also allows me to utalize the try catch block in a way where i can loop back if an error was encountered
             without crashing the program
             
             */




            while (true)
            {
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Red; // This sets the text color to red
                Console.WriteLine("------------- Menu system ---------------");
                Console.ResetColor(); // This reverts it back to default 
                Console.WriteLine("1. Make New Recipe");
                Console.WriteLine("2. Display List of Recipes"); // I added this to display the list of recipes
                Console.WriteLine("3. Display Recipe");
                Console.WriteLine("4. Scale Up or Down Recipe");
                Console.WriteLine("5. Reset");
                Console.WriteLine("6. Delete Recipe");
                Console.WriteLine("7. Exit Menu");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-----------------------------------------");
                Console.ResetColor();
                Console.WriteLine("\n");


                /*
                - I have incorperated a try and catch block for user input.
                -  User input is qualified as dangerous and thus we need exception handling here
                 */

                try
                {
                    Console.WriteLine("Enter corresponding number "); // Prompt to user to select a number from the menu 

                    choice = int.Parse(Console.ReadLine()); // The input is stored in the choice variable and is being analysed by the try block

                }
                /*
                 This catch block is set up to catch out a user trying to break the program. FormatException is trying to see if letters or words were entered instead of intergers
                 */
                catch (FormatException e)
                {
                    Console.WriteLine("You seem to have made a mistake" + e.Message);
                    Console.WriteLine("\n");
                    Console.WriteLine("Enter only numbers "); // This will display if a format error was encountered
                    Console.WriteLine("\n");
                    //  return;
                    continue; // Im using continue because i want the program to loop back in the event of a error. return ends the program

                }
                /*
                 Based on the user input which has by now passed the try catch block and should be free from errors. We will now pass the user input stored in the choice variable to the switch statement
                 */
                switch (choice)
                {
                    case 1:
                        fc.Capture(); // Call to capture method
                        break;
                    case 2:
                        fc.Print(); //  Call to print method
                        break;
                    case 3:
                        Console.WriteLine("Enter the recipe name to display: ");
                        string recipeName = Console.ReadLine();
                        fc.DisplayRecipe(recipeName); // call to display method
                        break;
                    case 4:
                        fc.Scale(); // Call to scale method
                        break;
                    case 5:
                        fc.Reset(); // call to reset method
                        break;
                    case 6:
                        fc.Clear(); // call to clear method
                        break;
                    case 7:
                        Environment.Exit(0); // This is a more elegant way to close a programm as per our standed "crash it" 
                        break;
                    default:
                        Console.WriteLine("Your input is out of bounds (1-7)"); // This will display if a user enters a number out of what was allowed. 
                        break;
                }
            }
        }
    }
    //******************* end of main method ******************************************//
}


//******************************** end of file ***************************************//