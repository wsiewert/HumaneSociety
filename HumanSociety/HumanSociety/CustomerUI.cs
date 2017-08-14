using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanSociety
{
    class CustomerUI
    {
        HumaneSociety humaneSociety;
        //use the current customer ID when purhasing animals.
        int currentCustomerID;

        public CustomerUI(HumaneSociety humaneSociety)
        {
            this.humaneSociety = humaneSociety;
        }

        public void Start()
        {
            UI.DisplayCustomerMainMenu();
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    break;
                case "1":
                    currentCustomerID = humaneSociety.AddCustomerProfile();
                    Start();
                    break;
                case "2":
                    SearchBy();
                    Start();
                    break;
                default:
                    UI.DisplayNotACommand();
                    Start();
                    break;
            }
        }

        public void SearchBy()
        {
            UI.DisplayCustomerSearchByMenu();
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    humaneSociety.SearchCollectionBySpecies(UI.GetUserInput("Provide a Species:"));
                    PurchaseAnimal();
                    break;
                case "2":
                    humaneSociety.SearchCollectionBySpecies(UI.GetUserInput("Provide an Age"));
                    PurchaseAnimal();
                    break;
                default:
                    UI.DisplayNotACommand();
                    SearchBy();
                    break;
            }
        }

        public void PurchaseAnimal()
        {
            int userInput = 0;
            if (humaneSociety.CheckCustomerEligibiltiy(currentCustomerID))
            {
                try
                {
                    userInput = int.Parse(UI.GetUserInput("Please Select an anmial to purchase"));
                    //PurchaseAnimal();
                }
                catch (Exception)
                {
                    UI.DisplayProvideANumber();
                }
            }
            else
            {
                Console.WriteLine("Sorry you are not eligible to pruchase.");
                return;
            }
        }
    }
}
