namespace Analizer
{
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