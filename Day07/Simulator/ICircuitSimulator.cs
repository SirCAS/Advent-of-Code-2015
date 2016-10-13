using System.Collections.Generic;
using AdventOfCode.Day7.Model.Interfaces;

namespace AdventOfCode.Day7.Simulator
{
    public interface ICircuitSimulator
    {
        IDictionary<string, ushort?> RunSimulation(IList<IComponent> components);
    }
}