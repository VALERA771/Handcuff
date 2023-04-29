using System;
using Exiled.API.Features;

namespace Handcuffing
{
    public class Plugin : Plugin<Config>
    {
        public override string Name { get; } = "Cuffer";
        public override string Prefix { get; } = "cuffer";
        public override string Author { get; } = "VALERA771#1471";
        public override Version Version { get; } = new(1, 0, 0);
        public override Version RequiredExiledVersion { get; } = new(6, 0, 0);
    }
}