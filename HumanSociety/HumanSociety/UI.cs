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
            Console.WriteLine("You may conintue as:");
            Console.WriteLine("1. Employee");
            Console.WriteLine("2. Customer");
        }

        public static string GetStartInterface()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    return userInput;
                case "2":
                    return userInput;
                default:
                    Console.WriteLine("Please choose a valid command");
                    return GetStartInterface();
            }
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
    }
}

