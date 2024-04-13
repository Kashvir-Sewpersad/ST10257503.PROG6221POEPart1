
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
        public void CaptureRecipeDetails() {

            /////////////////////////////// start of field declerations ////////////////////////////
            
            int stepCount;
            string step;
            int ingredientNumbers;

            string ingredientName;
            double ingredientQuantity;
            string ingredientMeasurement;

            //////////////////////////////// end of field declerations ////////////////////////////////// 
           

            Console.WriteLine("Please enter how many ingredients are needed for this recipe: ");

            ingredientNumbers = int.Parse(Console.ReadLine());

            for (int i = 0; i < ingredientNumbers; i++)
            {
                Console.WriteLine($"Enter the name of ingredient {i + 1}: ");

                ingredientName = Console.ReadLine();

                Console.WriteLine($"Enter the quantity for {ingredientName}: ");

                ingredientQuantity = double.Parse(Console.ReadLine());

                Console.WriteLine($"Enter the measurement for the {ingredientName}: ");


                ingredientMeasurement = Console.ReadLine();

                ingredients.Add(new Ingredient(ingredientName, ingredientQuantity, ingredientMeasurement));
            }

            Console.WriteLine("Enter the number of steps: ");
            stepCount = int.Parse(Console.ReadLine());

            for (int x = 0; x < stepCount; x++)
            {
                Console.WriteLine($"Enter step {x + 1}: ");
                step = Console.ReadLine();
                steps.Add(step);
            }

            Console.WriteLine("Details captured");

        }


    }
}


//******************************************** end of file *************************************************//