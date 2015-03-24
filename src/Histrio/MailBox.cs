﻿using System;
using System.Collections.Concurrent;

namespace Histrio
{
    internal sealed class MailBox : IDisposable
    {
        public MailBox(BlockingCollection<IMessage> blockingCollection)
        {
            Messages = blockingCollection;
        }

        public BlockingCollection<IMessage> Messages { get; private set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Add(IMessage message)
        {
            Messages.Add(message);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                Messages.Dispose();
            }
        }
    }
}