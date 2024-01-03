using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Console_App.Helpers
{
    public enum Operation
    {
        Low,
        Medium,
        High
    }
    public class Input
    {
        public string Text { get; set; }
        public int Zahl { get; set; }
        public Operation Operation { get; set; }
    }
}
