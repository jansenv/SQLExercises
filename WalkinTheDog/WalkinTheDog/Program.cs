using System;
using System.Linq;
using WalkinTheDog.Data;

namespace WalkinTheDog
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exercise i 
            
            var walkerRepo = new WalkerRepository();
            var walkers = walkerRepo.GetAllWalkers();

            Console.WriteLine("Walkers:");
            foreach (var walker in walkers)
            {
                Console.WriteLine($"{walker.Id}: {walker.Name}");
            }

            // Exercise ii
            // getting all walkers in Mr. Rogers neighborhood b/c i don't want to add another new neighborhood

            var MrRogersNeighborhoodWalkers = walkers.Where(walker => walker.Neighborhood.Name == "Mr. Rogers");
            Console.WriteLine("Walkers in Mr. Rogers' Neighborhood:");
            foreach (var walker in MrRogersNeighborhoodWalkers)
            {
                Console.WriteLine($"{walker.Id}: {walker.Name}");
            }
        }
    }
}
