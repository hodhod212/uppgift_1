using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace FirstProject
{
    class Program
    {
        public interface IItem
        {
            void printCharacterOrOpponent();
        }
        public class CharacterOrOpponentPower : IItem
        {
            string CharacterOrOpponent;
            int Health;
            int Force;
            int Luck;

            public CharacterOrOpponentPower(string characterOrOpponent,int health, int force, int luck) 
            {
                CharacterOrOpponent = characterOrOpponent;               
                Health = health;
                Force = force;
                Luck = luck;
            }


           
            public void printCharacterOrOpponent()
            {
                Console.WriteLine($"{CharacterOrOpponent} has {Force} force, {Luck} luck and {Health} health.");

            }
           
        }
        
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }
        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine(" 0) Exit");
            Console.WriteLine(" 1) Hello World");
            Console.WriteLine(" 2) Firstname, Lastname and Age");
            Console.WriteLine(" 3) Toggle color");
            Console.WriteLine(" 4) Date and Time");
            Console.WriteLine(" 5) Max Input");
            Console.WriteLine(" 6) Guess the number");
            Console.WriteLine(" 7) Create a Text File");
            Console.WriteLine(" 8) Read Text File");
            Console.WriteLine(" 9) Math Power");
            Console.WriteLine("10) Multiplication Table");
            Console.WriteLine("11) Random number  Array");
            Console.WriteLine("12) Reverse String");
            Console.WriteLine("13) Numbers between two numbers.");
            Console.WriteLine("14) The Numbers.");
            Console.WriteLine("15) Add Numbers.");
            Console.WriteLine("16) Character and Opponent.");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "0":
                    return false;
                case "1":
                    HelloWorld();
                    return true;
                case "2":
                    PersonName();
                    return true;
                case "3":
                    ToggleColor();
                    return true;
                case "4":
                    DateAndTime();
                    return true;
                case "5":
                    MaxInput();
                    return true;
                case "6":
                    GuessTheNumber();   
                    return true;
                case "7":
                    CreateTextFile();
                    return true;
                case "8":
                    ReadTheFile();
                    return true;
                case "9":
                    MathPower();
                    return true;
                case "10":
                    MultiplicationTable();
                    return true;
                case "11":
                    MyRandomNumberArray();
                    return true;
                case "12":
                    ReverseString();
                    return true;
               
                case "13":
                    NumbersBetweenNumbers();
                    return true;
                case "14":
                    TheNumbers();
                    return true;
                case "15":
                    AddNumbers();
                    return true;
                case "16":
                    CharacterOpponent();
                    return true;
                default:
                    return true;
            }
        }

        
        private static string CharacterOpponent()
        {
            Console.WriteLine("Enter your name: ");
             string Character = Console.ReadLine();
            Console.WriteLine("Enter the name of your opponent: ");
             string Opponent = Console.ReadLine();
             int YourForce,YourLuck,OpponentForce,OpponentLuck,YourHealth,OpponentHealth;
      
            Random r = new Random();
            YourForce=r.Next(0,100);
            YourLuck=r.Next(0,100);
            OpponentForce = r.Next(0, 100);
            OpponentLuck = r.Next(0, 100);
            YourHealth = r.Next(0, 100);
            OpponentHealth = r.Next(0, 100);

            List<IItem> items = new List<IItem>();
            CharacterOrOpponentPower yourPower = new CharacterOrOpponentPower(Character, YourHealth, YourForce,YourLuck);
            CharacterOrOpponentPower opponentPower = new CharacterOrOpponentPower(Opponent, OpponentHealth, OpponentForce,OpponentLuck);
            items.Add(yourPower);
            items.Add(opponentPower);
            foreach (IItem Item in items)
            {
                Item.printCharacterOrOpponent();
            }
            

            Console.Write("\r\nPress Enter to return to Main Menu");
            return Console.ReadLine();
        }
        private static string AddNumbers()
        {

            Console.WriteLine("Enter some numbers and enter comma between the numbers: ");
            int Inputs;
            bool Validity = true;
            string TheNumber = Console.ReadLine();
            char last_char = TheNumber[TheNumber.Length - 1];
            while (last_char == '-' || last_char == '.' || last_char == ',' || last_char == ';')
            {
                Console.WriteLine("You don't have to write '-' or ',' or ';' after the last number");
                Validity = false;
                break;
            }
            var results = TheNumber.Split(',');
            foreach (var item in results)
            {
                while (!int.TryParse(item, out Inputs))
                {
                    Console.WriteLine("You need to enter valid integer numbers and enter comma between them!");
                    Validity = false;
                    break;
                }
            }

            results.Select(x => int.Parse(x.Trim()));

            if (Validity)
            {
                Console.Write("Addition of the numbers: ");
                int Addition = 0;
                foreach (var number in results)
                {
                    Addition += int.Parse(number); 
                }
                Console.WriteLine(Addition);
                Console.WriteLine();
                
              
            }
            Console.Write("\r\nPress Enter to return to Main Menu");
            return Console.ReadLine();
        }
        private static string TheNumbers()
        {

            Console.WriteLine("Enter some numbers and enter comma between the numbers: ");
            int Inputs;
            bool Validity = true;
            string TheNumber = Console.ReadLine();
            char last_char = TheNumber[TheNumber.Length - 1];
            while(last_char ==  '-' || last_char == '.' || last_char == ',' || last_char == ';')
            {
                Console.WriteLine("You don't have to write '-' or ',' or ';' after the last number");
                Validity = false;
                break;
            } 
            var results = TheNumber.Split(',');
            foreach(var item in results)
            {
                while(!int.TryParse(item, out Inputs))
                {
                    Console.WriteLine("You need to enter valid integer numbers and enter comma between them!");
                    Validity = false;
                    break;
                }
            }
          
            results.Select(x => int.Parse(x.Trim()));
            
            if (Validity)
            {
                Console.WriteLine("Even numbers");

                foreach (var number in results)
                {
                    if (int.Parse(number) % 2 == 0)
                    {
                        Console.Write($"{number} ");
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Odd numbers");
                foreach (var number in results)
                {
                    if (int.Parse(number) % 2 != 0)
                    {
                        Console.Write($"{number} ");
                    }
                }
            }
            Console.Write("\r\nPress Enter to return to Main Menu");
            return Console.ReadLine();

        }
        private static string NumbersBetweenNumbers()
        {
            Console.Clear();
            bool TryAgain = true;
            while (TryAgain)
            {
                int FirstNumber, SecondNumber;
                string response;
                Console.WriteLine("Obs! your numbers have to be two digital and different numbers between 1 and 100");
                Console.WriteLine();
                Console.WriteLine("Enter the first number");

                while (!int.TryParse(Console.ReadLine(), out FirstNumber))
                {
                    Console.WriteLine("That was invalid. Enter a valid number.");
                }
                Console.WriteLine("Enter the second number");
                while (!int.TryParse(Console.ReadLine(), out SecondNumber))
                {
                    Console.WriteLine("That was invalid. Enter a valid number.");
                }
                if (SecondNumber < 1 || SecondNumber > 100 || FirstNumber < 1 || FirstNumber > 100)
                {
                    Console.WriteLine("Your numbers have to be between 1 and 100.");
                }
                else if (FirstNumber == SecondNumber)
                {
                    Console.WriteLine("Your first number and second number are the same.");
                }
                else
                {
                    int CountNumber = 0;
                    int MinNumber = Math.Min(FirstNumber, SecondNumber);
                    int MaxNumber = Math.Max(FirstNumber, SecondNumber);
                    Console.WriteLine();
                    while (MinNumber < MaxNumber - 1)
                    {

                        Console.Write($"{MinNumber + 1} \t");
                        MinNumber++;
                        CountNumber++;

                        if (CountNumber % 10 == 0 && CountNumber != 0)
                        {
                            Console.WriteLine("\n");
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("Would you like to play again (Y/N): ");
                    response = Console.ReadLine();
                    response = response.ToUpper();
                    if (response == "Y" || response == "YES")
                    {
                        TryAgain = true;
                    }
                    else
                    {
                        TryAgain = false;
                        break;
                    }
                }
            }
            Console.Write("\r\nPress Enter to return to Main Menu");
            return Console.ReadLine();

        }
        private static string MyRandomNumberArray()
        {
            Console.Clear();
            Console.WriteLine();
            int[] randomNum = new int[10];
            int[] increasingNum = new int[10];
            Random random = new Random();

            //randomNum fylls med slumpvisa nummer, 1 till 99
            for (int i = 0; i < 10; i++)
            {
                increasingNum[i] = randomNum[i] = random.Next(1, 99);
            }
            Array.Sort(increasingNum);
            Console.WriteLine("This is the random array:");
            Console.WriteLine();
            Console.Write("{ ");

            for (int i= 0;i < 10; i++)
            {
                if (i == 9)
                {
                    Console.Write($"{randomNum[i]} ");
                }
                else
                {
                    Console.Write($"{randomNum[i]}, ");
                }
            }
            Console.Write("}");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("This is the sorted random array in increasing order:");
            Console.WriteLine();
            Console.Write("{ ");
            for (int j=0;j<10; j++)
            {
                if(j== 9)
                {
                    Console.Write($"{increasingNum[j]} ");
                }
                else
                {
                    Console.Write($"{increasingNum[j]}, ");
                }
            }
            Console.Write("}");

            Console.WriteLine();

            Console.Write("\r\nPress Enter to return to Main Menu");

            return Console.ReadLine();
        }
        private static string MultiplicationTable()
        {
            Console.Clear();
            Console.WriteLine();
            for(int x=1;x<=10;x++)
            {
                Console.Write("\t \t");
                for(int y=1;y<=10;y++)
                {
                    
                Console.Write($"{x*y} \t");
                }
                Console.WriteLine("\n \n");
            }
            Console.Write("\r\nPress Enter to return to Main Menu");
            return Console.ReadLine();
        }
        private static string MathPower()
        {
            Console.Clear();
            double TheNumber;
            Console.WriteLine("Insert a valid number: ");
            while (!double.TryParse(Console.ReadLine(), out TheNumber))
            {
                Console.WriteLine("That was invalid. Enter a valid number.");
            }
            Console.WriteLine($"Root of {TheNumber} is: {Math.Round(Math.Pow(TheNumber, .5),2)}");
            Console.WriteLine($"Square of {TheNumber} is: {Math.Round(Math.Pow(TheNumber, 2),2)}");
            Console.WriteLine($"This is the {TheNumber} in power 10: {Math.Round(Math.Pow(TheNumber, 10), 2)}");
          
            Console.Write("\r\nPress Enter to return to Main Menu");
            return Console.ReadLine();
        }
        private static string ReadTheFile()
        {
            Console.Clear();
            String line;
            try
            {               
                StreamReader sr = new StreamReader(@"C:\after-2021-08-07\c#\FirstProject\FirstProject\Text.txt");
                line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
         
            Console.Write("\r\nPress Enter to return to Main Menu");
            return Console.ReadLine();
        }
        private static string CreateTextFile()
        {
            Console.Clear();
            Console.WriteLine("Enter your text here: ");
            string YourText=Console.ReadLine();
            try
            {
                StreamWriter sw = new StreamWriter(@"C:\after-2021-08-07\c#\FirstProject\FirstProject\Text.txt");

                
                sw.WriteLine(YourText);
                Console.WriteLine();
                Console.WriteLine($"The name of your text file is Text.txt. \nHere is what you have writen in your text file: {YourText}");
                Console.WriteLine();
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            Console.Write("\r\nPress Enter to return to Main Menu");
            return Console.ReadLine();

        }
        private static string GuessTheNumber()
        {
            Console.Clear();
            Random random=new Random();
            bool PlayAgain = true;
            int min = 1;
            int max = 100;
            int guess, number, guesses;
            string response;
            while (PlayAgain)
            {
                guess = 0;
                guesses = 0;
                response = "";
                number = random.Next(min,1+max);
                while (guess != number)
                {
                    Console.WriteLine($"Guess a number between {min} and {max} : ");
                    while (!int.TryParse(Console.ReadLine(), out guess))
                    {
                        Console.WriteLine("Enter a valid number!");
                    }
                        

                    Console.WriteLine($"Guess: {guess}");
                    if (guess > number)
                    {
                        Console.WriteLine($"{guess} is too high!");
                    }else if(guess<number){
                        Console.WriteLine($"{guess} is too low");
                    }
                    guesses++;

                }
                Console.WriteLine($"Number is: {number}");
                Console.WriteLine("You won!");
                Console.WriteLine($"You found it after {guesses} guesses.");
                Console.WriteLine("Would you like to play again (Y/N): ");
                response=Console.ReadLine();
                response=response.ToUpper();
                if(response=="Y" || response == "YES")
                {
                    PlayAgain = true;
                }
                else
                {
                    PlayAgain= false;
                    break;
                }                  

            }
                    Console.Write("\r\nPress Enter to return to Main Menu");
                    return Console.ReadLine();
            
        }
       
        private static string HelloWorld()
        {
            Console.Clear();
            Console.Write("Hello World");
            Console.Write("\r\nPress Enter to return to Main Menu");
            return Console.ReadLine();
        }
        private static string DateAndTime()
        {
            Console.Clear();
            DateTime now = DateTime.Now;
            Console.WriteLine(now);
            Console.Write("\r\nPress Enter to return to Main Menu");
            return Console.ReadLine();
        }
        private static string MaxInput()
        {
            Console.Clear();
            int FirstNumber;
            Console.WriteLine("Insert a valid number: ");
            while (!int.TryParse(Console.ReadLine(), out FirstNumber))
            {
                Console.WriteLine("That was invalid. Enter a valid number.");
            }
            int SecondNumber;
            Console.WriteLine("Insert another valid number: ");
            while (!int.TryParse(Console.ReadLine(), out SecondNumber))
            {
                Console.WriteLine("That was invalid. Enter a valid number.");
            }
            
            if(FirstNumber > SecondNumber)
            {
                Console.WriteLine($"{ FirstNumber} is the biggest number.");
            }
            else
            {
                Console.WriteLine($"{ SecondNumber} is the biggest number.");
            }
            Console.Write("\r\nPress Enter to return to Main Menu");
            return Console.ReadLine();
        }
        private static string ToggleColor()
        {
            Console.Clear();

            if (Console.ForegroundColor == ConsoleColor.Red)
            {
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.WriteLine("This text is red");
        

            Console.Write("\r\nPress Enter to return to Main Menu");
            return Console.ReadLine();
        }
        private static string PersonName()
        {
            Console.Clear();
            Console.WriteLine("Tell me about yourself.");
            Console.Write("Type your first name: ");

            string myFirstName;
            myFirstName = Console.ReadLine();

            Console.Write("Type your last name: ");
            string myLastName = Console.ReadLine();

            Console.Write("How old are you? ");
            int myBirthYear;
            while (!int.TryParse(Console.ReadLine(), out myBirthYear))
            {
                Console.WriteLine("That was invalid. Enter a valid number.");
            }

            Console.WriteLine();
            Console.WriteLine($"Hello,  {myFirstName}  {myLastName}, you are {myBirthYear} years old");
            Console.Write("\r\nPress Enter to return to Main Menu");
            return Console.ReadLine();
        }
        private static string CaptureInput()
        {
            Console.Clear();
            Console.Write("Enter the string you want to modify: ");
            return Console.ReadLine();
        }
        private static void ReverseString()
        {
            Console.Clear();
            Console.WriteLine("Reverse String");

            char[] charArray = CaptureInput().ToCharArray();
            char[] newPermutation = new char[charArray.Length];
            for (int i = 0; i < charArray.Length; i++)
            {
                newPermutation[i] = charArray[i];
            }
            Array.Reverse(newPermutation);
            int palindrome = 0;
           for(int i = 0; i < charArray.Length; i++)
            {
                if(charArray[i] != newPermutation[i])
                {
                    Console.WriteLine();
                    Console.WriteLine("charArray is not palindrome");
                    palindrome++;
                    break;
                }
               
            }
            if (palindrome == 0)
            {
                Console.WriteLine();
                Console.WriteLine("charArray is palindrome");
            }
            DisplayResult(String.Concat(newPermutation));
            

        }

        private static void DisplayResult(string message)
        {
            Console.WriteLine($"\r\nYour modified string is: {message}");
            Console.Write("\r\nPress Enter to return to Main Menu");
            Console.ReadLine();
        }
    }
}