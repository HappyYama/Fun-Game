using Rhisis.Game.Common;
using Rhisis.Abstractions.Features.Chat;
using Rhisis.Abstractions.Entities;
using System;

namespace Rhisis.WorldServer.Game.Chat
{
    [ChatCommand("/aroundkill", AuthorityType.GameMaster)]
    [ChatCommand("/ak", AuthorityType.GameMaster)]
    public class AroundKillChatCommand : IChatCommand
    {
        public void Execute(IPlayer player, object[] parameters)
        {
            throw new NotImplementedException();
            //ObjectMessageType defaultAttackType = ObjectMessageType.OBJMSG_ATK1;
            //var defaultAttackSpeed = 1.0f;

            //for (var i = 0; i < player.Object.Entities.Count; i++)
            //{
            //    if (player.Object.Entities[i] is IMonster monsterEntity)
            //    {
            //        if (!monsterEntity.Follow.IsFollowing)
            //        {
            //            _followSystem.Follow(monsterEntity, player);
            //        }
            //        _battleSystem.MeleeAttack(player, monsterEntity, defaultAttackType, defaultAttackSpeed);
            //    }
            //}
        }
    }
}