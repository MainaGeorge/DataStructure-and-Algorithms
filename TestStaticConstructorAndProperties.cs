namespace dojo
{
    public class TestStaticConstructorAndProperties
    {
        public static double InterestRate
        {
            get
            {
                return _interestRate;
            }
            set
            {
                if (value > 0)
                {
                    _interestRate = value;
                }
            }
        }
        public int Amount { get; }

        private static double _interestRate;

        public TestStaticConstructorAndProperties(int amount)
        {
            Amount = amount;
        }

        static TestStaticConstructorAndProperties()
        {
            _interestRate = 4.5;
        }

        public double GetInterest => Amount * _interestRate / 100;

        public double GetSumToRepay => Amount + GetInterest;
    }
}
