using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Console_App.Helpers
{
    public class Interaction
    {
        public Interaction(string? text)
        {
            Text = text;
        }
        public Interaction() { }
        public string? Text { get; set; }        
    }
}
