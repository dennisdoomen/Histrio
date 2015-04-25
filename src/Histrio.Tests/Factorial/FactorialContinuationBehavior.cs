namespace Histrio.Tests.Factorial
{
    public class FactorialContinuationBehavior : BehaviorBase, IObserver<CalculateFactorialFor>,
        IObserver<FactorialCalculated>
    {
        private readonly Address _customer;
        private readonly int _x;

        public FactorialContinuationBehavior(CalculateFactorialFor message)
        {
            _x = message.X;
            _customer = message.Customer;
        }

        public void OnNext(CalculateFactorialFor message)
        {
            var factorialCalculated = new FactorialCalculated
            {
                For = message.X,
                Result = _x*message.X
            };
            SendFactorialCalculated(factorialCalculated);
        }

        public void OnNext(FactorialCalculated message)
        {
            var factorialCalculated = new FactorialCalculated
            {
                For = message.For,
                Result = _x*message.Result
            };
            SendFactorialCalculated(factorialCalculated);
        }

        private void SendFactorialCalculated(FactorialCalculated factorialCalculated)
        {
            Actor.Send(factorialCalculated, _customer);
        }
    }
}