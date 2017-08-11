using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanSociety
{
    class HumaneSociety
    {
        HumaneSocietyDBDataContext humaneSocietyDB = new HumaneSocietyDBDataContext();

        public HumaneSociety()
        {

        }

        public void Start()
        {
            //UI main menu
        }

        public bool AddAnimal()
        {
            int? emptyRoomID = GetFirstEmptyRoom();

            if (emptyRoomID == null)
            {
                //cw("No rooms available at this time.")
                return false;
            }

            int activityLevel = int.Parse(UI.GetUserInput("Provide an activity level 1-10"));
            int age = int.Parse(UI.GetUserInput("Provide animal age:"));
            bool adoptionStatus = false;
            string breed = UI.GetUserInput("Provide a breed:");
            string name = UI.GetUserInput("Provide a name:");
            //create a list of species that can be added to
            //"this species doesnt exist, would you like to add it to the humanesociety?"
            string species = UI.GetUserInput("Provide a species");
            bool vaccinationStatus = false;
            string foodType = UI.GetUserInput("Provide a foodtype:");
            int foodQuantity = int.Parse(UI.GetUserInput("Provide the quanitity of food:"));
            string gender = UI.GetUserInput("Provide a gender:");
            decimal price = decimal.Parse(UI.GetUserInput("Provide a selling price:"));

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
                Price = price,
            };

            humaneSocietyDB.Animals.InsertOnSubmit(animal);
            humaneSocietyDB.SubmitChanges();
            AddAnimalToRoom(animal.ID, emptyRoomID);
            return true;
        }

        private void AddAnimalToRoom(int animalID, int? roomID)
        {
            // Add an exisiting animal to an empty room
            // Change occupied status
            var availableRoom = humaneSocietyDB.Animals.Where(x => x.ID == animalID);
            foreach (var x in availableRoom)
            {
                x.FK_Rooms_ID = roomID;
            }
            var changeRoomStatus = humaneSocietyDB.Rooms.Where(x => x.ID == roomID);
            foreach (var x in changeRoomStatus)
            {
                x.OccupiedStatus = true;
            }
            humaneSocietyDB.SubmitChanges();
        }

        public void RemoveAnimalFromRoom(int animalID)
        {
            //remove animal
            //change occupied status
            //Use join??
            int? roomID = null;
            var availableRoom = humaneSocietyDB.Animals.Where(x => x.ID == animalID);
            foreach (var x in availableRoom)
            {
                roomID = x.FK_Rooms_ID;
                x.FK_Rooms_ID = null;
            }
            var changeRoomStatus = humaneSocietyDB.Rooms.Where(x => x.ID == roomID);
            foreach (var x in changeRoomStatus)
            {
                x.OccupiedStatus = false;
            }
            humaneSocietyDB.SubmitChanges();
        }

        private int? GetFirstEmptyRoom()
        {
            var emptyRoom = humaneSocietyDB.Rooms.Where(x => x.OccupiedStatus == false);
            foreach (var x in emptyRoom)
            {
                return x.ID;
            }
            return null;
        }

        public void SetAdoptionStatus(int animalID, bool status)
        {
            var adoptionStatus = humaneSocietyDB.Animals.Where(x => x.ID == animalID);
            foreach (var x in adoptionStatus)
            {
                x.AdoptionStatus = status;
            }
            humaneSocietyDB.SubmitChanges();
        }

        private void GetInfoByRoomNumber()
        {
            //get room number, check ID
            //take ID from room number and check animal table with that foreign key
        }
    }
}
