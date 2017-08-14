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
            UI.DisplayStartDialogue();
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    Environment.Exit(0);
                    break;
                case "1":
                    EmployeeUI employee = new EmployeeUI(this);
                    employee.Start();
                    Start();
                    break;
                case "2":
                    CustomerUI customer = new CustomerUI(this);
                    //customer.Start();
                    Start();
                    break;
                default:
                    UI.DisplayNotACommand();
                    Start();
                    break;
            }
        }

        public bool AddAnimal()
        {
            int? emptyRoomID = GetFirstEmptyRoom();

            if (emptyRoomID == null)
            {
                Console.WriteLine("No Rooms are available.");
                return false;
            }

            int activityLevel = int.Parse(UI.GetUserInput("Provide an activity level 1-10"));
            string name = UI.GetUserInput("Provide a name:");
            int age = int.Parse(UI.GetUserInput("Provide animal age:"));
            bool adoptionStatus = false;
            string breed = UI.GetUserInput("Provide a breed:");
            string species = UI.GetUserInput("Provide a species:");
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

        public void VaccinateAnimal(int animalID)
        {
            var vaccinate = humaneSocietyDB.Animals.Where(x => x.ID == animalID);
            foreach (var x in vaccinate)
            {
                x.VaccinationStatus = true;
            }
            humaneSocietyDB.SubmitChanges();
        }

        public void DisplayRooms()
        {
            var rooms = humaneSocietyDB.Animals.Join(humaneSocietyDB.Rooms,
                a => a.FK_Rooms_ID,
                r => r.ID,
                (a, r) => new { r.RoomNumber, a.Species, a.Name});
            Console.WriteLine("");
            foreach (var item in rooms)
            {
                Console.WriteLine($"[ROOM {item.RoomNumber}] {item.Species} {item.Name}");
            }
            Console.WriteLine("");
        }

        public void DisplayAdoptedAnimals()
        {
            var adopted = humaneSocietyDB.Animals.Where(x => x.AdoptionStatus == true);
            foreach (var x in adopted)
            {
                Console.WriteLine("{0} {1}",x.Species,x.Name);
            }
        }
    }
}
