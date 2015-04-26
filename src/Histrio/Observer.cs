using System;

namespace Histrio
{
    /// <summary>
    /// </summary>
    public abstract class Observer
    {
        /// <summary>
        ///     Accepts the specified message and checkes if the message can be handled by this behavior.
        ///     If so, it notifies the message it can be handled. It uses a double dispatch to let the message
        ///     handle itself in s strongly typed fashion by the behavior
        /// </summary>
        /// ///
        /// <typeparam name="T">The type of content the message enbodies</typeparam>
        /// <param name="observable">The message.</param>
        /// <exception cref="InvalidOperationException">
        ///     The exception is thrown when the behavior can not handle this type of
        ///     message content
        /// </exception>
        public virtual void OnNext<T>(Observable<T> observable)
        {
            var observer = this as IObserver<T>;
            if (observer != null)
            {
                observable.GetHandledBy(observer);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}