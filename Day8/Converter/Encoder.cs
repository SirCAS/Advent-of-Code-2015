using System;
using System.Collections.Generic;
using System.Linq;

namespace Day8.Converter
{
    public class Encoder
    {
        private string[] dataSet;

        public Encoder(string[] input)
        {
            this.dataSet = input;
        }

        public string GetResult()
        {
            var resultList = new List<string>();
            foreach(var line in dataSet)
            {
                string newLine = line;
                for(int x=0; x<newLine.Length; ++x)
                {
                    if(newLine[x] == '\\')
                    {
                        newLine = newLine.Insert(x, "\\");
                        ++x;
                    }
                    else
                    if(newLine[x] == '"')
                    {
                        newLine = newLine.Insert(x, "\\");
                        ++x;
                    }
                }
                resultList.Add(newLine);
            }
            
             var resultArray = resultList
                .Select(x => x.Insert(0, "\"")) // Add leading "
                .Select(x => x.Append('"')) // Add trailing "
                .SelectMany(x => x)
                .ToArray();
            
            return new string(resultArray);
        }
    }
}
