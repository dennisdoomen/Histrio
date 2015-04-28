using System;

namespace Histrio.Tests.Factorial
{
    public class FactorialContinuationBehavior : Behavior, IObserver<CalculateFactorialFor>,
        IObserver<CalculatedFactorial>
    {
        private readonly Address _customer;
        private readonly uint _x;

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

        /// <summary>
        /// Notifies the observer that the provider has finished sending push-based notifications.
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        void IObserver<CalculatedFactorial>.OnCompleted()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Called when [error].
        /// </summary>
        /// <param name="error">The error.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        void IObserver<CalculatedFactorial>.OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        void IObserver<CalculateFactorialFor>.OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnNext(CalculatedFactorial message)
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