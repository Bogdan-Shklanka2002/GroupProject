using System;
using System.Collections.Generic;
using System.Text;
using CalcClass;

namespace Analizer
{
    public class AnalizerEx
    {
        public AnalizerEx(string input)
        {
            var nodes = new Stack<BinaryExpression>();
            foreach (var c in ToPostFix(Split(input)))
            {
                var s = c.ToString();
                double n;
                if (double.TryParse(s, out n))
                {
                    nodes.Push(new BinaryAtomic(n));
                }
                else if (IsOperator(s))
                {
                    var r = nodes.Pop();
                    var l = nodes.Pop();
                    nodes.Push(new BinaryExpression(l, r, Operators[s]));
                }
            }
            tree = nodes.Pop();


        }

        public double Evaluate => tree.Value;

        private BinaryExpression tree;

        private static List<String> ToPostFix(List<string> input)
        {
            var postfix = new List<String>();
            var ops = new Stack<string>();
            foreach (var c in input)
            {

                if (IsOperator(c))
                {
                    while (ops.Count > 0 && Precedence(ops.Peek()) >= Precedence(c))
                        postfix.Add(ops.Pop());
                    ops.Push(c);
                }
                else
                {
                    switch (c)
                    {
                        case "(":
                            ops.Push(c);
                            break;

                        case ")":
                            var top = ops.Pop();
                            while (top != "(")
                            {
                                postfix.Add(top);
                                top = ops.Pop();
                            }
                            break;
                        default:
                            postfix.Add(c);
                            break;
                    }
                }
            }

            while (ops.Count > 0)
            {
                var s = ops.Pop();
                if (s != "(" && s != ")")
                    postfix.Add(s);
            }

            return postfix;
        }


        private static bool IsOperator(string op)
        {
            return op == "-" || op == "+" ||
                   op == "*" || op == "/";
        }


        private static int Precedence(string op)
        {
            if (op == "-" || op == "+")
                return 1;
            if (op == "*" || op == "/")
                return 2;
            return 0;
        }

        private static Dictionary<string, Operator> Operators = new Dictionary<string, Operator>()
         {
        {"+", (x, y) => Calculations.Add((long)x,(long)y)},
        {"-", (x, y) => Calculations.Sub((long)x,(long)y)},
        {"*", (x, y) =>Calculations.Mult((long)x,(long)y)},
        {"/", (x, y) =>Calculations.Sub((long)x,(long)y)},
        };
        public List<string> Split(string str)
        {
            List<string> l = new List<string>();
            StringBuilder builder = new StringBuilder();
            foreach (var item in str)
            {
                if (!IsOperator(item.ToString()) && item != '(' && item != ')')
                {
                    builder.Append(item);
                }
                else
                {
                    l.Add(builder.ToString());
                    l.Add(item.ToString());
                    builder.Clear();
                }
            }
            l.Add(builder.ToString());

            return l;
        }
    }
    internal delegate double Operator(double x, double y);


    internal class BinaryExpression
    {
        protected BinaryExpression()
        {
        }


        public BinaryExpression(BinaryExpression left, BinaryExpression right,
            Operator op)
        {
            Left = left; Right = right; Operator = op;
        }


        public virtual double Value
        {
            get
            {
                return Operator(Left.Value, Right.Value);
            }
            protected set { }
        }

        public BinaryExpression Left;
        public BinaryExpression Right;
        public Operator Operator;
    }

    internal class BinaryAtomic : BinaryExpression
    {
        protected BinaryAtomic()
        {
        }


        public BinaryAtomic(double value)
        {
            Value = value;
        }


        public override double Value
        {
            get;
            protected set;
        }

        public override string ToString()
        {
            return Value.ToString();
        }


    }
}
