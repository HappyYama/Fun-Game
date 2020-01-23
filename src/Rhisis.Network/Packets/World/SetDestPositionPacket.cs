﻿using Sylver.Network.Data;
using System;

namespace Rhisis.Network.Packets.World
{
    /// <summary>
    /// Defines the <see cref="SetDestPositionPacket"/> packet structure.
    /// </summary>
    public class SetDestPositionPacket : IPacketDeserializer
    {
        /// <summary>
        /// Gets the X coordinate.
        /// </summary>
        public float X { get; private set; }

        /// <summary>
        /// Gets the Y coordinate.
        /// </summary>
        public float Y { get; private set; }

        /// <summary>
        /// Gets the Z coordinate.
        /// </summary>
        public float Z { get; private set; }

        /// <summary>
        /// Gets the forward state.
        /// </summary>
        public bool Forward { get; private set; }

        /// <inheritdoc />
        public void Deserialize(INetPacketStream packet)
        {
            X = packet.Read<float>();
            Y = packet.Read<float>();
            Z = packet.Read<float>();
            Forward = Convert.ToBoolean(packet.Read<byte>());
        }
    }
}
