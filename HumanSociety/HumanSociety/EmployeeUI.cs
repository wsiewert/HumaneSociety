using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanSociety
{
    class EmployeeUI
    {
        HumaneSociety humaneSociety;

        public EmployeeUI(HumaneSociety humaneSociety)
        {
            this.humaneSociety = humaneSociety;
        }

        public void Start()
        {
            UI.DisplayEmployeeMainMenu();
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    break;
                case "1":
                    humaneSociety.AddAnimal();
                    Start();
                    break;
                case "2":
                    humaneSociety.DisplayRooms();
                    Start();
                    break;
                case "3":
                    humaneSociety.DisplayAdoptedAnimals();
                    Start();
                    break;
                case "4":
                    humaneSociety.DisplaySusceptibleAnimals();
                    VaccinateAnimal();
                    Start();
                    break;
                case "5":
                    SortBy();
                    Start();
                    break;
                default:
                    UI.DisplayNotACommand();
                    Start();
                    break;
            }
        }

        public void VaccinateAnimal()
        {
            Console.WriteLine("Type an animals ID to vaccinate it, or 0 to exit:");
            try
            {
                int userInput = int.Parse(Console.ReadLine());
                if (userInput != 0)
                {
                    humaneSociety.VaccinateAnimal(userInput);
                }
            }
            catch (Exception)
            {
                VaccinateAnimal();
            }
        }

        public void SortBy()
        {
            UI.DisplaySortByMenu();
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    humaneSociety.SortByAge();
                    GetAnimalDetails();
                    break;
                case "2":
                    humaneSociety.SortByGender();
                    GetAnimalDetails();
                    break;
                case "3":
                    humaneSociety.SortByName();
                    GetAnimalDetails();
                    break;
                case "4":
                    humaneSociety.SortBySpecies();
                    GetAnimalDetails();
                    break;
                default:
                    UI.DisplayNotACommand();
                    SortBy();
                    break;
            }
        }

        public void GetAnimalDetails()
        {
            Console.WriteLine("Type an animal ID to get full details or 0 exit.");
            try
            {
                int userInput = int.Parse(Console.ReadLine());
                if (userInput != 0)
                {
                    humaneSociety.DisplayFullDetailsByID(userInput);
                }
            }
            catch (Exception)
            {
                GetAnimalDetails();
            }
        }
    }
}
