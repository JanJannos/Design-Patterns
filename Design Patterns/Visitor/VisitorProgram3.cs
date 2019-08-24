//using System;
//using System.Collections.Generic;
//using System.Runtime.CompilerServices;
//using System.Security.Cryptography.X509Certificates;
//using System.Text;


///**
// *  Visitor pattern - the problem is that we have hierarchy of classes
// *  and we need to add a functionality to that hierarchy 
// */


//namespace Design_Patterns.Visitor
//{
//    using dictType = Dictionary<Type, Action<Expression, StringBuilder>>;

//    public abstract class Expression
//    {
//        // public abstract void Print(StringBuilder sb);
//    }

//    public class DoubleExpression : Expression
//    {
//        public double Value;

//        public DoubleExpression(double val)
//        {
//            Value = val;
//        }

//        //public override void Print(StringBuilder sb)
//        //{
//        //    sb.Append(value);
//        //}
//    }

//    public class AdditionExpression : Expression
//    {
//        public Expression Left;
//        public Expression Right;


//        public AdditionExpression(Expression left, Expression right)
//        {
//            this.Left = left ?? throw new ArgumentNullException(paramName: nameof(left));
//            this.Right = right ?? throw new ArgumentNullException(paramName: nameof(right));
//        }

//        //public override void Print(StringBuilder sb)
//        //{
//        //    sb.Append("(");
//        //    Left.Print(sb);
//        //    sb.Append("+");
//        //    Right.Print(sb);
//        //    sb.Append(")");
//        //}
//    }



//    public static class ExpressionPrinter
//    {
//        //public static void Print(Expression e, StringBuilder sb)
//        //{
//        //    if (e is DoubleExpression de)
//        //    {
//        //        sb.Append(de.Value);
//        //    }
//        //    else if (e is AdditionExpression ae)
//        //    {
//        //        sb.Append("(");
//        //        Print(ae.Left, sb);
//        //        sb.Append("+");
//        //        Print(ae.Right, sb);
//        //        sb.Append(")");
//        //    }
//        //}


//        public static void Print(Expression e, StringBuilder sb)
//        {
//            actions[e.GetType()](e, sb);
//        }

//        private static dictType actions = new dictType
//        {
//            [typeof(DoubleExpression)] = (e, sb) =>
//            {
//                var de = (DoubleExpression)e;
//                sb.Append(de.Value);
//            },
//            [typeof(AdditionExpression)] = (e, sb) =>
//            {
//                var ae = (AdditionExpression) e;
//                sb.Append("(");
//                Print(ae.Left, sb);
//                sb.Append("+");
//                Print(ae.Right, sb);
//                sb.Append(")");
//            }


//        };
//    }

//    public class VisitorProgram3
//    {
//        public static void Main()
//        {
//            var e = new AdditionExpression(
//                new DoubleExpression(1),
//                new AdditionExpression(
//                    new DoubleExpression(2),
//                    new DoubleExpression(3)
//                )
//            );


//            var sb = new StringBuilder();
//            // e.Print(sb);
//            ExpressionPrinter.Print(e, sb);
//            Console.WriteLine(sb);
//        }
//    }
//}