using System.Collections.Generic;

namespace Day15.ConsoleApplication
{
    public class Recipe
    {
        public Recipe()
        {
            Ingredients = new Dictionary<Ingredient, int>();
        }

        public Dictionary<Ingredient, int> Ingredients { get; set; }
        
        public int Score { get; set; }
    }
}