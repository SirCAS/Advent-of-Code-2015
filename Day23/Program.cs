using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Day23.ConsoleApplication
{
    public class Computer
    {
        private int stackPointer = 0;
        private Dictionary<string, int> registers;

        public Computer(Dictionary<string, int> registers)
        {
            this.registers = registers;
        }

        public int GetRegisterValue(string register)
        {
            return registers[register];
        }

        public void ExecuteInstructions(IList<string> instructions)
        {
            while(stackPointer >= 0 && stackPointer < instructions.Count)
            {
                var instruction = instructions[stackPointer].Replace(",", string.Empty).Split(' ');
                switch(instruction[0])
                {
                    case "hlf":
                        registers[instruction[1]] /= 2;
                        ++stackPointer;
                        break;

                    case "tpl":
                        registers[instruction[1]] *= 3;
                        ++stackPointer;
                        break;

                    case "inc":
                        ++registers[instruction[1]];
                        ++stackPointer;
                        break;

                    case "jmp":
                        stackPointer += int.Parse(instruction[1]);
                        break;

                    case "jie":
                        if(registers[instruction[1]] % 2 == 0)
                            stackPointer += int.Parse(instruction[2]);
                        else
                            ++stackPointer;
                        break;

                    case "jio":
                        if(registers[instruction[1]] == 1)
                            stackPointer += int.Parse(instruction[2]);
                        else
                            ++stackPointer;
                        break;

                    default:
                        throw new NotSupportedException();
                }
            }
        }
    }


    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("+-------------------------+");
            Console.WriteLine("| Advent of Code - Day 23 |");
            Console.WriteLine("+-------------------------+");

            var input = File.ReadLines("input.txt").ToList();

            var b_part1 = RunProgram(input, false);
            var b_part2 = RunProgram(input, true);

            Console.WriteLine($"Part 1: Value of register b is {b_part1}");
            Console.WriteLine($"Part 2: Value of register b is {b_part2}");
            
            Console.WriteLine($"  -Gruss Gott");
        }

        public static int RunProgram(IList<string> input, bool isPart2)
        {
            var registerInitialzation = new Dictionary<string, int>
            {
                {"a", isPart2 ? 1 : 0 } , {"b", 0}
            };

            var computer = new Computer(registerInitialzation);

            computer.ExecuteInstructions(input);

            return computer.GetRegisterValue("b");
        }

   }
}