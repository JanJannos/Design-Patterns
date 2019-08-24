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
//    public interface IExpressionVisitor
//    {
//        void Visit(DoubleExpression de);
//        void Visit(AdditionExpression ae);
//    }

//    public abstract class Expression
//    {
//        public abstract void Accept(IExpressionVisitor visitor);

//    }

//    public class DoubleExpression : Expression
//    {
//        public double Value;

//        public DoubleExpression(double val)
//        {
//            Value = val;
//        }

//        public override void Accept(IExpressionVisitor visitor)
//        {
//            // Double dispatch
//            visitor.Visit(this);
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

//        public override void Accept(IExpressionVisitor visitor)
//        {
//            visitor.Visit(this);
//        }
//    }

//    public class ExpressionPrinter : IExpressionVisitor
//    {
//        StringBuilder sb = new StringBuilder();

//        public void Visit(DoubleExpression de)
//        {
//            sb.Append(de.Value);
//        }

//        public void Visit(AdditionExpression ae)
//        {
//            sb.Append("(");
//            ae.Left.Accept(this);
//            sb.Append("+");
//            ae.Right.Accept(this);
//            sb.Append(")");
//        }

//        public override string ToString()
//        {
//            return this.sb.ToString(); 
//        }
//    }


//    public class ExpressionCalculator : IExpressionVisitor
//    {
//        public double Result;

//        public void Visit(DoubleExpression de)
//        {
//            Result = de.Value;
//        }

//        public void Visit(AdditionExpression ae)
//        {
//            ae.Left.Accept(this);
//            var a = Result;
//            ae.Right.Accept(this);
//            var b = Result;
//            Result = a + b;
//        }
//    }

//    public class VisitorProgram4
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
//            var ep = new ExpressionPrinter();
//            ep.Visit(e);
//            Console.WriteLine(ep);

//             // Calc
//             var calc = new ExpressionCalculator();
//             calc.Visit(e);
//             Console.WriteLine($"{ep} = {calc.Result}");
//        }
//    }
//}