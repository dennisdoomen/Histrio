namespace Histrio
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Observable<T>
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
        /// <param name="behavior">The observer.</param>
        internal void GetHandledBy(IObserver<T> behavior)
        {
            behavior.OnNext(Subject);
        }

        /// <summary>
        ///     Gets the handled by.
        /// </summary>
        /// <param name="observer">The observer.</param>
        public void GetHandledBy(IObserver observer)
        {
            observer.OnNext(this);
        }
    }
}