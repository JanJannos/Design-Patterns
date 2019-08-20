using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using MoreLinq;

namespace Design_Patterns
{

    public interface IDatabase
    {
        int GetPopulation(string name);
    }


    public class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> capitals;

        //private static SingletonDatabase instance = new SingletonDatabase();
        // Create a lazy one

        private static Lazy<SingletonDatabase> instance =
            new Lazy<SingletonDatabase>(
                () => new SingletonDatabase());
        public static SingletonDatabase Instance => instance.Value;

        private SingletonDatabase()
        {
            Console.WriteLine("Initializing Database");
            capitals = File.ReadAllLines("Capitals.txt").Batch(2)
                .ToDictionary(
                list => list.ElementAt(0).Trim(),
                value => int.Parse(value.ElementAt(1)));
        }

        public int GetPopulation(string name)
        {
            return capitals[name];
        }
    }


    

    public class Program
    {
        static void Main(String[] args)
        {
            var db = SingletonDatabase.Instance;
            string city = "Tokyo";
            Console.WriteLine($"{city} has population of {db.GetPopulation(city)} people");
        }
    }
}
