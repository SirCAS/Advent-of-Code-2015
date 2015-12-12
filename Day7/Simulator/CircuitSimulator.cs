using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Day7.Model.Enums;
using AdventOfCode.Day7.Model.Interfaces;

namespace AdventOfCode.Day7.Simulator
{
    public class CircuitSimulator : ICircuitSimulator
    {
        public IDictionary<string, ushort?> RunSimulation(IList<IComponent> components)
        {
            IDictionary<string, ushort?> result = components.ToDictionary(x => x.OutputName, x => (ushort?)null);

            while (components.Any())
            {
                // Resolve missing components
                foreach (var item in components.ToList())
                {
                    // Determine type for appropiate handling
                    if (item.InputType == ComponentInputTypeEnum.TwoComponent)
                    {
                        var component = ((ITwoComponent) item);

                        // The inputs of a component could be a number or letter
                        if (!component.InputNames.All(x => IsNumber(x) || (result.ContainsKey(x) && result[x].HasValue)))
                            continue;

                        var inputs = component
                            .InputNames
                            .Select(x => IsNumber(x) ? ushort.Parse(x) : result[x])
                            .Select(x => x.Value)
                            .ToList();

                        result[component.OutputName] = component.Output(inputs);

                        components.Remove(item);
                    }
                    else
                    {
                        var component = ((IOneComponent)item);

                        var inputName = component.InputName;

                        if ((!result.ContainsKey(inputName) || !result[inputName].HasValue) && !IsNumber(inputName))
                            continue;

                        var input = (result.ContainsKey(inputName) && result[inputName].HasValue) ? result[inputName].Value : ushort.Parse(inputName);

                        result[component.OutputName] = component.Output(input);

                        components.Remove(item);
                    }
                }
            }

            return result;
        }

        private static bool IsNumber(string input)
        {
            ushort val;
            return ushort.TryParse(input, out val);
        }
    }
}
