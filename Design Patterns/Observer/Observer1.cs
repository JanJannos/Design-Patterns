//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Design_Patterns.Observer
//{

//    public class FallsIllEventArgs
//    {
//        public string Address;
//    }

//    public class Person
//    {

//        public void CatchACold()
//        {
//            FallsIll?.Invoke(this, new FallsIllEventArgs
//            {
//                Address = "123 Jackson Road"
//            });
//        }

//        public event EventHandler<FallsIllEventArgs> FallsIll;
//    }

//    public class Observer1
//    {
//        public static void Main(string[] args)
//        {
//            var person = new Person();
//            person.FallsIll += CallDoctor;
//            person.CatchACold();
//        }

//        private static void CallDoctor(object sender, FallsIllEventArgs e)
//        {
//            Console.WriteLine($"A doctor has been called to {e.Address}");
//        }
//    }
//}
