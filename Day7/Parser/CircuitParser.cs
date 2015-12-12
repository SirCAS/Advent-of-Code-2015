using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Day7.Common;
using AdventOfCode.Day7.Model;
using AdventOfCode.Day7.Model.Components;
using AdventOfCode.Day7.Model.Interfaces;

namespace AdventOfCode.Day7.Parser
{
    public class CircuitParser : ICircuitParser
    {
        private const string AndOperator = "AND";
        private const string OrOperator = "OR";
        private const string NotOperator = "NOT";
        private const string RshiftOperator = "RSHIFT";
        private const string LshiftOperator = "LSHIFT";
        private const string ArrowOperator = "->";

        public IList<IComponent> PaseComponents(IList<string> inputs)
        {
            return inputs.Select(ParseComponent).ToList();
        }

        public IComponent ParseComponent(string input)
        {
            string output = input.GetComponentLastPart(ArrowOperator);

            if (input.Contains(AndOperator))
            {
                return new AndComponent(new List<string> { input.GetComponentFirstPart(AndOperator), input.GetComponentMiddlePart(AndOperator, ArrowOperator) }, output);
            }

            if (input.Contains(OrOperator))
            {
                return new OrComponent(new List<string> { input.GetComponentFirstPart(OrOperator), input.GetComponentMiddlePart(OrOperator, ArrowOperator) }, output);
            }

            if (input.Contains(NotOperator))
            {
                return new NotComponent(input.GetComponentMiddlePart(NotOperator, ArrowOperator), output);
            }

            if (input.Contains(RshiftOperator))
            {
                var parameter = ushort.Parse(input.GetComponentMiddlePart(RshiftOperator, ArrowOperator));

                return new RshiftComponent(input.GetComponentFirstPart(RshiftOperator), output, parameter);
            }

            if (input.Contains(LshiftOperator))
            {
                var parameter = ushort.Parse(input.GetComponentMiddlePart(LshiftOperator, ArrowOperator));

                return new LshiftComponent(input.GetComponentFirstPart(LshiftOperator), output, parameter);
            }

            if (input.Contains(ArrowOperator))
            {
                string first = input.GetComponentFirstPart(ArrowOperator);

                ushort value = 0;
                if (ushort.TryParse(first, out value))
                {
                    return new InputComponent(output, value);
                }
                else
                {
                    return new LinkComponent(first, output);
                }
            }

            throw new ArgumentException("Invalid input param please verify the content of the input file");
        }
    }
}