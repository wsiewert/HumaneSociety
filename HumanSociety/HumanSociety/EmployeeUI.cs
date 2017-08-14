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
                    //do something then return to start
                    Start();
                    break;
                default:
                    Console.WriteLine("NOT A COMMAND");
                    Start();
                    break;
            }
        }
    }
}
