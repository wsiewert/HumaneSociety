using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanSociety
{
    class HumaneSociety
    {
        public HumaneSociety()
        {

        }

        public void Start()
        {
            
        }

        public bool AddAnimal()
        {
            int activityLevel = int.Parse(UI.GetUserInput("Provide an activity level 1-10"));
            int age = int.Parse(UI.GetUserInput("Provide animal age:"));
            bool adoptionStatus = false;
            string breed = UI.GetUserInput("Provide a breed:");
            string name = UI.GetUserInput("Provide a name:");
            string species = UI.GetUserInput("Provide a species");
            bool vaccinationStatus = false;
            string foodType = UI.GetUserInput("Provide a foodtype:");
            int foodQuantity = int.Parse(UI.GetUserInput("Provide a food type"));

            HumaneSocietyDBDataContext humaneSocietyDB = new HumaneSocietyDBDataContext();
            Animal animal = new Animal
            {
                ActivityLevel = 5,
                Age = 5,
                AdoptionStatus = false,
                Breed = "EXAMPLE",
                Name = "EXAMPLE",
                Species = "EXAMPLE",
                VaccinationStatus = false,
                FoodType = "EXAMPLE",
                FoodQuantity = 5,
            };

            humaneSocietyDB.Animals.InsertOnSubmit(animal);
            humaneSocietyDB.SubmitChanges();
            return false;
        }
    }
}
