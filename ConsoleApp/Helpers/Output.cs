using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Console_App.Helpers
{
    public class Output : Interaction
    {
        public Output(string message) : base(message)
        {
            Zeitpunkt = DateTimeOffset.Now;
        }
        public Output(string message, DateTimeOffset time) : base(message)
        {
            Zeitpunkt = time;
        }

        public DateTimeOffset Zeitpunkt { get; set; }
    }
    
}
