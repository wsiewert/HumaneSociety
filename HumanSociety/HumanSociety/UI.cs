using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanSociety
{
    static class UI
    {
        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string userInput = Console.ReadLine().ToLower();
            return userInput;
        }

        public static void DisplayStartDialogue()
        {
            Console.WriteLine("Welcome to the Humane Society");
            Console.WriteLine("Conintue as:");
            Console.WriteLine("1. Employee");
            Console.WriteLine("2. Customer");
            Console.WriteLine("0. Quit");
        }

        public static List<object> CreateAnimalProfile()
        {
            List<object> animalProfileList = new List<object>() { };
            //Create the animal profile Dialoge
            return animalProfileList;
        }

        public static List<object> CreateCustomerProfile()
        {
            List<object> customerProfileList = new List<object>() { };
            //Create the Customer Profile dialogue
            return customerProfileList;
        }

        public static void DisplayEmployeeMainMenu()
        {
            Console.WriteLine("Choose 1 of the following options:");
            Console.WriteLine("1. Add Animal");
            Console.WriteLine("2. Display Rooms");
            Console.WriteLine("3. Display Adopted Animals");
            Console.WriteLine("0. Exit Employee Menu");
        }

        public static void DisplayNotACommand()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("NOT A COMMAND");
            Console.ResetColor();
        }
    }
}

