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
            customerProfileList.Add(GetCustomerFirstName());
            customerProfileList.Add(GetCustomerLastName());
            customerProfileList.Add(GetCustomerAge());
            customerProfileList.Add(GetCustomerActivityLevel());
            customerProfileList.Add(GetCustomerMartialStatus());
            customerProfileList.Add(GetCustomerOccupationStatus());
            return customerProfileList;
        }

        private static string GetCustomerFirstName()
        {
            Console.WriteLine("Provide a first name:");
            string userInput = Console.ReadLine();
            return userInput;
        }

        private static string GetCustomerLastName()
        {
            Console.WriteLine("Provide a last name:");
            string userInput = Console.ReadLine();
            return userInput;
        }

        private static int GetCustomerAge()
        {
            Console.WriteLine("Provide an age:");
            int userInput = 0;
            try
            {
                userInput = int.Parse(Console.ReadLine());
                return userInput;
            }
            catch (Exception)
            {
                DisplayProvideANumber();
                return GetCustomerAge();
            }
        }

        private static int GetCustomerActivityLevel()
        {
            Console.WriteLine("Please Provide an activity level between 1-10");
            int userInput = 0;
            try
            {
                userInput = int.Parse(Console.ReadLine());
                if (userInput > 0 && userInput < 11)
                {
                    return userInput;
                }
                else
                {
                    DisplayRedText("Please povide a number within 1-10");
                    return GetCustomerActivityLevel();
                }
            }
            catch (Exception)
            {
                DisplayProvideANumber();
                return GetCustomerActivityLevel();
            }
        }

        private static bool GetCustomerMartialStatus()
        {
            Console.WriteLine("Are you Married (Y/N)?");
            string userInput = Console.ReadLine().ToLower();
            switch (userInput)
            {
                case "y":
                    return true;
                case "n":
                    return false;
                default:
                    DisplayRedText("Please Privde 'y' or 'n'");
                    return GetCustomerMartialStatus();
            }
        }

        private static bool GetCustomerOccupationStatus()
        {
            Console.WriteLine("Do you have a job (Y/N)?");
            string userInput = Console.ReadLine().ToLower();
            switch (userInput)
            {
                case "y":
                    return true;
                case "n":
                    return false;
                default:
                    DisplayRedText("Please Privde 'y' or 'n'");
                    return GetCustomerOccupationStatus();
            }
        }

        public static void DisplayCustomerMainMenu()
        {
            Console.WriteLine("Choose 1 of the following options:");
            Console.WriteLine("1. Create New Customer Profile");
            Console.WriteLine("0. Exit Customer Menu");
        }

        public static void DisplayEmployeeMainMenu()
        {
            Console.WriteLine("Choose 1 of the following options:");
            Console.WriteLine("1. Add Animal");
            Console.WriteLine("2. Display Rooms");
            Console.WriteLine("3. Display Adopted Animals");
            Console.WriteLine("4. Display Susceptible Animals");
            Console.WriteLine("5. Categorize Animals");
            Console.WriteLine("6. Check Animal Food And Quantity");
            Console.WriteLine("0. Exit Employee Menu");
        }

        public static void DisplaySortByMenu()
        {
            Console.WriteLine("Choose how to order the animals:");
            Console.WriteLine("1. Sort By Age");
            Console.WriteLine("2. Sort By Gender");
            Console.WriteLine("3. Sort By Name");
            Console.WriteLine("4. Sort By Species");
        }

        public static void DisplayNotACommand()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("NOT A COMMAND");
            Console.ResetColor();
        }

        public static void DisplayProvideANumber()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Please Provide a Number!");
            Console.ResetColor();
        }

        public static void DisplayRedText(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}

