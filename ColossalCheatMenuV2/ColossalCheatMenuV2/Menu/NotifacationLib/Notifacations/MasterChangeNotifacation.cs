using Colossal;
using Colossal.Mods;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Colossal.Menu.ClientHub.Notifacation {
    [HarmonyPatch(typeof(MonoBehaviourPunCallbacks), "OnMasterClientSwitched")]
    internal class MasterChangeNotifacation {
        private static List<Player> notifiedPlayers = new List<Player>();
        [HarmonyPrefix]
        private static void Postfix(Player newMasterClient) {
            if (!notifiedPlayers.Contains(newMasterClient) && Menu.noti) {
                notifiedPlayers.Add(newMasterClient);
                Notifacations.SendNotification($"<color=greem>[MASTER]</color> Changed, Name: {newMasterClient.NickName}");
                if (Plugin.mastertimer <= 20) {
                    notifiedPlayers.Remove(newMasterClient);
                }
            }
        }
    }
}
