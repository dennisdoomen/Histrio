namespace Histrio
{
    /// <summary>
    ///     A message that carries a typed payload anabling strongly type message handling
    ///     using POCO (Plain Old CLR Objects).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Message<T> : Observable<T>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Message{T}" /> class.
        /// </summary>
        /// <param name="subject">The Subject.</param>
        public Message(T subject) : base(subject)
        {
        }

        /// <summary>
        ///     Gets or sets the <see cref="Address" /> of the Actor that is the recipient of this message
        /// </summary>
        /// <value>
        ///     To.
        /// </value>
        public Address To { get; set; }
    }
}