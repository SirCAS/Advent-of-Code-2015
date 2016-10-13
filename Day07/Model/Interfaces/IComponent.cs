using AdventOfCode.Day7.Model.Enums;

namespace AdventOfCode.Day7.Model.Interfaces
{
    public interface IComponent
    {
        ComponentTypeEnum Type { get; }

        ComponentInputTypeEnum InputType { get; }

        string OutputName { get; }
    }
}