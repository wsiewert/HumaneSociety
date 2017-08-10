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
            int foodQuantity = int.Parse(UI.GetUserInput("Provide the quanitity of food:"));
            string gender = UI.GetUserInput("Provide a gender:");
            decimal price = decimal.Parse(UI.GetUserInput("Provide a selling price:"));

            HumaneSocietyDBDataContext humaneSocietyDB = new HumaneSocietyDBDataContext();
            Animal animal = new Animal
            {
                ActivityLevel = activityLevel,
                Age = age,
                AdoptionStatus = adoptionStatus,
                Breed = breed,
                Name = name,
                Species = species,
                VaccinationStatus = vaccinationStatus,
                FoodType = foodType,
                FoodQuantity = foodQuantity,
                Gender = gender,
                Price = price
            };

            humaneSocietyDB.Animals.InsertOnSubmit(animal);
            humaneSocietyDB.SubmitChanges();
            return false;
        }

        public void AddAnimalToRoom(Animal animal)
        {
            // Add an exisiting animal to an empty room
            // return room number?
        }
    }
}
