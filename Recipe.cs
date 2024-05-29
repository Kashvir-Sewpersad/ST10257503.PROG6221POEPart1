

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10257503.PROG6221POEPart1
{
    public class Recipe
    {


        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Steps { get; set; }


        /*
         
         This method will retive the inputed values for calories located in functionality, use the internal sum method and return the total value for calories
         */

        public int TotalCalories
        {
            get { return Ingredients.Sum(ingredient => ingredient.Calories); }
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
