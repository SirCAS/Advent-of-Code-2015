using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Day7.Model.Components;
using AdventOfCode.Day7.Model.Enums;
using AdventOfCode.Day7.Model.Interfaces;

namespace AdventOfCode.Day7.Simulator
{
    public class CircuitSimulator
    {
        private IList<InputComponent> Inputs { get; set; }

        private IList<IComponent> Components { get; set; }

        public IDictionary<string, ushort?> RunSimulation(IList<IComponent> components)
        {
            LoadInstructions(components);

            IDictionary<string, ushort?> result = new Dictionary<string, ushort?>();

            result = Inputs.ToDictionary(x => x.OutputName, x => (ushort?) x.Value);

            foreach (var variable in Components.Select(x => x.OutputName))
            {
                result.Add(variable, null);
            }

            while (Components.Any())
            {
                // Resolve missing components
                foreach (var item in Components.ToList())
                {
                    // Determine type for appropiate handling
                    switch (item.InputType)
                    {
                        case ComponentInputTypeEnum.TwoComponent:
                            {
                                var component = ((ITwoComponent) item);

                                // The inputs of a component could be a number or letter
                                if (component.InputNames.All(x => IsNumber(x) || (result.ContainsKey(x) && result[x].HasValue)))
                                {
                                    var inputs = component
                                        .InputNames
                                        .Select(x => IsNumber(x) ? ushort.Parse(x) : result[x])
                                        .Select(x => x.Value)
                                        .ToList();

                                    result[component.OutputName] = component.Output(inputs);

                                    Components.Remove(item);

                                }
                            }
                            break;

                        case ComponentInputTypeEnum.OneComponent:
                        case ComponentInputTypeEnum.OneWithParamComponent:
                            {
                                var component = ((IOneComponent) item);

                                var inputName = component.InputName;

                                if ((result.ContainsKey(inputName) && result[inputName].HasValue) || IsNumber(inputName))
                                {
                                    var input = result[inputName].HasValue? result[inputName].Value : ushort.Parse(inputName);

                                    result[component.OutputName] = component.Output(input);

                                    Components.Remove(item);
                                }
                            }
                            break;
                    }
                }
            }

            return result;
        }

        private bool IsNumber(string input)
        {
            ushort val;
            return ushort.TryParse(input, out val);
        }

        private void LoadInstructions(IList<IComponent> components)
        {
            Inputs = components.Where(x => x.Type == ComponentTypeEnum.Input).Cast<InputComponent>().ToList();

            Components = components.Where(x => x.Type != ComponentTypeEnum.Input).ToList();
        }
    }
}
