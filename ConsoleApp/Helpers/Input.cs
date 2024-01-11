using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Console_App.Helpers
{
    /// <summary>
    /// Represents the unit of input in one of the initialized fields. 
    /// </summary>
    public class Input : Interaction
    {
        public Enum? Operation { get; set; }
        public int? Zahl { get; set; }
        public Input(Enum operation)
        {
            Operation = operation;
        }
        public Input(string str) : base(str) { }
        public Input(int number) 
        {
            Zahl = number; 
        }        
    }
}
