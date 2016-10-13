using AdventOfCode.Day7.Model.Abstractions;
using AdventOfCode.Day7.Model.Enums;
using AdventOfCode.Day7.Model.Interfaces;

namespace AdventOfCode.Day7.Model.Components
{
    public class LshiftComponent : OneWithParamComponent, IComponent
    {
        public LshiftComponent(string inputName, string outputName, ushort parameter)
            : base (inputName, outputName, parameter)
        { }

        public ComponentTypeEnum Type
        {
            get { return ComponentTypeEnum.Lshift; }
        }

        public override ushort Output(ushort input)
        {
            return (ushort) (input << Parameter);
        }
    }
}