using AdventOfCode.Day7.Model.Enums;
using AdventOfCode.Day7.Model.Interfaces;

namespace AdventOfCode.Day7.Model.Abstractions
{
    public abstract class OneComponent : IOneComponent
    {
        protected OneComponent(string inputName, string outputName)
        {
            InputName = inputName;
            OutputName = outputName;
        }

        public ComponentInputTypeEnum InputType { get { return ComponentInputTypeEnum.OneComponent; } }

        public string InputName { get; private set; }

        public string OutputName { get; private set; }

        public abstract ushort Output(ushort input);
    }
}