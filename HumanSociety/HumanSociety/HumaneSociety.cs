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
                    customer.Start();
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

        public int AddCustomerProfile()
        {
            List<object> customerProfile = UI.CreateCustomerProfile();
            Customer customer = new Customer
            {
                FirstName = customerProfile[0].ToString(),
                LastName = customerProfile[1].ToString(),
                Age = int.Parse(customerProfile[2].ToString()),
                ActivityLevel = int.Parse(customerProfile[3].ToString()),
                MartialStatus = bool.Parse(customerProfile[4].ToString()),
                Occupation = bool.Parse(customerProfile[5].ToString())
            };
            humaneSocietyDB.Customers.InsertOnSubmit(customer);
            humaneSocietyDB.SubmitChanges();
            return customer.ID;
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

        public void PurchaseAnimal(int customerID, int animalID)
        {
            //join tables
            //set adoption status
            //remove from room
            //setup transaction table

            //var rooms = humaneSocietyDB.Animals.Join(humaneSocietyDB.Rooms,
            //    a => a.FK_Rooms_ID,
            //    r => r.ID,
            //    (a, r) => new { r.RoomNumber, a.Species, a.Name });
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
                Console.WriteLine($"[ROOM {item.RoomNumber}] {item.Species}, {item.Name}");
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

        public void DisplaySusceptibleAnimals()
        {
            var susceptibleAnimals = humaneSocietyDB.Animals.Where(x => x.VaccinationStatus == false);
            foreach (var item in susceptibleAnimals)
            {
                Console.WriteLine($"[ID: {item.ID}] {item.Species}, {item.Name}");
            }
        }

        public void DisplayFullDetailsByID(int animalID)
        {
            var vaccinate = humaneSocietyDB.Animals.Where(x => x.ID == animalID);
            foreach (var item in vaccinate)
            {
                Console.WriteLine($"  [ID: {item.ID}]");
                Console.WriteLine($"  Name: {item.Name}");
                Console.WriteLine($"  Age: {item.Age}");
                Console.WriteLine($"  Species: {item.Species}");
                Console.WriteLine($"  Breed: {item.Breed}");
                Console.WriteLine($"  Gender: {item.Gender}");
                Console.WriteLine($"  Adopted: {item.AdoptionStatus}");
                Console.WriteLine($"  Vaccinated: {item.VaccinationStatus}");
                Console.WriteLine($"  Food Type: {item.FoodType}");
                Console.WriteLine($"  Food Quantity: {item.FoodQuantity}");
                Console.WriteLine($"  Activity Level: {item.ActivityLevel}");
                Console.WriteLine($"  ${item.Price}");
            }
        }

        public void SortByAge()
        {
            var ageSort = humaneSocietyDB.Animals.OrderBy(x => x.Age);
            foreach (var item in ageSort)
            {
                Console.WriteLine($"[ID: {item.ID}] {item.Age}Yr, {item.Species}, {item.Name}");
            }
        }

        public void SortByName()
        {
            var nameSort = humaneSocietyDB.Animals.OrderBy(x => x.Name);
            foreach (var item in nameSort)
            {
                Console.WriteLine($"[ID: {item.ID}] {item.Species}, {item.Name}");
            }
        }

        public void SortBySpecies()
        {
            var speciesSort = humaneSocietyDB.Animals.OrderBy(x => x.Species);
            foreach (var item in speciesSort)
            {
                Console.WriteLine($"[ID: {item.ID}] {item.Species}, {item.Name}");
            }
        }

        public void SortByGender()
        {
            var genderSort = humaneSocietyDB.Animals.OrderBy(x => x.Gender);
            foreach (var item in genderSort)
            {
                Console.WriteLine($"[ID: {item.ID}] {item.Species}, {item.Name}, {item.Gender}");
            }
        }

        public void DisplayAnimalFoodType()
        {
            var foodType = humaneSocietyDB.Animals.OrderBy(x => x.FoodType);
            foreach (var item in foodType)
            {
                Console.WriteLine($"[ID: {item.ID}] {item.Species}, {item.Name}");
                Console.WriteLine($"  Food Type: {item.FoodType}");
                Console.WriteLine($"  Food Quantity: {item.FoodQuantity}");
                Console.WriteLine("");
            }
        }

        public bool CheckCustomerEligibiltiy(int CustomerID)
        {
            int temporaryAge = 0;
            int temporaryActivityLevel = 0;
            bool temporaryMartialStatus = false;
            bool temporaryOccupation = false;
            var customerElegibilty = humaneSocietyDB.Customers.Where(x => x.ID == CustomerID);
            foreach (var x in customerElegibilty)
            {
                temporaryAge = x.Age;
                temporaryActivityLevel = x.ActivityLevel;
                temporaryMartialStatus = x.MartialStatus;
                temporaryOccupation = x.Occupation;
            }
            if ((temporaryActivityLevel > 2 && temporaryAge >= 18) && (temporaryMartialStatus || temporaryOccupation))
            {
                return true;
            }
            return false;
        }

        public void SearchCollectionBySpecies(string species)
        {
            var searchSpecies = humaneSocietyDB.Animals.Where(x => x.Species == species);
            foreach (var item in searchSpecies)
            {
                Console.WriteLine($"[ID: {item.ID}] {item.Species} {item.Name}");
            }
        }

        public void SearchCollectionByAge(int age)
        {
            var searchSpecies = humaneSocietyDB.Animals.Where(x => x.Age == age);
            foreach (var item in searchSpecies)
            {
                Console.WriteLine($"[ID: {item.ID}] {item.Species} {item.Name} {item.Age}");
            }
        }
    }
}
