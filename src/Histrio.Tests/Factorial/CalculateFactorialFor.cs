namespace Histrio.Tests.Factorial
{
    public class CalculateFactorialFor
    {
        public CalculateFactorialFor(uint x, Address customer)
        {
            X = x;
            Customer = customer;
        }

        public uint X { get; private set; }
        public Address Customer { get; private set; }
    }
}