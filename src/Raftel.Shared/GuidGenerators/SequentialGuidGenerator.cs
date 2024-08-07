﻿using System.Security.Cryptography;

namespace Raftel.Shared.GuidGenerators;

public static class SequentialGuidGenerator
{
    private static readonly RandomNumberGenerator RandomNumberGenerator = RandomNumberGenerator.Create();

    public static Guid Create()
    {
        var randomBytes = new byte[10];
        RandomNumberGenerator.GetBytes(randomBytes);
        var timestamp = DateTime.UtcNow.Ticks / 10000L;

        var timestampBytes = BitConverter.GetBytes(timestamp);
        if (BitConverter.IsLittleEndian)
        {
            Array.Reverse(timestampBytes);
        }

        var guidBytes = new byte[16];
        Buffer.BlockCopy(randomBytes, 0, guidBytes, 0, 10);
        Buffer.BlockCopy(timestampBytes, 2, guidBytes, 10, 6);

        return new Guid(guidBytes);
    }
}