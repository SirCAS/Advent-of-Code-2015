using AdventOfCode.Day7.Model.Abstractions;
using AdventOfCode.Day7.Model.Enums;
using AdventOfCode.Day7.Model.Interfaces;

namespace AdventOfCode.Day7.Model.Components
{
    public class LinkComponent : OneComponent, IComponent
    {
        public LinkComponent(string inputName, string outputName)
            : base(inputName, outputName)
        { }

        public ComponentTypeEnum Type
        {
            get { return ComponentTypeEnum.Link; }
        }

        public override ushort Output(ushort input)
        {
            return input;
        }
    }
}