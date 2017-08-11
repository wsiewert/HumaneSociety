using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanSociety
{
    class Program
    {
        static void Main(string[] args)
        {
            HumaneSocietyDBDataContext humaneSocietyDB = new HumaneSocietyDBDataContext();
            //Animal animal = new Animal
            //{
            //    ActivityLevel = 5,
            //    Age = 5,
            //    AdoptionStatus = false,
            //    Breed = "EXAMPLE",
            //    Name = "EXAMPLE",
            //    Species = "EXAMPLE",
            //    VaccinationStatus = false,
            //    FoodType = "EXAMPLE",
            //    FoodQuantity = 5,
            //};

            //humaneSocietyDB.Animals.InsertOnSubmit(animal);
            //humaneSocietyDB.SubmitChanges();

            //var roomNumber = humaneSocietyDB.Rooms.Where(x => x.OccupiedStatus == false);

            //foreach (var x in roomNumber)
            //{
            //    Console.WriteLine(x.RoomNumber);
            //}

            HumaneSociety humaneSociety = new HumaneSociety();
            //humaneSociety.AddAnimal();
            //humaneSociety.RemoveAnimalFromRoom(5);
            //humaneSociety.SetAdoptionStatus(6,true);
            humaneSociety.VaccinateAnimal(6);

            Console.ReadLine();
        }
    }
}
