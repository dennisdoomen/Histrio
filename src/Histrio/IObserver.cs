namespace Histrio
{

    /// <summary>
    /// 
    /// </summary>
    public interface IObserver
    {
        /// <summary>
        ///     Accepts the specified message and checkes if the message can be handled by this behavior.
        ///     If so, it notifies the message it can be handled. It uses a double dispatch to let the message
        ///     handle itself in s strongly typed fashion by the behavior
        /// </summary>
        /// ///
        /// <typeparam name="T">The type of content the message enbodies</typeparam>
        /// <param name="message">The message.</param>
        /// <exception cref="T:System.InvalidOperationException">
        ///     The exception is thrown when the behavior can not handle this type of
        ///     message content
        /// </exception>
        void OnNext<T>(Observable<T> message);
    }

    /// <summary>
    ///     An interface that is used to specify that a behavior can handle a specific type of message
    /// </summary>
    /// <typeparam name="T">The type of the message it can handle</typeparam>
    public interface IObserver<in T>
    {
        /// <summary>
        ///     Accepts the specified message. OnNext is Actor Model terminology for "I can do something with this message"
        /// </summary>
        /// <param name="message">The message.</param>
        void OnNext(T message);
    }
}