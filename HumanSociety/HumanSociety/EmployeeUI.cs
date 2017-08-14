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
                default:
                    UI.DisplayNotACommand();
                    Start();
                    break;
            }
        }
    }
}
