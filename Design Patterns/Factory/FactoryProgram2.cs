//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Design_Patterns
//{
//    public interface IHotDrink
//    {
//        void Consume();
//    }

//    internal class Tea : IHotDrink
//    {
//        public void Consume()
//        {
//            Console.WriteLine("This tea is sensational");
//        }
//    }

//    internal class Coffee : IHotDrink
//    {
//        public void Consume()
//        {
//            Console.WriteLine("This coffee is sensational");
//        }
//    }


//    public interface IHotDrinkFactory
//    {
//        IHotDrink Prepare(int amount);
//    }

//    internal class TeaFactory : IHotDrinkFactory
//    {
//        public IHotDrink Prepare(int amount)
//        {
//            Console.WriteLine($"Put in a tea bag ,boil water , pour {amount} ml , add lemon and enjoy!");
//            return new Tea();
//        }
//    }


//    internal class CoffeeFactory : IHotDrinkFactory
//    {
//        public IHotDrink Prepare(int amount)
//        {
//            Console.WriteLine($"Grind some beans ,boil water , pour {amount} ml , add cream and sugar and enjoy!");
//            return new Coffee();
//        }
//    }


//    public class HotDrinkMachine
//    {       
//        private List<Tuple<String, IHotDrinkFactory>> factories = new
//            List<Tuple<string, IHotDrinkFactory>>();


//        public HotDrinkMachine()
//        {
//            foreach (var type in typeof(HotDrinkMachine).Assembly.GetTypes())
//            {
//                if (typeof(IHotDrinkFactory).IsAssignableFrom(type) &&
//                    !type.IsInterface)
//                {
//                    factories.Add(Tuple.Create(type.Name.Replace("Factory", String.Empty),
//                        (IHotDrinkFactory)Activator.CreateInstance(type)));
//                }
//            }
//        }

//        public IHotDrink MakeDrink()
//        {
//            Console.WriteLine("Availble Drinks:");
//            for (int index = 0; index < factories.Count; index++)
//            {
//                var tuple = factories[index];
//                Console.WriteLine($"{index}:{tuple.Item1}");
//            }

//            while (true)
//            {
//                String s;
//                if ((s = Console.ReadLine()) != null
//                    && int.TryParse(s, out int i)
//                    && i >= 0
//                    && i < factories.Count)
//                {
//                    Console.Write("Specify Amount :");
//                    s = Console.ReadLine();
//                    if (s != null
//                            && int.TryParse(s, out int amount)
//                            && amount > 0)
//                    {
//                        return factories[i].Item2.Prepare(amount);
//                    }
//                }

//                Console.WriteLine("Incorrect amount , try again");
//            }


//        }

//    }

//    public class Program2
//    {
//        static void Main(string[] args)
//        {
//            var machine = new HotDrinkMachine();
//            var drink = machine.MakeDrink();
//            drink.Consume();           
//        }
//    }
//}
