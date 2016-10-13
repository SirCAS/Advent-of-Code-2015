using AdventOfCode.Day7.Model.Enums;

namespace AdventOfCode.Day7.Model.Interfaces
{
    public interface IOneComponent
    {
        string InputName { get; }

        ComponentInputTypeEnum InputType { get; }

        string OutputName { get; }

        ushort Output(ushort input);
    }
}