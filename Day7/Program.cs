using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Day7
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public enum ComponentTypeEnum { Input, Not, And, Or, Rshift, Lshift }

    public class Component
    {
        public ComponentTypeEnum Type { get; set; }
    }

    public class TwoInputComponent : Component
    {
        public ComponentTypeEnum Type { get; set; }
        public string Input1 { get; set; }
        public string Input2 { get; set; }
        public string Output { get; set; }
    }

    public class OneInputComponent : Component
    {
    
    }



    public class CircuitParser
    {
        /*
            123 -> x
            456 -> y
            x AND y -> d
            x OR y -> e
            x LSHIFT 2 -> f
            y RSHIFT 2 -> g
            NOT x -> h
            NOT y -> i
         */

        public Component ParseComponent(string input)
        {
            var result = new Component
            {
                Type = FindType(input)
            };

            if()




            return result;
        }

        public IList<Component> PaseComponents(IList<string> inputs)
        {
            return inputs.Select(ParseComponent).ToList();
        }

        private ComponentTypeEnum FindType(string input)
        {
            if(input.Contains("AND"))
                return ComponentTypeEnum.And;
            
            if(input.Contains("OR"))
                return ComponentTypeEnum.Or;
            
            if(input.Contains("LSHIFT"))
                return ComponentTypeEnum.Lshift;
            
            if(input.Contains("RSHIFT"))
                return ComponentTypeEnum.Rshift;
            
            if(input.Contains("NOT"))
                return ComponentTypeEnum.Not;
            
            return ComponentTypeEnum.Input;
        }

    }
}
