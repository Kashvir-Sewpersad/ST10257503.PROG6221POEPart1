

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10257503.PROG6221POEPart1
{
    public class Recipe
    {

        public string Name { get; set; } // getter and setter for name
        public List<Ingredient> Ingredients { get; set; } // getter and setter for ingrident list values
        public List<string> Steps { get; set; } // getter and setter for steps list values/ data


        /*
         
         This method will retive the inputed values for calories located in functionality, use the internal sum method and return the total value for calories
         */

        public int TotalCalories
        {
            get { return Ingredients.Sum(ingredient => ingredient.Calories); } // getting  the data stored returning the sum of its parts 
        }


        public Recipe(string name)
        {
            Name = name;
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
        }

        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
        }

        public void AddStep(string step)
        {
            Steps.Add(step);
        }

    }
}
