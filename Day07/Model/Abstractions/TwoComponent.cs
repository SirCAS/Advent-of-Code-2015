using System.Collections.Generic;
using AdventOfCode.Day7.Model.Enums;
using AdventOfCode.Day7.Model.Interfaces;

namespace AdventOfCode.Day7.Model.Abstractions
{
    public abstract class TwoComponent : ITwoComponent
    {
        protected TwoComponent(IList<string> inputNames, string outputName)
        {
            InputNames = inputNames;
            OutputName = outputName;
        }

        public ComponentInputTypeEnum InputType { get { return ComponentInputTypeEnum.TwoComponent; } }

        public IList<string> InputNames { get; private set; }

        public string OutputName { get; private set; }

        public abstract ushort Output(IList<ushort> inputs);
    }
}