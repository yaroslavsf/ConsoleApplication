using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Console_App.Helpers
{
    /// <summary>
    /// Represents the controlling mechanism over input/output stream.
    /// </summary>
    public class InteractionHandler
    {
        readonly List<Interaction> _interactions;        
        public List<Interaction> Interactions { get => _interactions; }
        public InteractionHandler(List<Interaction> interactions)
        {
            _interactions = interactions;
        }
        public InteractionHandler()
        {
            _interactions = new();
        }
        public void Output(string message)
        {
            Console.Write(message);
            //log
            _interactions.Add(new Output(message));
        }
        public string StringInput()
        {
            string input = Console.ReadLine() ?? "";            
            //log
            _interactions.Add(new Input(input));
            return input;
        }
        public int NumberInput(Type? enumType = null)
        {
            bool isValidated = false;
            int input = 0;
            while (!isValidated)
            {
                try
                {
                    string str = Console.ReadLine()!;
        
                    //check on float/double
                    float checkFloat = float.Parse(str);
                    if (checkFloat % 1 != 0) throw new Exception("Die Zahl sollte nicht mit Fliesskomma sein");

                    input = int.Parse(str); 
                    
                    if (enumType != null)
                    {
                        object parsedEnumValue = Enum.Parse(enumType, input.ToString());

                        // Ensure that the parsed value is of the correct enum type
                        if (parsedEnumValue.GetType() == enumType)
                        {
                            // Ensure that enum contains input number
                            if (!Enum.IsDefined(enumType, input)) throw new IndexOutOfRangeException("Es gibt keine Option wie diese");

                            // Cast the object to the enum type and create an instance of Input
                            _interactions.Add(new Input((Enum)parsedEnumValue));
                        }                                           
                    }      
                    else
                    {
                        _interactions.Add(new Input(input));
                    }
                        

                    isValidated = true;
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (e is FormatException)
                        Console.WriteLine($"Die gegebene Eingabe ist keine Zahl");
                    else
                        Console.WriteLine($"Fehler bei der Eingabe einer Zahl: {e.Message}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Bitte geben Sie die Zahl erneut ein: ");
                }
            }
            return input;
        }
    }
}