﻿using Rhisis.Abstractions.Protocol;

namespace Rhisis.Protocol.Packets.Client.World
{
    public class RemoveInventoryItemPacket : IPacketDeserializer
    {
        /// <summary>
        /// Gets the item index in the inventory.
        /// </summary>
        public int ItemIndex { get; private set; }

        /// <summary>
        /// Gets the item quantity.
        /// </summary>
        public int Quantity { get; private set; }

        /// <summary>
        /// Creates a new <see cref="RemoveInventoryItemPacket"/> object.
        /// </summary>
        /// <param name="packet">Incoming packet</param>
        public void Deserialize(IFFPacket packet)
        {
            ItemIndex = packet.ReadInt32();
            Quantity = packet.ReadInt32();
        }
    }
}