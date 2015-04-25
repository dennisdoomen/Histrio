using System;

namespace Histrio
{
    /// <summary>
    ///     A Cell behaves like a property. One can get en set value in / from it using message passing
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CellBehavior<T> : BehaviorBase, IObserver<Get>, IObserver<Set<T>>
    {
        private T _contents;

        /// <summary>
        ///     Processes a Get message and sends the content to the customer
        /// </summary>
        /// <param name="message">The message.</param>
        public void OnNext(Get message)
        {
            var reply = new Reply<T>(_contents);
            Actor.Send(reply, message.Customer);
        }

        void IObserver<Get>.OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        void IObserver<Get>.OnCompleted()
        {
            throw new NotImplementedException();
        }

        void IObserver<Set<T>>.OnCompleted()
        {
            throw new NotImplementedException();
        }

        void IObserver<Set<T>>.OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Processes a Set message and stores the content in it locally
        /// </summary>
        /// <param name="message">The message.</param>
        public void OnNext(Set<T> message)
        {
            _contents = message.Content;
        }
    }
}