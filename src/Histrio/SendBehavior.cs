namespace Histrio
{
    /// <summary>
    ///     A behavior that simply forwards message to an address of another actor
    /// </summary>
    public class SendBehavior : BehaviorBase
    {
        private readonly Address _address;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SendBehavior" /> class.
        /// </summary>
        /// <param name="address">The address the behavior fill forward messages to</param>
        public SendBehavior(Address address)
        {
            _address = address;
        }

        /// <summary>
        ///     Accepts the specified message and checkes if the message can be handled by this behavior.
        ///     If so, it notifies the message it can be handled. It uses a double dispatch to let the message
        ///     handle itself in a strongly typed fashion by the behavior
        /// </summary>
        /// <typeparam name="T">The type of content the message enbodies</typeparam>
        /// <param name="message">The message.</param>
        public override void OnNext<T>(Observable<T> message)
        {
            Actor.Send(message.Subject, _address);
        }
    }
}