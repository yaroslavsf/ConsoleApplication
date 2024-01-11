using _01_Console_App.Helpers;
using System;
using System.Drawing;

namespace _01_Console_App
{
    public enum EMenu
    {
        EXIT = 0,
        NUMBERS,
        TEXT,
        PYRAMID,
    }
    public enum ENumbers
    {
        EXIT = 0,
        ADD,
        SUM,
        GENERATE,
        FIND_MIN_MAX,
        SORT
    }
    public enum EText
    {
        EXIT = 0,
        ADD,
        GENERATE,
        SORT_APLPHABETICALLY,
        SORT_LENGTH
    }
    public enum EPyramid
    {
        EXIT = 0,
        GENERATE
    }
    public class ConsoleApplication
    {
        readonly List<int> _numbersList = new();
        readonly List<string> _stringsList = new();
        readonly List<List<char>> _pyramidList = new();
        readonly InteractionHandler _interactionHandler = new();

        public List<int> NumbersList => _numbersList;
        public List<List<char>> PyramidList => _pyramidList;
        public List<string> StringsList => _stringsList;
        public InteractionHandler InteractionHandler => _interactionHandler;

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
                }
            }
        }

        public int Menu()
        {
            Console.Write("1: Operationen mit Zahlen\n" +
                "2: Operationen mit Texten\n" +
                "3: Pyramide von gewisser Höhe bauen\n" +
                "0: Exit\n" +
                "Bitte wähle den entsprechenden Eintrag aus:");
            return _interactionHandler.NumberInput(typeof(EMenu));
        }
        public void Numbers()
        {
            Console.Clear();
            while (true)
            {
                _interactionHandler.Output("die Liste: [" + string.Join(", ", _numbersList) + "]\n");
                    Console.Write(
                    "1: Hinzufügen\n" +
                    "2: Addieren alle Zahlen\n" +
                    "3: Generieren 5 random Zahlen\n" +
                    "4: Finden min/max\n" +
                    "5: Sortieren\n" +
                    "0: Zurück\n" +
                    "Option eingeben: ");
                int option = _interactionHandler.NumberInput(typeof(ENumbers));
                switch (option)
                {
                    case 1:
                        //add
                        Console.Write("Geben Sie die hinzuzufügende Zahl ein: ");
                        int number = _interactionHandler.NumberInput();
                        _numbersList.Add(number);
                        Console.Clear();
                        break;
                    case 2:
                        //sum
                        int sum = 0;
                        foreach (int i in _numbersList)
                        {
                            sum += i;
                        }
                        Console.Clear();
                        _interactionHandler.Output($"Summe aller Zahlen:{sum}\n");                       
                        break;
                    case 3:
                        //generate
                        Random random = new();
                        for (int i = 0; i < 5; i++)
                        {
                            int randomNumber = random.Next(100);
                            _numbersList.Add(randomNumber);
                        }
                        Console.Clear();
                        Console.WriteLine("Neue 5 generierte Werte wurden hinzugefügt");
                        break;
                    case 4:
                        //min/max
                        Console.Clear();
                        _interactionHandler.Output($"Min: {_numbersList.Min()}, Max: {_numbersList.Max()}\n");
                        break;
                    case 5:
                        //sort
                        _numbersList.Sort();
                        Console.Clear();
                        Console.WriteLine("Liste ist sortiert");
                        break;
                    //back to main menu
                    case 0:
                        Console.Clear();
                        return;                   
                }
            }
        }

        public void Text()
        {
            Console.Clear();
            while (true)
            {
                _interactionHandler.Output("die Liste: [" + string.Join(", ", _stringsList) + "]\n");
                   Console.Write("1: Hinzufügen\n" +
                    "2: Generieren 5 random Strings\n" +
                    "3: Sortieren alphabetisch\n" +
                    "4: Sortieren nach Länge\n" +
                    "0: Zurück\n" +
                    "Option eingeben: ");
                int option = _interactionHandler.NumberInput(typeof(EText));
                switch (option)
                {
                    case 1:
                        //add 
                        Console.Write("Geben Sie die hinzuzufügende Zeichenfolge ein: ");
                        string str = _interactionHandler.StringInput();
                        _stringsList.Add(str);
                        Console.Clear();
                        break;
                    case 2:
                        //generate                        
                        Random random = new();
                        for (int i = 0; i < 5; i++)
                        {
                            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                            _stringsList.Add(new string(Enumerable.Repeat(chars, random.Next(10))
                                 .Select(s => s[random.Next(s.Length)]).ToArray()));
                        }
                        Console.Clear();
                        Console.WriteLine("Es wurden 5 neue Strings generiert");
                        break;
                    case 3:
                        //sort aplhabetically
                        _stringsList.Sort();
                        Console.Clear();
                        Console.WriteLine("Die Liste ist alphabetisch sortiert");
                        break;
                    case 4:
                        //sort by length
                        _stringsList.Sort((a, b) => a.Length.CompareTo(b.Length));
                        Console.Clear();
                        Console.WriteLine("Die Liste ist nach Länge sortiert");
                        break;
                    //back to main menu
                    case 0:
                        Console.Clear();
                        return;                   
                }
            }
        }

        public void Pyramid()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Hier ist die Pyramide:");
                string result = "";
                for (int i = 0; i < _pyramidList.Count; i++)
                {
                    for (int j = 0; j < _pyramidList[i].Count; j++)
                    {
                        result += _pyramidList[i][j];
                    }
                    result += '\n';
                }
                _interactionHandler.Output(result);
                Console.WriteLine("1: Neu Generieren\n0: Zurück");
                Console.Write("Option eingeben: ");
                int option = _interactionHandler.NumberInput(typeof(EPyramid));
                switch (option)
                {
                    case 1:
                        Console.Write("Geben Sie die Höhe als Zahl ein: ");
                        int size = _interactionHandler.NumberInput();
                        //Re-init the size of double demensional list
                        _pyramidList.Clear();
                        for (int i = 0; i < size; i++)
                        {
                            _pyramidList.Add(new List<char>());
                        }
                        //Add values
                        for (int y = 1; y <= size; y++)
                        {
                            // loop 1 to add white spaces
                            for (int j = 1; j <= (size - y); j++)
                            {
                                _pyramidList[y - 1].Add(' ');
                            }
                            // loop 2 to add numbers
                            for (int j = 1; j < 2 * y; j++)
                            {
                                _pyramidList[y - 1].Add('*');
                            }
                            // loop 3 to add white spaces
                            for (int j = 1; j <= (size - y); j++)
                            {
                                _pyramidList[y - 1].Add(' ');
                            }
                        }
                        Console.Clear();
                        break;
                    case 0:
                        Console.Clear();
                        return;                   
                }
            }
        }    
    }
} 