﻿namespace Sawnet.Core.Events;

public class DomainEventException : Exception
{
    public DomainEventException(string message)
        : base(message)
    {
    }
}