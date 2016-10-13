using AdventOfCode.Day7.Model.Abstractions;
using AdventOfCode.Day7.Model.Enums;
using AdventOfCode.Day7.Model.Interfaces;

namespace AdventOfCode.Day7.Model.Components
{
    public class NotComponent : OneComponent, IComponent
    {
        public NotComponent(string inputName, string outputName)
            : base(inputName, outputName)
        { }

        public ComponentTypeEnum Type
        {
            get { return ComponentTypeEnum.Not; }
        }

        public override ushort Output(ushort input)
        {
            return (ushort) ~input;
        }
    }
}