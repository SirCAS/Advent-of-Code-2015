using System.Collections.Generic;

namespace Day15.ConsoleApplication
{
    public class Ingredient
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Durability { get; set; }
        public int Flavor { get; set; }
        public int Texture { get; set; }
        public int Calories { get; set; }
    }

    public class Recipe
    {
        public Dictionary<Ingredient, int> Ingredients { get; set; }
        public int Score { get; set; }
    }
}