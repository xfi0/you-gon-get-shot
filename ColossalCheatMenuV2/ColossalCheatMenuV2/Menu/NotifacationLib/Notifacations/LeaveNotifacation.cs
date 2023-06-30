using Colossal.Mods;
using Colossal;
using HarmonyLib;
using Photon.Pun;
using System.Net;
using Photon.Realtime;
using UnityEngine;
using Colossal.Menu;
using System.Collections.Generic;

namespace Colossal.Menu.ClientHub.Notifacation {
    [HarmonyPatch(typeof(MonoBehaviourPunCallbacks), "OnPlayerLeftRoom")]
    internal class LeaveNotifacation {
        private static List<Player> notifiedPlayers = new List<Player>();

        [HarmonyPrefix]
        private static void Postfix(Player otherPlayer) {
            if (!notifiedPlayers.Contains(otherPlayer) && Menu.noti) {
                notifiedPlayers.Add(otherPlayer);
                Notifacations.SendNotification($"<color=cyan>[LEAVE]</color> Name: {otherPlayer.NickName}");
            }
        }
    }
}