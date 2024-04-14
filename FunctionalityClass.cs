
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
        //****************************start of storage system ***********************//

        private List<Ingredient> ingredients;

        private List<string> steps;

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

            string step;

            int ingredientNum;

            string ingName;

            string additional;

            string additionalYES = " ";

            string extraStep;

            string extraStepYes = " ";

            int ingredientQuantity;

            string ingredientMeasurement;

            int i;

            int x;

            //////////////////////////////// end of field declerations ////////////////////////////////// 

           

            Console.WriteLine(" This app works in grams (g)");

            Console.WriteLine("Follow the Prompts  ");







            try
            {

                Console.WriteLine("Enter how many ingridents will be used in this recipe : ");

                ingredientNum = int.Parse(Console.ReadLine());


            }
            catch (FormatException e)
            {
                Console.WriteLine(" ENTER NUMBERS ONLY ");

                return;
            }


            for (i = 0; i < ingredientNum; i++)
            {
                Console.WriteLine($"Enter the name of ingredient {i + 1}: ");

                ingName = Console.ReadLine();


                try
                {
                    Console.WriteLine($"Enter the quantity for {ingName}: ");

                    ingredientQuantity = int.Parse(Console.ReadLine());
                }
                catch (FormatException e) {

                    Console.WriteLine("Please enter your answer in numerical notation");

                    return;
                }


                Console.WriteLine($"Enter the measurement for the {ingName}: ");


                ingredientMeasurement = Console.ReadLine();




                Console.WriteLine($"Would you like to add anything extra? Enter 'yes' or 'no': ");

                additional = Console.ReadLine();

                if (additional.ToLower() == "yes") {

                    Console.WriteLine("Please enter any additional info here : ");

                    additionalYES = Console.ReadLine();
                }
                else {

                    Console.WriteLine("No aditional information added ");
                }

                ingredients.Add(new Ingredient(ingName, ingredientQuantity, ingredientMeasurement, additionalYES));
            }





            try
            {

                Console.WriteLine("Enter the number of steps: ");

                stepCount = int.Parse(Console.ReadLine());

            }
            catch (FormatException e)
            {
                Console.WriteLine("Steps requires a numerical input");

                return;
            }



            for (x = 0; x < stepCount; x++)
            {
                Console.WriteLine($"Enter step {x + 1}: ");

                step = Console.ReadLine();

                Console.WriteLine("would you like to add any other steps or final touches? Enter 'yes ' or 'no' ");

                extraStep = Console.ReadLine();

                if (extraStep.ToLower() == "yes")
                {

                    Console.WriteLine("enter the extra step you would like to add : ");

                    extraStepYes = Console.ReadLine();
                }
                else {

                    Console.WriteLine("no additional steps ");

                }

                steps.Add(step);

                steps.Add(extraStepYes);
            }

            Console.WriteLine("Details captured");

        }

        //************************************* end of capure method ********************************//





        //********************************************** start of print out ****************************//
        public void Print()
        {

            Console.WriteLine(" ----------- Recipe -------------  ");

            Console.WriteLine("\n");

            Console.WriteLine("First we have Ingredients");

            Console.WriteLine("\n");

            foreach (var ingredient in ingredients)
            {

                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} {ingredient.Addition} of {ingredient.Name} ");


            }

            Console.WriteLine("\n");

            Console.WriteLine(" ------------- Steps ----------------- ");

            Console.WriteLine("\n");

            for (int y = 0; y < steps.Count; y++)
            {


                Console.WriteLine($" {y + 1}.   {steps[y]} ");


            }
        }


        //********************************************* end of print out ********************************//


        public void Scale()
        {
            double fact;

            // string updatedQuantities;


            

                try
                {

                    Console.WriteLine("Enter how much you want to scale the recipe by I.e 0.5, 2, 3 etc : ");


                    fact = double.Parse(Console.ReadLine());
                    if (fact <= 0) {
                        Console.WriteLine("You cannot use values under 0");
                        return ;
                    }
                    
                }


                catch (FormatException e)
                {

                    Console.WriteLine("Enter numbers please");
                    return;
                }
                catch (DivideByZeroException e)
                {

                    Console.WriteLine("you cannot divide by zero!");

                    return;
                }
                catch (Exception e)
                {

                    Console.WriteLine("Theres been an error");
                    return;
                }
                finally {

                    Console.WriteLine("You will be relocated to the menu system ");

                }





                foreach (Ingredient ingredient in ingredients)

                {

                    ingredient.Quantity *= fact;

                }



                Console.WriteLine("Recipe scaled successfully!");



                /* we will need to display the increased size of the recipe */

                Console.WriteLine(" ---------- Updated  quantity of recipe ---------- ");

                foreach (var ingredient in ingredients)
                {

                    Console.WriteLine($"{ingredient.Quantity * fact}  of {ingredient.Name} ");


                }
            }



            public void Reset()
            {


            }

            public void Clear()
            {
                ingredients.Clear();

                steps.Clear();
            }

        }
    }

//******************************************** end of file *************************************************//