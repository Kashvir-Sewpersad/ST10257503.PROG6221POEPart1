
//**************************************** start if file ************************************//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10257503.PROG6221POEPart1
{

    //***************************** start of ingredient class *******************************//
    public class Ingredient
    {

        public string Name { get; set; } // name getter and setter
        public double Quantity { get; set; } // quantity (grams) getter and setter
        public string Unit { get; set; } // units getter and setter (cups)


        public string Addition { get; set; } // getter and setter for any added process


        //--------------------- updates ----------------------------//
        /*
         as per the poe we need to store calories and food groups
         
         */
        public int Calories { get; set; } // calorie getter + setter 
        public string FoodGroup { get; set; } // food group getter and setter

        //-----------------------------------------------------------------------

        /*
         Updated to accept the calories and food groups
         */
        public Ingredient(string name, double quantity, string unit, string addition, int calories, string foodGroup)
        {
            Name = name;

            Quantity = quantity;

            Unit = unit;

            Addition = addition;

            //-----------------------------------------------------//

            Calories = calories; // added

            FoodGroup = foodGroup; // added
        }
    }

    //***************************** end of ingredient class *******************************//

    public class Step
    {

        public string Steps { get; set; }
        public string additionSteps { get; set; }
    }
   
}

//************************************* end of file ************************************//