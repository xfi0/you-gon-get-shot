using Colossal.Menu;
using Colossal.Menu.ClientHub;
using Colossal.Mods;
using ExitGames.Client.Photon;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ColossalOnevent {
    //[HarmonyPatch(typeof(PhotonNetwork), "RaiseEvent")]
    internal class EventNotifacation {
        [HarmonyPrefix]
        private static void Postfix(byte eventCode, object eventContent, RaiseEventOptions raiseEventOptions, SendOptions sendOptions) {
           if(Menu.noti) {
                Notifacations.SendNotification($"<color=yellow>[EVENT]</color> Code: {eventCode}");
           }
        }
    }
}
