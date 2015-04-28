using System;

namespace Histrio
{
    /// <summary>
    /// </summary>
    public abstract class Observer
    {
        /// <summary>
        ///     Accepts the specified observable and checks if the observable can be handled by the observer.
        ///     If so, it notifies the observable it can be handled. It uses a double dispatch to let the observable
        ///     handle itself in a strongly typed fashion by an <see cref="IObserver{T}" /> that the concrete Obserer
        ///     also may implement
        /// </summary>
        /// <typeparam name="T">The type of the subject the observable represents</typeparam>
        /// <param name="observable">The observable.</param>
        /// <exception cref="InvalidOperationException">
        ///     The exception is thrown when no <see cref="IObserver{T}" />, implemented by the concrete Observer,
        ///     can handle the subject of the observable
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