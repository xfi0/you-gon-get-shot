using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using BepInEx;
using BoingKit;
using Colossal.Menu;
using Colossal.Menu.ClientHub;
using Colossal.Menu.ClientHub.Notifacation;
using Colossal.Mods;
using Colossal.Patches;
using GorillaLocomotion;
using GorillaLocomotion.Swimming;
using GorillaNetworking;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;
using UnityEngine.XR;

namespace Colossal {
    [BepInPlugin("org.ColossusYTTV.ColossalCheatMenuV2", "ColossalCheatMenuV2", "1.0.0")]
    public class Loader : BaseUnityPlugin {
        private void OnEnable() {
            HarmonyLoader.ApplyHarmonyPatches();
        }

        private void OnDisable() {
            HarmonyLoader.RemoveHarmonyPatches();
        }

        public async void Awake() {
            using (WebClient client = new WebClient()) {
                try {
                    string versiondownload = client.DownloadString("https://pastebin.com/raw/2uU6L7NZ");
                    if (versiondownload != Plugin.version) {
                        CustomConsole.LogToConsole("Update needed... Downloading");
                        await Plugin.update();
                    } else {
                        CustomConsole.LogToConsole("Up To Date!");
                    }
                } catch (WebException ex) {
                    CustomConsole.LogToConsole("Error: " + ex.Message);
                }
            }

            System.Random random = new System.Random();
            int randomNumber = random.Next(1, 51);
            if (randomNumber == 1) {
                Plugin.sussy = true;
            }
        }

        private void Start() {
            GameObject bepinexbypass = new GameObject();
            if(bepinexbypass != null) {
                bepinexbypass.name = "Bepinex Bypass";
                if(!bepinexbypass.GetComponent<Plugin>()) {
                    bepinexbypass.AddComponent<Plugin>();
                }
            }
        }
    }
}