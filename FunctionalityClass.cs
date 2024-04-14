
//******************************************** start of file *************************************************//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10257503.PROG6221POEPart1
{
    /// <summary>
    /// 
    /// </summary>
    /// 

    /*
     
     The purpose of this class is to contain the functionality or worker methods which will be called in the switch statement in the main method
     
     */
    internal class FunctionalityClass
    {
        //**************************** start of storage system ***********************//



        private List<Ingredient> ingredients; // I have created an array list to store the ingredents

        private List<string> steps; // Here I have created one to store the steps involed in the recipe
        private List<double> originalQuantities;
        /*
         side note, I should have created a seperate class for the steps, including getters and setters however for this case its not nessesary 
         */

        //**************************** end of storage system ***********************//





        //******************************* start of constructor ***********************//
        public FunctionalityClass()
        {
            ingredients = new List<Ingredient>();

            steps = new List<string>();
        }

        //******************************* end of constructor ***********************//





        //************************************* start of capure method ********************************//


        /*
         
         The purpose of this mwthod is to capture the details regarding the recipe
         we will need to capture: name, quantity and quantity
         
         */
        public void Capture()
        {

            /////////////////////////////// start of field declerations ////////////////////////////

            int stepCount; // This variable will be used to store how many steps in the recipe which will then be used in a loop

            string step; // This variable will be used to store the step { text }

            int ingredientNum; // This variable will be used to store how many ingredients will be used per recipe 

            string ingName; // This variable will be used to store the ingredient name

            string additional; // This variable will be used to store any additional ingredients 

            string additionalYES = " "; // I have declared and initialized this variable to nothing. It will be used in the event that there is any additional ingredients

            string extraStep; // This variable will be used to store any additional steps 

            string extraStepYes = " "; // I have declared and initialized this variable to nothing. It will be used in the event that there is any additional steps

            int ingredientQuantity; // This variable will be used to store the quantity of ingridents 

            string ingredientMeasurement; // This variable will be used to store the measurement

            int i; // This variable will be used to increment a for loop to recive information based on how many ingridents we have

            int x; // This variable will be used to increment a for loop for how many steps we have

            //////////////////////////////// end of field declerations ////////////////////////////////// 

            Console.WriteLine("Follow the Prompts  ");

            Console.WriteLine("All values must be added as grams");
           



            try // try block to detect any errors on dangerous code
            {

                Console.WriteLine("Enter how many ingridents will be used in this recipe : "); // Promt to user

                ingredientNum = int.Parse(Console.ReadLine()); // Input will be converted and store


            }
            catch (FormatException e)
            {
                Console.WriteLine(" ENTER NUMBERS ONLY "); // This catch block will execute if a format error occurs. That will come in the form of a user inputing letters

                return;
            }

            /*
             for loop using the number of ingridents to increment and recive details such as quantity, name and measurement
             */
            for (i = 0; i < ingredientNum; i++)
            {
                Console.WriteLine($"Enter the name of ingredient {i + 1}: "); // Promt to user

                ingName = Console.ReadLine(); // Variable will be stored 

                /*
                 This is volatile data as it is user input and not a string as such it has potential to crash the app. 
                - For that reason alone i am adding a try catch block
                 */
                try
                {
                    Console.WriteLine($"Enter the quantity for {ingName} in grams (g): ");

                    ingredientQuantity = int.Parse(Console.ReadLine()); // Variable will be screened, converted and stored 
                }
                catch (FormatException e) {

                    Console.WriteLine("Please enter your answer in numerical notation"); 

                    return;
                }


                Console.WriteLine($"Enter the measurement for the {ingName} in cups: "); // prompt for a measurement


                ingredientMeasurement = Console.ReadLine();  // Because C# accepts data as a string by default theres no need for exception handling here 



                /*
                 This is added in the event that something was forgotten
                 */
                Console.WriteLine($"Would you like to add anything extra? Enter 'yes' or 'no': ");

                additional = Console.ReadLine(); 

                if (additional.ToLower() == "yes") // if additional variable has a value of "yes" it will execute. anything else will be ignored
                {

                    Console.WriteLine("Please enter any additional info here : ");

                    additionalYES = Console.ReadLine();
                }
                else {

                    Console.WriteLine("No aditional information added "); // This will output if the if statements conditions are not met
                }

                ingredients.Add(new Ingredient(ingName, ingredientQuantity, ingredientMeasurement, additionalYES)); // All the aquired information is added to the arraylist 
            }



            /*
             We are now onto the steps part of it.I will use a try catch for any dangerous data
             
             */

            try
            {

                Console.WriteLine("Enter the number of steps: "); 

                stepCount = int.Parse(Console.ReadLine()); // Stored and converted if applicable

            }
            catch (FormatException e)
            {
                Console.WriteLine("Steps requires a numerical input");

                return;
            }



            for (x = 0; x < stepCount; x++) // itterating using stepcount as a limiting factor 
            {
                Console.WriteLine($"Enter step {x + 1}: ");

                step = Console.ReadLine();

                Console.WriteLine("would you like to add any other steps or final touches? Enter 'yes ' or 'no' ");

                extraStep = Console.ReadLine(); // This is included for any steps that have been missed

                if (extraStep.ToLower() == "yes")
                {

                    Console.WriteLine("enter the extra step you would like to add : ");

                    extraStepYes = Console.ReadLine();
                }
                else {

                    Console.WriteLine("no additional steps ");

                }

                steps.Add(step); // Here i am adding the steps to the array

                steps.Add(extraStepYes); // same as above but for aditional steps 
            }

            Console.WriteLine("Details captured");

        }

        //************************************* end of capure method ********************************//





        //********************************************** start of print out ****************************//
        
        /*
         The purpose of this method is to display the information captured in the capture method
        - neatness mmust be presant
         */

        public void Print()
        {

            Console.WriteLine(" ----------- Recipe -------------  ");

            Console.WriteLine("\n");

            Console.WriteLine("---- Ingredients ----"); // header

            Console.WriteLine("\n");

            foreach (var ingredient in ingredients)
            {
                // Output the ingredient values from the array 
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} {ingredient.Addition} of {ingredient.Name} ");


            }

            Console.WriteLine("\n");

            Console.WriteLine(" ------------- Steps ----------------- "); // header

            Console.WriteLine("\n");

            for (int y = 0; y < steps.Count; y++)
            {


                Console.WriteLine($" {y + 1}.   {steps[y]} "); // This will output the values from the steps array


            }
        }


        //********************************************* end of print out ********************************//


        public void Scale()
        {
            double fact;

            try
            {
                Console.WriteLine("Enter how much you want to scale the recipe by (e.g., 0.5, 2, 3, etc): ");

                fact = double.Parse(Console.ReadLine()); // converting and storing user input 

                if (fact <= 0)
                {
                    Console.WriteLine("You cannot use values under 0");
                    return;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter numbers only.");
                return;
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred.");
                return;
            }
            finally
            {
                Console.WriteLine("Returning to the menu system...");
            }

            
            originalQuantities = new List<double>(); // creating an array list


            foreach (Ingredient ingredient in ingredients)
            {
                originalQuantities.Add(ingredient.Quantity); // adding to array list
            }

            /*
             the goal here is to scale the recipe, so the user will input a factor to scale by and it multiplies the original amout
             
             */
            foreach (Ingredient ingredient in ingredients)
            {
                ingredient.Quantity *= fact;
            }

            Console.WriteLine("Recipe scaled successfully!");

            Console.WriteLine(" ---------- Updated quantity of recipe ---------- ");

            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} of {ingredient.Name}"); // output quantity and name
            }
            Console.WriteLine(" ------------------------- ");
        }



            public void Reset()
            {
            if (originalQuantities == null)
            {
                Console.WriteLine("Scale the recipe first before attempting to reset");

                return;
            }

            for (int i = 0; i < ingredients.Count; i++)
            {
                ingredients[i].Quantity = originalQuantities[i];
            }

            Console.WriteLine("Recipe quantities reset to their original values.");

        }

            public void Clear()
            {
                ingredients.Clear();

                steps.Clear();
            }

        }
    }

//******************************************** end of file *************************************************//