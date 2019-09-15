//using System;
//using System.Collections.Generic;
//using System.Text;


///**
// *  Visitor pattern - the problem is that we have hierarchy of classes
// *  and we need to add a functionality to that hierarchy 
// */


//namespace Design_Patterns.Visitor
//{
//    public abstract class Expression
//    {
//        public abstract void Print(StringBuilder sb);
//    }

//    public class DoubleExpression : Expression
//    {
//        private double value;

//        public DoubleExpression(double val)
//        {
//            value = val;
//        }

//        public override void Print(StringBuilder sb)
//        {
//            sb.Append(value);
//        }
//    }

//    public class AdditionExpression : Expression
//    {

//        private Expression left, right;


//        public AdditionExpression(Expression left, Expression right)
//        {
//            this.left = left ?? throw new ArgumentNullException(paramName: nameof(left));
//            this.right = right ?? throw new ArgumentNullException(paramName: nameof(right));
//        }

//        public override void Print(StringBuilder sb)
//        {
//            sb.Append("(");
//            left.Print(sb);
//            sb.Append("+");
//            right.Print(sb);
//            sb.Append(")");
//        }
//    }



//    public class VisitorProgram
//    {
//        public static void Main()
//        {
//            var e = new AdditionExpression(
//                new DoubleExpression(1), 
//                new AdditionExpression(
//                        new DoubleExpression(2), 
//                        new DoubleExpression(3)
//                    )
//                );


//            var sb = new StringBuilder();
//            e.Print(sb);
//            Console.WriteLine(sb);
//        }
//    }
//}
