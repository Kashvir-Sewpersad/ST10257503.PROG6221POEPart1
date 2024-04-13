
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
        public void CaptureRecipeDetails()
        {

            /////////////////////////////// start of field declerations ////////////////////////////

            int stepCount;

            string step;

            int ingredientNumbers;

            string ingredientName;

            double ingredientQuantity;

            string ingredientMeasurement;

            int i;

            int x;

            //////////////////////////////// end of field declerations ////////////////////////////////// 


            Console.WriteLine("Enter how many ingridents will be used in this recipe : ");

            ingredientNumbers = int.Parse(Console.ReadLine());

            for (i = 0; i < ingredientNumbers; i++)
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

            for (x = 0; x < stepCount; x++)
            {
                Console.WriteLine($"Enter step {x + 1}: ");

                step = Console.ReadLine();

                steps.Add(step);
            }

            Console.WriteLine("Details captured");

        }

        //************************************* end of capure method ********************************//

        public void PrintRecipe() {
        
        
        
        }


        public void IncreaseScale() {
        
        
        
        }


        public void ResetToOriginal() { 
        
        
        }

        public void ClearData() { 
        
        
        
        }

    }
}

//******************************************** end of file *************************************************//