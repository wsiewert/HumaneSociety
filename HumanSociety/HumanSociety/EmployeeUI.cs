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
    }
}
