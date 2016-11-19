using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Day15.ConsoleApplication
{
    public static class CookieCrafter
    {
        private const int TotalAmount = 100;

        public static Recipe GetAwesomeCookie1(string dataFile)
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

            var percent = 0;

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
                                result.Add(DoRec(new Dictionary<Ingredient, int>
                                {
                                    {ingredients[0], firstIngredient},
                                    {ingredients[1], secondIngredient},
                                    {ingredients[2], thirdIngredient},
                                    {ingredients[3], fourthIngredient},
                                }));
                            }

                            ++percent;
                        }
                    }
                }
                //Console.SetCursorPosition(0, Console.CursorTop);
                //double status = percent / 1030301.00;
                //Console.Write(status-1  + " %     ");
            }

            var winningScore = result.Max(x => x.Score);

            return result.First(x => x.Score == winningScore);
        }

        public static Recipe GetAwesomeCookie2(string dataFile)
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

            /*var result = new List<Recipe>();

            var percent = 0;

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
                                result.Add(DoRec(new Dictionary<Ingredient, int>
                                {
                                    {ingredients[0], firstIngredient},
                                    {ingredients[1], secondIngredient},
                                    {ingredients[2], thirdIngredient},
                                    {ingredients[3], fourthIngredient},
                                }));
                            }

                            ++percent;
                        }
                    }
                }
                Console.SetCursorPosition(0, Console.CursorTop);
                double status = percent / 1030301.00;
                Console.Write(status-1  + " %     ");
            }*/

            var result = DoIt(new Dictionary<Ingredient, int>(), ingredients, 0, TotalAmount);

            var winningScore = result.Max(x => x.Score);

            return result.First(x => x.Score == winningScore);
        }

        private static List<Recipe> DoIt(Dictionary<Ingredient, int> proposal, List<Ingredient> remaing, int current, int max)
        {
            var result = new List<Recipe>();
            if(remaing.Count == 1)
            {
                if(current >= max)
                {
                    return result;
                }
                else
                {
                    var mine = remaing[0];
                    for(int x=0; x<max-current; ++x)
                    {
                        if(proposal.ContainsKey(mine))
                        {
                            proposal.Remove(mine);
                        }
                        proposal.Add(mine, x);

                        var scoops = proposal.Sum(y => y.Value);
                        if(scoops == max)
                        {
                            return new List<Recipe>
                            {
                                DoRec(proposal)
                            };
                        }
                    }
                }
            } else {
                foreach(var mine in remaing)
                {
                    for(int x=0; x<= max - current; ++x)
                    {
                        if(proposal.ContainsKey(mine))
                        {
                            proposal.Remove(mine);
                        }
                        proposal.Add(mine, x);

                        var newList = new List<Ingredient>();
                        newList.AddRange(remaing);
                        newList.Remove(mine); 

                        result.AddRange(DoIt(proposal, newList, x, max));
                    }
                }
            }
            
            return result;
        }


        private static Recipe DoRec(Dictionary<Ingredient, int> ingredients)
        {
            int capa = ingredients.Sum(x => x.Key.Capacity * x.Value);
            int dura = ingredients.Sum(x => x.Key.Durability * x.Value);
            int flav = ingredients.Sum(x => x.Key.Flavor * x.Value);
            int text = ingredients.Sum(x => x.Key.Texture * x.Value);

            var result = Math.Max(0, capa) * Math.Max(0, dura) * Math.Max(0,flav) * Math.Max(0,text);

            return new Recipe
            {
                Ingredients = ingredients,
                Score =  result
            };
        }
    }
}