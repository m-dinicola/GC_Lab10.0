using System;
using System.Collections.Generic;
using System.IO;

namespace Lab10._0_GC
{
    class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<int, string> options = new Dictionary<int, string> {
                { 1, "Animation" },
                { 2, "Drama" },
                { 3, "Horror" },
                { 4, "SciFi" },
                { 5, "Custom" }
            };
            string optionString = "";
            foreach (KeyValuePair<int, string> option in options)
            {
                optionString += $"{option.Key}. {option.Value}\n";
            }

            bool tryAgain = true;
            while (tryAgain)
            {
                int selection = GetInt($"Choose the genre you would like to see:\n{optionString}");
                if (options.ContainsKey(selection))
                {
                    FilmLibrary library = GenerateFilmLibrary();
                    if(selection == 5)
                    {
                        library.Genre = PromptUser("Please enter your desired genre: ");
                    }
                    else
                    {
                        library.Genre = options[selection];
                    }
                    library.PrintGenre();
                    tryAgain = Continue();
                }
                else
                {
                    Console.Write("That's not a valid input. Try again. ");
                }
            }
        }

        public static FilmLibrary GenerateFilmLibrary()
        {
            List<string[]> csv = new List<string[]>();
            string[] lines = System.IO.File.ReadAllLines("movies.txt");
            foreach(string line in lines)
            {
                csv.Add(line.Split(','));
            }
            return new FilmLibrary(csv);
        }

        //IO methods required for Main switch to function
        public static bool Continue()
        {
            return (GetYN("Would you like to continue? (y/n) ") == "y");
        }

        public static string GetYN(string message)
        {
            while (true)
            {
                string input = PromptUser(message).ToLower();
                if (input == "y" || input == "yes" || input == "n" || input == "no")
                {
                    return input.Substring(0, 1);
                }
            }
        }

        public static string PromptUser(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        public static int GetInt(string message)
        {
            return GetInt(message, "Not a valid input. ", int.MinValue, int.MaxValue);
        }

        public static int GetInt(string message, string errorMessage, int lowerBound, int upperBound)
        {
            int returnVal;
            while (!int.TryParse(PromptUser(message), out returnVal) || returnVal >= upperBound || returnVal < lowerBound)
            {
                Console.Write(errorMessage);
            }
            return returnVal;
        }


    }
}
