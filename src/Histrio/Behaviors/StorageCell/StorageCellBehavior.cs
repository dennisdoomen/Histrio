﻿namespace Histrio.Behaviors.StorageCell
{
    /// <summary>
    /// A StorageCell behaves like a property. One can get en set value in / from it using message passing
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class StorageCellBehavior<T> : BehaviorBase, IHandle<Get>, IHandle<Set<T>>
    {
        private T _contents;

        /// <summary>
        /// Processes a Get message and sends the content to the customer
        /// </summary>
        /// <param name="message">The message.</param>
        public void Accept(Get message)
        {
            var reply = new Reply<T>(_contents);
            var replyMessage = reply.AsMessage();
            replyMessage.To = message.Customer;
            Actor.Send(replyMessage);
        }

        /// <summary>
        /// Processes a Set message and stores the content in it locally
        /// </summary>
        /// <param name="message">The message.</param>
        public void Accept(Set<T> message)
        {
            _contents = message.Content;
        }
    }
}