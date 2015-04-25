using System;

namespace Histrio
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Observable<T> : IObservable<T>
    {
        /// <summary>
        ///     Gets or sets the Subject.
        /// </summary>
        /// <value>
        ///     The Subject.
        /// </value>
        public T Subject { get; protected set; }

        /// <summary>
        ///     Gets the handled by.
        /// </summary>
        /// <param name="observer">The observer.</param>
        internal void GetHandledBy(IObserver<T> observer)
        {
            observer.OnNext(Subject);
        }

        /// <summary>
        ///     Gets the handled by.
        /// </summary>
        /// <param name="observer">The observer.</param>
        public void GetHandledBy(IObserver observer)
        {
            observer.OnNext(this);
        }

        /// <summary>
        /// Subscribes the specified observer.
        /// </summary>
        /// <param name="observer">The observer.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IDisposable Subscribe(IObserver<T> observer)
        {
            throw new NotImplementedException();
        }
    }
}