using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day15.ConsoleApplication
{
    // OBS: This codes ONLY works with exactly four recipes
    //      Please refer to ParallelCookieCrafter for a robust solution
    public static class HardcodedCookieCrafter
    {
        private const int TotalAmount = 100;
        private const int TargetCalories = 500;

        public static Recipe GetAwesomeCookie(string dataFile)
        {
            // Load data from input file
            var ingredients = File.ReadAllLines(dataFile)
                .Select(x => x.Split(' '))
                .Select(x => new Ingredient
                {
                    Name = x[0].TrimEnd(':'),
                    Capacity = int.Parse(x[2].TrimEnd(',')),
                    Durability = int.Parse(x[4].TrimEnd(',')),
                    Flavor = int.Parse(x[6].TrimEnd(',')),
                    Texture = int.Parse(x[8].TrimEnd(',')),
                    Calories = int.Parse(x[10].TrimEnd(',')),
                })
                .ToList();

            var result = new List<Recipe>();

            for(int firstIngredient=0; firstIngredient <= TotalAmount; ++firstIngredient)
            {
                for(int secondIngredient=0; secondIngredient <= TotalAmount; ++secondIngredient)
                {
                    for(int thirdIngredient=0; thirdIngredient <= TotalAmount; ++thirdIngredient)
                    {
                        for(int fourthIngredient=0; fourthIngredient <= TotalAmount; ++fourthIngredient)
                        {
                            if(fourthIngredient + thirdIngredient + secondIngredient + firstIngredient == TotalAmount)
                            {
                                var recipe = CreateRecipe(new Dictionary<Ingredient, int>
                                {
                                    {ingredients[0], firstIngredient},
                                    {ingredients[1], secondIngredient},
                                    {ingredients[2], thirdIngredient},
                                    {ingredients[3], fourthIngredient},
                                });

                                if(recipe != null)
                                {
                                    result.Add(recipe);
                                }
                            }
                        }
                    }
                }
            }

            var winningScore = result.Max(x => x.Score);

            return result.First(x => x.Score == winningScore);
        }

        private static Recipe CreateRecipe(Dictionary<Ingredient, int> ingredients)
        {
            int capa = ingredients.Sum(x => x.Key.Capacity * x.Value);
            int dura = ingredients.Sum(x => x.Key.Durability * x.Value);
            int flav = ingredients.Sum(x => x.Key.Flavor * x.Value);
            int text = ingredients.Sum(x => x.Key.Texture * x.Value);
            int calo = ingredients.Sum(x => x.Key.Calories * x.Value);

            if(calo == TargetCalories)
            {
                var result = Math.Max(0, capa) * Math.Max(0, dura) * Math.Max(0,flav) * Math.Max(0,text);

                return new Recipe
                {
                    Ingredients = ingredients,
                    Score =  result
                };
            }

            return null;
        }
    }
}