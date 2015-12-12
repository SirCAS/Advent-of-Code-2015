using System.Collections.Generic;
using AdventOfCode.Day7.Model;
using AdventOfCode.Day7.Model.Interfaces;

namespace AdventOfCode.Day7.Parser
{
    public interface ICircuitParser
    {
        IList<IComponent> PaseComponents(IList<string> inputs);
        IComponent ParseComponent(string input);
    }
}