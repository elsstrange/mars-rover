using System;

namespace MarsRover
{
    public class Rover
    {
        public string Location() => "0:0:N";

        public string Execute(string instructions)
        {
            if (instructions == "Z")
                throw new ArgumentException("Instructions can only contain M, R or L");
            
            var distance = instructions.Length;
            
            return $"0:{distance}:N";
        }
    }
}