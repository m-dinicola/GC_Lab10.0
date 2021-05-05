using System;
using System.Collections.Generic;
using System.IO;

namespace Lab10._0_GC
{
    class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<int, string> options = new Dictionary<int, string> {     //enumerates the options available for the user to select
                { 1, "Animation" },
                { 2, "Drama" },
                { 3, "Horror" },
                { 4, "SciFi" },
                { 5, "Custom" }                                                 //custom allows users to type in their own genre to search
            };
            string optionString = "";
            foreach (KeyValuePair<int, string> option in options)
            {
                optionString += $"{option.Key}. {option.Value}\n";              //builds the output string with which to prompt user
            }

            bool tryAgain = true;
            while (tryAgain)
            {
                int selection = GetInt($"Choose the genre you would like to see:\n{optionString}");
                if (options.ContainsKey(selection))                             //do the options contain the entered int? If no, it's an invalid entry, try-again
                {
                    FilmLibrary library = GenerateFilmLibrary();                //creates and stores a FilmLibrary using the GenerateFilmLibrary method.
                    if(selection == 5)
                    {
                        library.Genre = PromptUser("Please enter your desired genre: ");        //for a custom genre, gets user input and sets as library's genre
                    }
                    else
                    {
                        library.Genre = options[selection];                     //if not custom, genre set for the library is matched to selection
                    }
                    library.PrintGenre();                                       //uses the library's PrintGenre method to print movies from the selected genre
                    tryAgain = Continue();                                      //if user wants to try again, Continue will come back true, and loop will continue.
                }
                else
                {
                    Console.Write("That's not a valid input. Try again. ");     //tryAgain will still be true if user selection wasn't valid, so loop will run again.
                }
            }
        }

        public static FilmLibrary GenerateFilmLibrary()
        {
            List<string[]> csv = new List<string[]>();                          //Creates a list of string arrays in which we will collect the values of a csv source
            string[] lines = System.IO.File.ReadAllLines("movies.txt");         //This string array keeps a string for each line in the source csv
            foreach(string line in lines)                                       //Cycles through each line
            {
                csv.Add(line.Split(','));                                       //splits each line at the comma, ouputs as a string[2], adds to list of csv values
            }
            return new FilmLibrary(csv);                                        //uses constructor overload that takes a list of string arrays to create a new FilmLibrary
        }

        //IO methods required for Main switch to function
        public static bool Continue()
        {
            return (GetYN("Would you like to continue? (y/n) ") == "y");        //returns true when GetYN returns y
        }

        public static string GetYN(string message)
        {
            while (true)                                                        //tries again until user inputs an acceptable value
            {
                string input = PromptUser(message).ToLower();                   //stores user input as a lowercase string
                if (input == "y" || input == "yes" || input == "n" || input == "no")
                {
                    return input.Substring(0, 1);                               //if it was a valid input, it returns the first letter
                }
            }
        }

        public static string PromptUser(string message)                         //prints the promt, returns the user response
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        public static int GetInt(string message)                                //overload without min/max values performs GetInt with maximum and minimum int values
        {
            return GetInt(message, "Not a valid input. ", int.MinValue, int.MaxValue);
        }

        public static int GetInt(string message, string errorMessage, int lowerBound, int upperBound)  //prompts user with given prompt errorMessage and re-ask until we can return an int within bounds
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
