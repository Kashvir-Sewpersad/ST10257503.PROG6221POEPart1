
//******************************************** start of file *************************************************//

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ST10257503.PROG6221POEPart1
{
    /// <summary>
    /// 
    /// 
    /// 
    /// 
    /// ------------------------------------------ Required changes based on lecturer feedback ------------------------------------------- ///
    /// 
    /// 
    /// 1) improved exception handling (with regards to null input) : trying 
    /// 
    /// 2) Users need to be prompted to confirm that they would like to clear data   : CHECK
    /// 
    /// 3) readme requires additional data : IN PROGRESS
    /// 
    /// 4) The  system should be able to print in colour    : CHECK
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// ------------------------------------------ End of requiired changes -------------------------------------------------------------///
    /// 
    /// 
    /// 
    /// 
    /// </summary>
    /// 

    /*
     
     The purpose of this class is to contain the functionality or worker methods which will be called in the switch statement in the main method
     
     */
    internal class FunctionalityClass


    {
        //**************************** start of storage system ***********************//



        public List<Ingredient> ingredients; // I have created an array list to store the ingredents

        public List<string> steps; // Here I have created one to store the steps involed in the recipe

        public List<double> originalQuantities; // This is to store the original values so when we update via scale we still have the originals to work with


        public Dictionary<string, Recipe> recipes; // i have created a dictonary of type string to store the recipes. This will allow us later to display in aphabetical order 

        // Delegate for notification
        public delegate void CaloriesExceededHandler(string recipeName);

        public event CaloriesExceededHandler OnCaloriesExceeded;




        /*
         side note, I should have created a seperate class for the steps, including getters and setters however for this case its not nessesary 
         */

        //**************************** end of storage system ***********************//





        //******************************* start of constructor ***********************//
        public FunctionalityClass()
        {
            ingredients = new List<Ingredient>(); // created a instance for Ingrident

            steps = new List<string>(); // Craeted an instance for steps

            recipes = new Dictionary<string, Recipe>(); // created an instance for recipe
        }

        //******************************* end of constructor ***********************//



        //************************************* start of capure method ********************************//


        /*
         
         The purpose of this mwthod is to capture the details regarding the recipe
         we will need to capture: name, quantity and quantity
         
         */
        /// <summary>
        /// 
        /// </summary>
        public void Capture()
        {


            //************************************************** start of alterations *******************************************//


            string recipeName; // Added a variable type string to store the name 


            int calories; // created a variable type interger to store the calories. I was going to go double or float, seemed excessive 

            string foodGroup; // created a variable type string to store the food groups



            //************************************************** end of alterations ***********************************************//



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
            Console.WriteLine("\n");
            Console.WriteLine("Follow the Prompts  ");

            Console.WriteLine("All values must be added as grams");


            //************************  start of name addition and storage *****************************//

            /*
            As per the requirements of part 2 users must be able to add an ingrident name for each ingrident
             */



            Console.WriteLine("Please enter the recipe name : "); // prompt for recipe name. I have left out exception handling here because it seems to restrictive on users

            recipeName = Console.ReadLine(); 



            //***************************** end of name addition and storage ********************************//



            if (recipes.ContainsKey(recipeName)) // soooooooooo what im doing here is checking the recipe dictionary to see if theres a recipe with the same name 
            {
                Console.WriteLine("Recipe already exists. Please enter a unique name."); // if there is a recipe with the same name the user will be notified
                return;
            }

            Recipe recipe = new Recipe(recipeName); //  creating an instance of Recipe ()



            try // try block to detect any errors on dangerous code
            {

                Console.WriteLine("Enter how many ingridents will be used in this recipe : "); // Promt to user

                ingredientNum = int.Parse(Console.ReadLine()); // Input will be converted and store


            }
            catch (FormatException e)
            {
                Console.WriteLine("You seem to have made a mistake" + e.Message); // SO taking mr.Kims advice i have improved my exceptionhandling by displaying the error message


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
                    Console.WriteLine($"Enter the quantity for {ingName} in grams (g): "); // prompt 

                    ingredientQuantity = int.Parse(Console.ReadLine()); // Variable will be screened, converted and stored 
                }
                catch (FormatException e)
                {
                    Console.WriteLine("You seem to have made a mistake" + e.Message); // display of exception encountered 
                    Console.WriteLine("Please enter your answer in numerical notation"); // output message 

                    return;
                }





                try
                {
                    Console.WriteLine($"Enter the number of calories for {ingName}: "); // testing user input for calories 

                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid. Please enter a  number.");
                }
                catch (OverflowException) // so for my calories i set it ass interger which is from -2,147,483,648 to 2,147,483,647 . if that value is exceeded the code can break which is why i have overflow
                {
                    Console.WriteLine("Input is too large. Please enter a smaller number.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("You seem to have made a mistake" + e.Message);
                }


                calories = int.Parse(Console.ReadLine());

                if (calories >= 300)
                {
                    Console.ForegroundColor = ConsoleColor.Red; // set to red
                    Console.WriteLine($"Warning: The recipe '{recipeName}' exceeds 300 calories."); // output if calories are over 300 in red to signify danger 
                    Console.ResetColor(); // back to default
                    Console.WriteLine("You may want to reduce portion size or remove item");
                    Console.WriteLine("Would you like to reduce the calories Yes or No"); // i am giving the user the ability to re enter their value through a s series of nested if staements 
                    string alter = Console.ReadLine();

                    if (alter.ToLower() == "yes") // nested if statement 
                    {
                        Console.WriteLine($"Enter the number of calories for {ingName}: ");
                        calories = int.Parse(Console.ReadLine()); // if the second if statement executes the value for calorie will be updated 

                    }

                }



                Console.WriteLine($"Enter the food group for {ingName}: "); // Promt for food group

                foodGroup = Console.ReadLine();

            



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
                else
                {

                    Console.WriteLine("No aditional information added "); // This will output if the if statements conditions are not met
                }

                //  ingredients.Add(new Ingredient(ingName, ingredientQuantity, ingredientMeasurement, additionalYES)); // All the aquired information is added to the arraylist 



                Ingredient ingredient = new Ingredient(ingName, ingredientQuantity, ingredientMeasurement, additionalYES, calories, foodGroup); // adding to ingridents
                recipe.AddIngredient(ingredient);



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
                Console.WriteLine("You seem to have made a mistake" + e.Message);
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
                else
                {

                    Console.WriteLine("no additional steps ");



                }

                recipe.AddStep(step); // Here i am adding the steps to the array

                recipe.AddStep(extraStepYes); // same as above but for aditional steps
                                              // 


            }




            recipes.Add(recipeName, recipe);

            if (recipe.TotalCalories > 300)
            {
                OnCaloriesExceeded?.Invoke(recipeName); // delegate
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

            Console.WriteLine("Recipes: ");
            foreach (var recipe in recipes.Values.OrderBy(r => r.Name)) // im using a lamda to sort and produce recipes in alphebetical order 
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"- {recipe.Name}"); // output recipe names stored 
                Console.ResetColor();
            }
        }

        public void DisplayRecipe(string recipeName)
        {
            if (recipes.ContainsKey(recipeName)) // looking for recipes with same name 
            {
                Recipe recipe = recipes[recipeName];
                Console.WriteLine($"Recipe: {recipe.Name}");
                Console.WriteLine("Ingredients:");
                foreach (var ingredient in recipe.Ingredients) // looping through ingridents 
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($" {ingredient.Name} {ingredient.Quantity + " Grams (g) "} {ingredient.Unit + " Cups "}   ({ingredient.Calories} calories, {ingredient.FoodGroup})"); // displaying the values stored in it 
                    Console.ResetColor();
                }
                Console.WriteLine("Steps:");
                for (int i = 0; i < recipe.Steps.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{i + 1}. {recipe.Steps[i]}"); // outputing the steps 
                    Console.ResetColor();
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Total Calories: {recipe.TotalCalories}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }



        //********************************************* end of print out ********************************//


        public void Scale()
        {
            double fact;

            try
            {

                Console.WriteLine("Enter how much you want to scale the recipe by (e.g., 0.5, 2, 3, etc): ");
                //  Console.WriteLine("Ensure to use a comma ( , ) if scaling up or down by a fraction");


                /*
                 .Replace('.' , ',') needed to be added. the program would not read a ' . ' and jumpp straight into the catch block when scaling up or down with a fraction
                 
                 */
                fact = double.Parse(Console.ReadLine().Replace('.', ',')); // converting and storing user input 

                if (fact <= 0) // This prevents users from adding values under 0
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
            catch (Exception) // this will execute if all other catches fail 
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
                // ingredient.Unit *= fact; 
            }

            Console.WriteLine("Recipe scaled successfully!");


            Console.WriteLine(" ---------- Updated quantity of recipe ---------- ");

            foreach (var ingredient in ingredients)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{ingredient.Quantity} of {ingredient.Name}"); // output quantity and name
                Console.ResetColor();

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
                ingredients[i].Quantity = originalQuantities[i]; // This sets the values from the ingrident array to the original array values
            }

            Console.WriteLine("Recipe quantities reset to their original values."); // output once action is confirmed

        }

        public void Clear()
        {
            //***************** start of field decclerations ********************//

            string userChoice;

            //***************** end of field declerations *******************//


            try
            {

                Console.WriteLine("Are you sure you would like to clear this recipe ? "
                    + "\n"
                    + "1 for Yes "
                    + "\n"
                    + "2 for No");

            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred: {ex.Message}");

            }

            userChoice = Console.ReadLine();

            switch (userChoice)
            {

                case "1":

                    Console.WriteLine("This recipe will now be removed from the system "); // added as per lecturer feedback

                    ingredients.Clear();

                    steps.Clear();

                    break;



                case "2":

                    Console.WriteLine("This recipe will remain unchanged");

                    break;

                default:

                    Console.WriteLine("Whoops!!!! Theres been an Unforseen error ");

                    break;
            }

        }

        /*
         
         
         So i decided to add this in so users know what ingridents fall into which category
         It is set to display in color 
         It is called in the main method
         
         
         */
        public void Mesasge()
        {

            Console.WriteLine("Please Enter Your Name : "); // prompt for user name
            String FirstName = Console.ReadLine();

            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome " + FirstName); // output name 
            Console.ResetColor();
            Console.WriteLine("\n");

            Console.WriteLine("This Is A Recipe App So Heres A Quick Brief On The 7 Food Groups");


            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1.Fruits");
            Console.WriteLine("Rich in vitamins, minerals , fiber, and antioxidants. Fruits are healty but can have a lot of calories");
            Console.ResetColor();


            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("2.Vegetables");
            Console.WriteLine("High in vitamins , minerals (iron,  magnesium), fiber, and antioxidants. These are generally lower in calories than fruit");
            Console.ResetColor();


            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("3.Grains");
            Console.WriteLine("Provides carbs, fiber, B vitamins, iron and magnesium. These can be good in moderation Commonly found in items in the forms of seeds");
            Console.ResetColor();


            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("4.Protein");
            Console.WriteLine("Rich in protein, B vitamins B12, iron, zinc, and essential fatty acids. This is a building block and should be consumed in moderation.Commonly found in items such as meat or beans");
            Console.ResetColor();


            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("5.Dairy");
            Console.WriteLine("High in calcium, Whey protein, vitamin D, and other essential nutrients like  potassium.Commonly found in milk products like Cheese");
            Console.ResetColor();

            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("6.Oils and Fat");
            Console.WriteLine("Provide essential fatty acids, vitamin E, and energy.These aid in absorbsion of nutrients. Fat and oils are found in all organic matter");
            Console.ResetColor();

            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("7.Sweets and Sugars");
            Console.WriteLine("While not essential, they can provide quick energy. However, consumption should be limited due to potential negative health effects. These are high in calories");
            Console.ResetColor();
            Console.WriteLine("\n");
        }

    }

}

//******************************************** end of file *************************************************//