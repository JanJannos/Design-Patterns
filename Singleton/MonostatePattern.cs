using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns.Singleton
{

    public class CEO
    {
        private static String name;
        private static int age;

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Age)}: {Age}";
        }

        public String Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
    }

    public class MonostatePattern
    {
        public static void Main1(string[] args)
        {
            var ceo = new CEO();
            ceo.Name = "Jack";
            ceo.Age = 55;

            var ceo2 = new CEO();
            Console.WriteLine(ceo2);

            // With this approach we always get the same data , 
            // not creating a new CEO because of the static members
        }
    }
}
