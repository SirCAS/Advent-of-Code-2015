using System.Collections.Generic;
using AdventOfCode.Day7.Model.Abstractions;
using AdventOfCode.Day7.Model.Enums;
using AdventOfCode.Day7.Model.Interfaces;

namespace AdventOfCode.Day7.Model.Components
{
    public class OrComponent : TwoComponent, IComponent
    {
        public OrComponent(IList<string> inputNames, string outputName)
            : base(inputNames, outputName)
        { }

        public ComponentTypeEnum Type
        {
            get { return ComponentTypeEnum.Or; }
        }

        public override ushort Output(IList<ushort> inputs)
        {
            ushort output = inputs[0];

            for (int x = 1; x < inputs.Count; ++x)
            {
                output |= inputs[x];
            }

            return output;
        }
    }
}