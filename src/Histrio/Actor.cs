using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Histrio
{
    internal class Actor : IActor
    {
        private Behavior _behavior;

        private Actor(Behavior behavior, Address address, MailBox mailBox, Theater theater)
        {
            _behavior = behavior;
            Address = address;
            Theater = theater;
            _behavior.Actor = this;
            new TaskFactory(TaskCreationOptions.LongRunning, TaskContinuationOptions.None)
                .StartNew(() =>
                {
                    var messages = mailBox.Messages.GetConsumingEnumerable();
                    foreach (var message in messages)
                    {
                        message.GetHandledBy(_behavior);
                    }
                });
        }

        private Theater Theater { get; set; }

        public void Send<T>(Message<T> message)
        {
            Theater.Dispatch(message);
        }

        public void Send<T>(T messageContent, Address to)
        {
            Theater.Dispatch(messageContent.AsMessage(), to);
        }

        public void Send<T>(T messageContent, string actorName)
        {
            Theater.Dispatch(messageContent.AsMessage(), new Address(actorName));
        }

        public void Become(Address address)
        {
            _behavior = new SendBehavior(address) {Actor = this};
        }

        public Address Create(Behavior behavior)
        {
            return Theater.CreateActor(behavior);
        }

        public Address Address { get; private set; }

        public static Address Create(Behavior behavior, string name, MailBox mailBox, Theater theater)
        {
            var address = new Address(name);
            new Actor(behavior, address, mailBox, theater);
            return address;
        }
    }
}