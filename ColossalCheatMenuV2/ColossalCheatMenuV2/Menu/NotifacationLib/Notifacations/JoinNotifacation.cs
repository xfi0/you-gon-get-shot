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
    [HarmonyPatch(typeof(MonoBehaviourPunCallbacks), "OnPlayerEnteredRoom")]
    internal class JoinNotifacation {
        private static List<Player> notifiedPlayers = new List<Player>();

        [HarmonyPrefix]
        private static void Prefix(Player newPlayer) {
            if (!notifiedPlayers.Contains(newPlayer) && Menu.noti) {
                notifiedPlayers.Add(newPlayer);
                Notifacations.SendNotification($"<color=cyan>[JOIN]</color> Name: {newPlayer.NickName}");
            }
        }
    }
}