using AdventOfCode.Day7.Model.Abstractions;
using AdventOfCode.Day7.Model.Enums;
using AdventOfCode.Day7.Model.Interfaces;

namespace AdventOfCode.Day7.Model.Components
{
    public class InputComponent : IComponent
    {
        public InputComponent(string outputName, ushort value)
        {
            OutputName = outputName;
            Value = value;
        }

        public ComponentInputTypeEnum InputType { get { return ComponentInputTypeEnum.OneComponent; } }

        public ComponentTypeEnum Type { get { return ComponentTypeEnum.Input; } }

        public ushort Value { get; private set; }

        public string OutputName { get; private set; }
    }
}
