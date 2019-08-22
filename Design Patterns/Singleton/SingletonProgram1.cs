using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreLinq;

namespace Design_Patterns.Singleton
{

    public interface IDatabase
    {
        int GetPopulation(string name);
    }


    public class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> capitals;
        private static int instanceCount; // 0
        public static int Count => instanceCount;

        private SingletonDatabase()
        {
            instanceCount++;
            Console.WriteLine("Initializing Database");
            capitals = File.ReadAllLines("Capitals.txt").Batch(2)
                .ToDictionary(
                    list => list.ElementAt(0).Trim(),
                    value => int.Parse(value.ElementAt(1)));
        }

        //private static SingletonDatabase instance = new SingletonDatabase();
        // Create a lazy one

        private static Lazy<SingletonDatabase> instance =
            new Lazy<SingletonDatabase>(
                () => new SingletonDatabase());
        public static SingletonDatabase Instance => instance.Value;



        public int GetPopulation(string name)
        {
            return capitals[name];
        }
    }


    public class SingletonRecordFinder
    {
        public int GetTotalPopulation(IEnumerable<String> names)
        {
            int result = 0;
            foreach (var name in names)
            {
                result += SingletonDatabase.Instance.GetPopulation(name);
            }

            return result;
        }
    }

    public class ConfigurableRecordFinder
    {
        private IDatabase database;

        public ConfigurableRecordFinder(IDatabase injectedDatabase)
        {
            if (this.database == null)
            {
                this.database = injectedDatabase ?? throw new ArgumentNullException(paramName: nameof(database));
            }
        }

        public int GetTotalPopulation(IEnumerable<String> names)
        {
            int result = 0;
            foreach (var name in names)
            {
                result += database.GetPopulation(name);
            }

            return result;
        }
    }


    public class DummyDatabase : IDatabase
    {
        public int GetPopulation(string name)
        {
            return new Dictionary<string, int>
            {
                ["alpha"] = 1,
                ["beta"] = 2,
                ["gamma"] = 3
            }[name];
        }
    }


    public class Program
    {
        //static void Main(String[] args)
        //{
        //    var db = SingletonDatabase.Instance;
        //    string city = "Tokyo";
        //    Console.WriteLine($"{city} has population of {db.GetPopulation(city)} people");
        //}
    }
}
