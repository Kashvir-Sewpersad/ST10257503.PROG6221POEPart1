using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10257503.PROG6221POEPart1
{
    public class Ingredient
    {

        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }


        public string Addition { get; set; }

        public Ingredient(string name, int quantity, string unit , string addition )
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Addition = addition;
        }
    }

    public class Step { 
    
    public string Steps { get; set; }
        public string additionSteps { get; set; }
    }
  /*  public steps1(string Ad  , string x)
    {
        additionSteps = Ad;
    
    }*/
}