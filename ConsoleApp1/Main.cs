using _01_Console_App.Helpers;
using System;
using System.Drawing;

namespace _01_Console_App
{
    class ConsoleApplication
    {
        readonly List<int> _numbers = new();
        readonly List<string> _strings = new();
        readonly List<List<char>> _pyramid = new();

        public void Launch()
        {
            while (true)
            {
                switch (Menu())
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        Numbers();
                        break;
                    case 2:
                        Text();
                        break;
                    case 3:
                        Pyramid();
                        break;
                    default:
                        Console.WriteLine("Unhandled option error in Menu() has occured");
                        break;
                }
            }
        }
        /// <summary>
        /// Method <c>Menu</c> picks the operation from user
        /// </summary>
        /// <returns>
        /// 1 - Option with number function;
        /// 2 - Option with text function;
        /// 3 - Option with pyramide;
        /// 0 - Exit
        /// </returns>
        public int Menu()
        {
            Console.WriteLine("1: Operationen mit Zahlen");
            Console.WriteLine("2: Operationen mit Texten");
            Console.WriteLine("3: Pyramide von gewisser Höhe bauen");
            Console.WriteLine("0: Exit");
            Console.Write("Bitte wähle den entsprechenden Eintrag aus:");
            return IntegerInput(0, 3);
        }
        public void Numbers()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Hier ist die Liste: [" + string.Join(", ", _numbers) + "]");
                Console.WriteLine("1: Hinzufügen\n2: Addieren alle Zahlen\n3: Generieren 5 random Zahlen\n4: Finden min/max\n5: Sortieren\n6: Zurück");
                Console.Write("Option eingeben: ");
                int option = IntegerInput(1, 5);
                switch (option)
                {
                    case 1:
                        //add
                        Console.Write("Geben Sie die hinzuzufügende Zahl ein: ");
                        int number = IntegerInput();
                        _numbers.Add(number);
                        Console.Clear();
                        break;
                    case 2:
                        int sum = 0;
                        foreach (int i in _numbers)
                        {
                            sum += i;
                        }
                        Console.Clear();
                        Console.WriteLine($"Summe aller Zahlen:{sum}");
                        break;
                    case 3:
                        //generate
                        Random random = new Random();
                        for (int i = 0; i < 5; i++)
                        {
                            int randomNumber = random.Next(100);
                            _numbers.Add(randomNumber);
                        }
                        Console.Clear();
                        Console.WriteLine("Neue 5 generierte Werte wurden hinzugefügt");
                        break;
                    case 4:
                        //min/max
                        Console.Clear();
                        Console.WriteLine($"Min: {_numbers.Min()}, Max: {_numbers.Max()}");
                        break;
                    case 5:
                        //sort
                        _numbers.Sort();
                        Console.Clear();
                        Console.WriteLine("Liste ist sortiert");
                        break;
                    //back to main menu
                    case 6:
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Unhandled option error in Numbers() has occured");
                        break;
                }
            }
        }

        public void Text()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Hier ist die Liste: [" + string.Join(", ", _strings) + "]");
                Console.WriteLine("1: Hinzufügen\n2: Generieren 5 random Strings\n3: Sortieren alphabetisch\n4: Sortieren nach Länge\n5: Zurück");
                Console.Write("Option eingeben: ");
                int option = IntegerInput(1, 5);
                switch (option)
                {
                    case 1:
                        //add 
                        Console.Write("Geben Sie die hinzuzufügende Zeichenfolge ein: ");
                        string str = Console.ReadLine() ?? "";
                        _strings.Add(str);
                        Console.Clear();
                        break;
                    case 2:
                        //generate                        
                        Random random = new Random();
                        for (int i = 0; i < 5; i++)
                        {
                            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                            _strings.Add(new string(Enumerable.Repeat(chars, random.Next(10))
                                 .Select(s => s[random.Next(s.Length)]).ToArray()));
                        }
                        Console.Clear();
                        Console.WriteLine("Es wurden 5 neue Strings generiert");
                        break;
                    case 3:
                        //sort aplhabetically
                        _strings.Sort();
                        Console.Clear();
                        Console.WriteLine("Die Liste ist alphabetisch sortiert");
                        break;
                    case 4:
                        //sort by length
                        _strings.Sort((a, b) => a.Length.CompareTo(b.Length));
                        Console.Clear();
                        Console.WriteLine("Die Liste ist nach Länge sortiert");
                        break;
                    //back to main menu
                    case 5:
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Unhandled option error in Text() has occured");
                        break;
                }
            }
        }

        public void Pyramid()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Hier ist die Pyramide:");
                for (int i = 0; i < _pyramid.Count; i++)
                {
                    for (int j = 0; j < _pyramid[i].Count; j++)
                    {
                        Console.Write(_pyramid[i][j]);
                    }
                    Console.WriteLine(' ');
                }
                Console.WriteLine("1: Neu Generieren\n2: Zurück");
                Console.Write("Option eingeben: ");
                int option = IntegerInput(1, 2);
                switch (option)
                {
                    case 1:
                        Console.Write("Geben Sie die Höhe als Zahl ein: ");
                        int size = IntegerInput();
                        //Re-init the size of double demensional list
                        _pyramid.Clear();
                        for (int i = 0; i < size; i++)
                        {
                            _pyramid.Add(new List<char>());
                        }
                        //Add values
                        for (int y = 1; y <= size; y++)
                        {
                            // loop 1 to add white spaces
                            for (int j = 1; j <= (size - y); j++)
                            {
                                _pyramid[y - 1].Add(' ');
                            }
                            // loop 2 to add numbers
                            for (int j = 1; j < 2 * y; j++)
                            {
                                _pyramid[y - 1].Add('*');
                            }
                            // loop 3 to add white spaces
                            for (int j = 1; j <= (size - y); j++)
                            {
                                _pyramid[y - 1].Add(' ');
                            }
                        }
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Unhandled option error in Pyramid() has occured");
                        break;

                }
            }
        }

        static int IntegerInput(int? lowBound = null, int? highBound = null)
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

                    //check if both bounds are not violated
                    if (highBound != null && lowBound != null
                            && input > highBound || input < lowBound) throw new Exception("Es gibt keine Option wie diese");
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