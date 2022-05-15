﻿using Rhisis.Abstractions.Caching;
using Rhisis.Abstractions.Entities;
using Rhisis.Protocol;
using Rhisis.Protocol.Snapshots;
using Rhisis.Protocol.Packets.Client.World;
using Sylver.HandlerInvoker.Attributes;

namespace Rhisis.WorldServer.Handlers
{
    [Handler]
    public class QueryPlayerDataHandler
    {
        private readonly IPlayerCache _playerCache;

        public QueryPlayerDataHandler(IPlayerCache playerCache)
        {
            _playerCache = playerCache;
        }

        [HandlerAction(PacketType.QUERY_PLAYER_DATA)]
        public void OnExecute(IPlayer player, QueryPlayerDataPacket packet)
        {
            var cachedPlayer = _playerCache.Get((int)packet.PlayerId);

            if (cachedPlayer is null)
            {
                if (player.CharacterId != packet.PlayerId)
                {
                    cachedPlayer = _playerCache.Load((int)packet.PlayerId);
                }
            }
            else
            {
                if (cachedPlayer.Version != packet.Version)
                {
                    if (player.CharacterId == packet.PlayerId)
                    {
                        cachedPlayer.Job = player.Job.Id;
                        cachedPlayer.Level = player.Level;
                        cachedPlayer.Version = packet.Version + 1;
                        cachedPlayer.IsOnline = true;
                        cachedPlayer.MessengerStatus = player.Messenger.Status;

                        _playerCache.Set(cachedPlayer);
                    }
                }
            }

            if (cachedPlayer != null)
            {
                using var queryPlayerDataSnapshot = new QueryPlayerDataSnapshot(cachedPlayer);
                player.Send(queryPlayerDataSnapshot);
            }
        }
    }
}
