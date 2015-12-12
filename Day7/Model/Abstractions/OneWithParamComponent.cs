using AdventOfCode.Day7.Model.Enums;
using AdventOfCode.Day7.Model.Interfaces;

namespace AdventOfCode.Day7.Model.Abstractions
{
    public abstract class OneWithParamComponent : IOneComponent
    {
        protected OneWithParamComponent(string inputName, string outputName, ushort parameter)
        {
            InputName = inputName;
            OutputName = outputName;
            Parameter = parameter;
        }

        public ComponentInputTypeEnum InputType { get { return ComponentInputTypeEnum.OneWithParamComponent; } }

        public string InputName { get; private set; }

        public string OutputName { get; private set; }

        public ushort Parameter { get; private set; }

        public abstract ushort Output(ushort input);
    }
}