using System;
using CommandSystem;
using Exiled.API.Features;
using UnityEngine;

namespace Handcuffing
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Handcuff : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);

            if (!Physics.Raycast(player.CameraTransform.position, player.CameraTransform.forward, out var raycastHit,
                    LayerMask.GetMask("Player", "Hitbox")))
            {
                response = "Это нельзя связать!";
                return false;
            }

            if (Player.Get(raycastHit.collider) is not Player pl)
            {
                response = "Это нельзя связать!";
                return false;
            }
            
            if (pl.IsCuffed)
                pl.RemoveHandcuffs();
            else
                pl.Handcuff(player);

            response = pl.IsCuffed ? "Игрок связан успешно" : "Игрок отпущен";
            return false;
        }

        public string Command { get; } = "handcuff";
        public string[] Aliases { get; } = { "cuff", "cf" };
        public string Description { get; } = "Cuffs player ignoring FF settings";
    }
}