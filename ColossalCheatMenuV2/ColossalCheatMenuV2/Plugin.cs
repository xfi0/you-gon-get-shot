using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using BepInEx;
using Colossal.Menu;
using Colossal.Mods;
using ExitGames.Client.Photon;
using GorillaLocomotion;
using GorillaNetworking;
using HarmonyLib;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;
using UnityEngine.XR;
using Utilla;
using Valve.Newtonsoft.Json;
using static Photon.Voice.Unity.Recorder;

namespace Colossal
{
    [BepInPlugin("org.ColossusYTTV", "ColossalCheatMenuV2", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private void OnEnable()
        {
            HarmonyLoader.ApplyHarmonyPatches();
        }

        private void OnDisable()
        {
            HarmonyLoader.RemoveHarmonyPatches();
        }

        private List<DynamicClass> dynamicClasses = new List<DynamicClass>();
        private bool inroom = false;
        private bool doonce = false;
        public static Texture2D texture;

        public static int called = 0;
        public static float instantate = 0;

        public static float boxespdestroy = 0;
        public void Awake()
        {
            //Movement Mods
            dynamicClasses.Add(new ExcelFly());
            dynamicClasses.Add(new TFly());
            dynamicClasses.Add(new WallWalk());
            dynamicClasses.Add(new Platforms());
            dynamicClasses.Add(new UpsideDownMonkey());
            dynamicClasses.Add(new FreezeMonkey());
            //Speed
            dynamicClasses.Add(new SpeedMod());

            //Visual Mods
            dynamicClasses.Add(new Chams());
            dynamicClasses.Add(new BoxEsp());
            dynamicClasses.Add(new HollowBoxEsp());

            //Player Mods
            dynamicClasses.Add(new TagGun());
            dynamicClasses.Add(new LegMod());
            dynamicClasses.Add(new CreeperMonkey());
            dynamicClasses.Add(new GhostMonkey());
            dynamicClasses.Add(new InvisMonkey());
            //NoFinger is a harmony patch. This is not needed

            //Other
            dynamicClasses.Add(new BreakNameTags());
            dynamicClasses.Add(new BreakModChecker());
            dynamicClasses.Add(new BreakPunchMod());
            dynamicClasses.Add(new FPSBooster());

            //AntiCrashes
            dynamicClasses.Add(new AntiDestroyPlayerObjects());

            Debug.Log("<color=magenta>Loaded all mods!</color>");
        }
        public interface DynamicClass
        {
            void Update();
        }

        public void Update()
        {
            if(!doonce)
            {
                //Loads the menus start function
                Menu.Menu.LoadOnce();
                Debug.Log("<color=magenta>Loaded menu start functions!</color>");

                //for the credits board
                GameObject.Find("CodeOfConduct").GetComponent<Text>().text = "<color=magenta>COLOSSAL CHEAT MENU V2</color>";
                GameObject.Find("COC Text").GetComponent<Text>().text = $"CREDITS:\n<color=magenta>LARS : MENU TEMPLATE (THANKS AGAIN)</color>\n<color=magenta>COLOSSUS : MENU CREATOR</color>\n<color=yellow>WILL : NO FINGERS</color>\n<color=white>FAULT : LEG MOD</color>";
                Debug.Log("<color=magenta>Loaded COC!</color>");

                doonce = true;
            }

            if (PhotonNetwork.InRoom && !inroom)
            {
                //To update the MOTD live.
                WebClient webClient = new WebClient();
                string motd = webClient.DownloadString(new Uri("https://raw.githubusercontent.com/ColossusYTTV/ColossalCheatMenuV2/main/Files/MOTD.txt?token=GHSAT0AAAAAACCIVNXAUHAUFI7UUTFBU7ZSZCVIN7Q"));
                GameObject.Find("Level/lower level/UI/Tree Room Texts/motdtext").GetComponent<Text>().text = motd;
                webClient.Dispose();

                Debug.Log("<color=magenta>Loaded MOTD!</color>");

                inroom = true;
            }
            if (!PhotonNetwork.InRoom && inroom)
            {
                inroom = false;
            }

            Menu.Menu.Load();

            //Loads all the mods update functions.
            foreach (DynamicClass dynamicClass in dynamicClasses)
            {
                dynamicClass.Update();
            }
        }
        public void FixedUpdate()
        {
            if(PhotonNetwork.InRoom)
            {
                instantate += Time.deltaTime;
            }
            else
            {
                instantate = 0;
                called = 0;
            }
            if (instantate >= 40)
            {
                called = 0;
            }

            if(BoxEsp.boxesp && PhotonNetwork.InRoom)
            {
                boxespdestroy += Time.deltaTime;
            }
        }
    }
}