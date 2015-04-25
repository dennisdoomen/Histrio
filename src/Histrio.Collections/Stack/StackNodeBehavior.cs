using System;

namespace Histrio.Collections.Stack
{
    /// <summary>
    ///     A behavior implementing a strongly type stack
    /// </summary>
    /// <typeparam name="T">The type of the value stored into a stack node</typeparam>
    public class StackNodeBehavior<T> : Behavior, IObserver<Push<T>>, IObserver<Pop>
    {
        private readonly T _content;
        private readonly Address _link;

        /// <summary>
        ///     Initializes a new instance of the <see cref="StackNodeBehavior{T}" /> class.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="link">The link.</param>
        public StackNodeBehavior(T content, Address link)
        {
            _content = content;
            _link = link;
        }

        /// <summary>
        ///     Accepts the specified message. OnNext is Actor Model terminology for "I can do something with this message"
        /// </summary>
        /// <param name="message">The message.</param>
        public void OnNext(Pop message)
        {
            Actor.Become(_link);
            Actor.Send(_content, message.Customer);
        }

        void IObserver<Pop>.OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        void IObserver<Pop>.OnCompleted()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Accepts the specified message. OnNext is Actor Model terminology for "I can do something with this message"
        /// </summary>
        /// <param name="message">The message.</param>
        public void OnNext(Push<T> message)
        {
            var p = Actor.Create(new StackNodeBehavior<T>(_content, _link));
            var stackNodeBehavior = new StackNodeBehavior<T>(message.Value, p);
            var stackNode = Actor.Create(stackNodeBehavior);
            Actor.Become(stackNode);
        }

        void IObserver<Push<T>>.OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        void IObserver<Push<T>>.OnCompleted()
        {
            throw new NotImplementedException();
        }
    }
}