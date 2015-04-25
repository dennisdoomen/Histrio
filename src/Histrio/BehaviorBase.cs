namespace Histrio
{
    /// <summary>
    ///     A base class for implementing behaviors that get injected into Actors
    /// </summary>
    public abstract class BehaviorBase : Observer
    {
        /// <summary>
        ///     Gets or sets the actor the behavior is injected to. Use this reference to create new Actors,
        ///     send messages to other Actors and replace this Actor with a new one
        /// </summary>
        /// <value>
        ///     The actor.
        /// </value>
        protected internal IActor Actor { protected get; set; }
    }
}