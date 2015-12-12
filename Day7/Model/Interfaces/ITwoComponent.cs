using System.Collections.Generic;
using AdventOfCode.Day7.Model.Enums;

namespace AdventOfCode.Day7.Model.Interfaces
{
    public interface ITwoComponent
    {
        ComponentInputTypeEnum InputType { get; }
        IList<string> InputNames { get; }
        string OutputName { get; }
        ushort Output(IList<ushort> inputs);
    }
}