namespace Analizer
{
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
}