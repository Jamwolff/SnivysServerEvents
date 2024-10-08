﻿using SnivysServerEvents.Configs;
using Exiled.API.Features;

namespace SnivysServerEvents.Events
{
    internal class ShortEventHandlers
    {
        private static ShortConfig _config;
        private static bool _seStarted;
        
        public ShortEventHandlers()
        {
            _config = Plugin.Instance.Config.ShortConfig;
            Plugin.ActiveEvent += 1;
            Exiled.Events.Handlers.Player.ChangingRole += Plugin.Instance.eventHandlers.OnRoleSwapSE;
            Start();
        }
        public static void Start()
        {
            _seStarted = true;
            foreach (var player in Player.List)
            {
                player.AddItem(ItemType.KeycardJanitor);
                //To Do:
                //Configurable Adding Item
                //player.AddItem(_config.StartingItem);
                player.Scale = new UnityEngine.Vector3(GetPlayerSize(), GetPlayerSize(), GetPlayerSize());
            }
            Cassie.MessageTranslated(_config.StartEventCassieMessage, _config.StartEventCassieText);
        }

        public static float GetPlayerSize()
        {
            return _config.PlayerSize;
        }
        public static void EndEvent()
        {
            if (_seStarted)
            {
                Cassie.MessageTranslated(_config.EndEventCassieMessage, _config.EndEventCassieText);
                Exiled.Events.Handlers.Player.ChangingRole -= Plugin.Instance.eventHandlers.OnRoleSwapSE;
                _seStarted = false;
            }
        }
    }
}
