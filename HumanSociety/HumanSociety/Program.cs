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
            //HumaneSocietyDBDataContext humaneSocietyDB = new HumaneSocietyDBDataContext();
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

            HumaneSociety humaneSociety = new HumaneSociety();
            humaneSociety.AddAnimal();

            Console.ReadLine();
        }
    }
}
