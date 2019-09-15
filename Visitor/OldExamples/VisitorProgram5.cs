//using System;
//using System.Collections.Generic;
//using System.Runtime.CompilerServices;
//using System.Security.Cryptography.X509Certificates;
//using System.Text;
//using System.Threading.Tasks.Dataflow;


///**
// *  Visitor pattern - the problem is that we have hierarchy of classes
// *  and we need to add a functionality to that hierarchy 
// */


//namespace Design_Patterns.Visitor
//{

//    public abstract class Expression
//    {

//    }

//    public class DoubleExpression : Expression
//    {
//        public double Value;

//        public DoubleExpression(double val)
//        {
//            Value = val;
//        }


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


//    }

//    public class ExpressionPrinter
//    {
//        public void Print(AdditionExpression ae, StringBuilder sb)
//        {
//            sb.Append("(");
//            Print((dynamic)ae.Left, sb);
//            sb.Append("+");
//            Print((dynamic)ae.Right, sb);
//            sb.Append(")");
//        }

//        public void Print(DoubleExpression de, StringBuilder sb)
//        {
//            sb.Append(de.Value);
//        }
//    }


//    public class VisitorProgram5
//    {
//        public static void Main()
//        {
//            Expression e = new AdditionExpression(
//                new DoubleExpression(1),
//                new AdditionExpression(
//                    new DoubleExpression(2),
//                    new DoubleExpression(3)
//                )
//            );

//            var ep = new ExpressionPrinter();
//            var sb = new StringBuilder();
//            ep.Print((dynamic)e , sb);
//            Console.WriteLine(sb);

//        }
//    }
//}