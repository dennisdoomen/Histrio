using System;

namespace Histrio.Tests.Factorial
{
    public class FactorialContinuationBehavior : Behavior, IObserver<CalculateFactorialFor>,
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
            var factorialCalculated = new CalculatedFactorial
            {
                For = message.X,
                Result = _x*message.X
            };
            SendFactorialCalculated(factorialCalculated);
        }

        void IObserver<CalculateFactorialFor>.OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        void IObserver<FactorialCalculated>.OnCompleted()
        {
            throw new NotImplementedException();
        }

        void IObserver<FactorialCalculated>.OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        void IObserver<CalculateFactorialFor>.OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnNext(FactorialCalculated message)
        {
            var factorialCalculated = new CalculatedFactorial
            {
                For = message.For,
                Result = _x*message.Result
            };
            SendFactorialCalculated(factorialCalculated);
        }

        private void SendFactorialCalculated(CalculatedFactorial factorialCalculated)
        {
            Actor.Send(factorialCalculated, _customer);
        }
    }
}