﻿using Rhisis.Abstractions.Protocol;

namespace Rhisis.Protocol.Packets.Client.World
{
    public class MoverFocusPacket : IPacketDeserializer
    {
        /// <summary>
        /// Gets the player id.
        /// </summary>
        public uint PlayerId { get; private set; }

        /// <inheritdoc />
        public void Deserialize(IFFPacket packet)
        {
            PlayerId = packet.ReadUInt32();
        }
    }
}