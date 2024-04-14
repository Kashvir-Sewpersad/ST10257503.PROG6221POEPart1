
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

            FunctionalityClass fc = new FunctionalityClass(); // created a object of the functionality class


            ///////////////// start of field declerations ////////////////////////
            
            int choice; //choice variable created to be used for user input

            //////////////// end of field declerations //////////////////////////


            Console.WriteLine(" Welcome to the Recipe App !!! ");

            Console.WriteLine("View the Menu below and choose an option");

            Console.WriteLine(" \n ");

            /*
          -   created a while loop to allow itteration through the menu system

          -   This also allows me to utalize the try catch block in a way where i can loop back if an error was encountered
             without crashing the program
             
             */

            //**************************** start of menu ****************************//

            while (true) {

                Console.WriteLine(" ------------- Menu system --------------- ");
             
                Console.WriteLine("1.**** Make New Recipe ****"); // This menu will display as soon as a user runs the program
              
                Console.WriteLine("2.**** Display Recipe ****");
              
                Console.WriteLine("3.**** Scale Up or Down Recipe ****");
              
                Console.WriteLine("4.**** Reset ****");
            
                Console.WriteLine("5.**** Delete Recipe ****");
            
                Console.WriteLine("6.**** Exit Menu ****");

                Console.WriteLine(" ----------------------------------------- ");


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
                catch(FormatException e)
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("Enter only numbers "); // This will display if a format error was encountered
                    Console.WriteLine("\n");
                    //  return;
                    continue; // Im using continue because i want the program to loop back in the event of a error. return ends the program

               }
                /*
                 Based on the user input which has by now passed the try catch block and should be free from errors. We will now pass the user input stored in the choice variable to the switch statement
                 */
                switch (choice) {
                    
                    case 1:
                        fc.Capture(); // method call to capture method
                        break;

                    case 2:
                        fc.Print(); // method call to print method
                        break;

                    case 3:
                        fc.Scale(); // method call to scale method
                        break;

                    case 4:
                        fc.Reset(); // method call to reset method
                        break;

                    case 5:
                        fc.Clear(); // method call to clear method
                        break;

                    case 6:
                        Environment.Exit(0); // Environment.Exit(0) is a elegent way of exiting the program as per just crashing it 
                        return; //This return statement is from the Catch block earlier. 
                        break;

                    default:
                        Console.WriteLine("Your input is out of bounds (1-6)"); // I have added a default case, however the try catch should have weeded out any issues by now
                        break;

                       

                }


            }

           


        }
        
        //******************* end of main method ******************************************//

    }
}

//******************************** end of file ***************************************//