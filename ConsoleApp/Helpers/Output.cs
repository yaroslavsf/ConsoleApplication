using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Console_App.Helpers
{
    /// <summary>
    /// Represents the unit of output in one of the initialized fields. 
    /// </summary>
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
