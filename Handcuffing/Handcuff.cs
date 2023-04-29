using System;
using System.Collections.Generic;
using CommandSystem;
using Exiled.API.Features;
using InventorySystem;
using InventorySystem.Disarming;
using UnityEngine;
using Utils.Networking;

namespace Handcuffing
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Handcuff : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);

            if (!Physics.Raycast(player.CameraTransform.position, player.CameraTransform.forward, out var raycastHit, 10,
                    LayerMask.GetMask("Hitbox")) || Player.Get(raycastHit.collider) is not Player pl)
            {
                response = "Couldn't find player to cuff";
                return false;
            }
            
            if (pl.IsCuffed)
                pl.RemoveHandcuffs();
            else
            {
                pl.Handcuff();
                pl.DropItems();
            }

            response = pl.IsCuffed ? $"Player {pl.Nickname} has benn cuffed" : $"Player {pl.Nickname} has been released";
            return false;
        }

        public string Command { get; } = "handcuff";
        public string[] Aliases { get; } = { "cuff", "cf" };
        public string Description { get; } = "Cuffs player ignoring FF settings";
    }
}