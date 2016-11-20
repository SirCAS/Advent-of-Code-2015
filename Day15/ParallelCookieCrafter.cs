using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Day15.ConsoleApplication
{
    public static class ParallelCookieCrafter
    {
        /// <summary>
        /// The maximum allowed scoops of ingredients
        /// </summary>
        private const int TotalAmount = 100;
        
        /// <summary>
        /// Determine the total number of concurrent workers when bruteforcing
        /// 1 means one worker pr. ingredient, 2 means two worker pr. ingredient, etc.
        /// </summary>
        private const int ParallelizingFactor = 2;

        /// <summary>
        /// Determine the target for calcories in the cookies
        /// If value is null then there will be no validation of calcories
        /// </summary>
        private static int? CaloriesTarget = 500;
        
        private static Ingredient[] ingredients;
        private static ConcurrentBag<Recipe> result;

        public static Recipe GetAwesomeCookie(string dataFile)
        {
            // Load data from input file
            ingredients = File.ReadAllLines(dataFile)
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
                .ToArray();

            // List containing all valid recipies
            result = new ConcurrentBag<Recipe>();

            // Determine partition sizes for parallizing
            int partitionSize = (TotalAmount / (ingredients.Length * ParallelizingFactor));
            int partitionCount = (ingredients.Length * ParallelizingFactor);
            
            // Setup parallel bruteforce
            Parallel.For(0, partitionCount, index =>
            {
                // Calculate indexes
                int startIndex = index * partitionSize;
                int endIndex = (index + 1) * partitionSize - 1;

                // Catch left overs (TODO: Better handling of rounding)
                if(index == partitionCount - 1)
                    endIndex = TotalAmount;

                // Create individual coefficient arrays for each worker
                var coefficients = new int[ingredients.Length];
                
                // Propagate mutations
                FindRecipes(coefficients, startIndex, endIndex, 0);
            });

            // Return the highest score (TODO: multiple winners are potential possible)
            var winningScore = result.Max(x => x.Score);
            return result.First(x => x.Score == winningScore);
        }

        private static void FindRecipes(int[] coefficients, int startIndex, int endIndex, int length)
        {
            for(int x=startIndex; x <= endIndex; ++x)
            {
                coefficients[length] = x;
                if(length < ingredients.Length - 1)
                {
                    FindRecipes(coefficients, 0, TotalAmount, length + 1);
                }
                else
                {
                    FindRecipes(coefficients);
                }
            }
        }

        private static void FindRecipes(int[] coefficients)
        {
            if(coefficients.Sum() == 100)
            {
                var recipe = new Recipe();

                int capa = 0, dura = 0, flav = 0, text = 0, calor = 0;
                
                for(uint y=0; y < ingredients.Length; ++y)
                {
                    capa += ingredients[y].Capacity * coefficients[y];
                    dura += ingredients[y].Durability * coefficients[y];
                    flav += ingredients[y].Flavor * coefficients[y];
                    text += ingredients[y].Texture * coefficients[y];
                    calor += ingredients[y].Calories * coefficients[y];
                    
                    recipe.Ingredients.Add(ingredients[y], coefficients[y]);
                }

                if(CaloriesTarget.HasValue && calor == CaloriesTarget.Value)
                {
                    recipe.Score = Math.Max(0, capa) * Math.Max(0, dura) * Math.Max(0, flav) * Math.Max(0, text);

                    result.Add(recipe);
                }
            }
        }
    }
}