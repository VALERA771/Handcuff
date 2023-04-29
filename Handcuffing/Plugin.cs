using System;
using Exiled.API.Features;
using Exiled.API.Interfaces;
using Exiled.Events.EventArgs.Player;
using Player = Exiled.Events.Handlers.Player;

namespace Handcuffing
{
    public class Plugin : Plugin<Plugin.Config>
    {
        public override string Name { get; } = "Cuffer";
        public override string Prefix { get; } = "cuffer";
        public override string Author { get; } = "VALERA771#1471";
        public override Version Version { get; } = new(1, 0, 1);
        public override Version RequiredExiledVersion { get; } = new(6, 0, 0);
        
        public sealed class Config : IConfig
        {
            public bool IsEnabled { get; set; } = true;
            public bool Debug { get; set; } = false;
        }
    }
}