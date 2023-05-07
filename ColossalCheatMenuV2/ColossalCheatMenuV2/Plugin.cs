using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
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
using Valve.VR;
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
        private bool inroom = false;
        private bool doonce = false;

        public static Texture2D texture;

        public static int called = 0;
        public static float instantate = 0;

        public static GameObject hud;

        public static bool excelfly = false;
        public static bool freezemonkey = false;
        public static bool platforms = false;
        public static bool mosa = false;
        public static bool coke = false;
        public static bool pixi = false;
        public static bool rgrip85 = false;
        public static bool rgrip95 = false;
        public static bool lgrip85 = false;
        public static bool lgrip95 = false;
        public static bool tfly = false;
        public static bool upsidedownmonkey = false;
        public static bool wallwalk = false;
        public static bool boxesp = false;
        public static bool chams = false;
        public static bool hollowboxesp = false;
        public static bool creepermonkey = false;
        public static bool ghostmonkey = false;
        public static bool invismonkey = false;
        public static bool legmod = false;
        public static bool nofinger = false;
        public static bool taggun = false;
        public static bool breakmodcheckers = false;
        public static bool breaknametags = false;
        public static bool breakpunchmod = false;
        public static bool fpsbooster = false;

        public void Update()
        {
            if (!doonce)
            {
                //Loads the menus start function
                Menu.Menu.LoadOnce();
                Debug.Log("<color=magenta>Loaded menu start functions!</color>");

                //for the credits board
                GameObject.Find("CodeOfConduct").GetComponent<Text>().text = "<color=magenta>COLOSSAL CHEAT MENU V2</color>";
                GameObject.Find("COC Text").GetComponent<Text>().text = $"CREDITS:\n<color=magenta>LARS : MENU TEMPLATE (THANKS AGAIN)</color>\n<color=magenta>COLOSSUS : MENU CREATOR</color>\n<color=yellow>WILL : NO FINGERS</color>\n<color=white>FAULT : LEG MOD\n<color=yellow>STARRY : CREEPERMOKNEY (HALF)</color>";
                Debug.Log("<color=magenta>Loaded COC!</color>");

                hud = GameObject.Find("CLIENT_HUB");

                doonce = true;
            }
            if (PhotonNetwork.InRoom && !inroom)
            {
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        string rawData = client.DownloadString("https://pastebin.com/raw/bhLzrd4F");
                        Console.WriteLine($"\n<color=magenta>{rawData}</color>\n");
                        GameObject.Find("Level/lower level/UI/Tree Room Texts/motdtext").GetComponent<Text>().text = rawData;
                    }
                    catch (WebException ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
                Debug.Log("<color=magenta>Loaded MOTD!</color>");

                inroom = true;
            }
            if (!PhotonNetwork.InRoom && inroom)
            {
                inroom = false;
            }

            Menu.Menu.Load();
            ModManager();
        }
        public void FixedUpdate()
        {
            if (PhotonNetwork.InRoom)
            {
                instantate += Time.deltaTime;
            }
            else
            {
                instantate = 0;
                called = 0;
            }
            if (instantate >= 120)
            {
                called = 0;
            }
        }
        private void ModManager()
        {
            if(excelfly)
            {
                if(hud.GetComponent<ExcelFly>() == null)
                    hud.AddComponent<ExcelFly>();
            }

            if (freezemonkey)
            {
                if (hud.GetComponent<FreezeMonkey>() == null)
                    hud.AddComponent<FreezeMonkey>();
            }

            if (platforms)
            {
                if (hud.GetComponent<Platforms>() == null)
                    hud.AddComponent<Platforms>();
            }

            if (mosa)
            {
                if (hud.GetComponent<SpeedMod>() == null)
                    hud.AddComponent<SpeedMod>();
            }

            if (coke)
            {
                if (hud.GetComponent<SpeedMod>() == null)
                    hud.AddComponent<SpeedMod>();
            }

            if (pixi)
            {
                if (hud.GetComponent<SpeedMod>() == null)
                    hud.AddComponent<SpeedMod>();
            }

            if (rgrip85)
            {
                if (hud.GetComponent<SpeedMod>() == null)
                    hud.AddComponent<SpeedMod>();
            }

            if (rgrip95)
            {
                if (hud.GetComponent<SpeedMod>() == null)
                    hud.AddComponent<SpeedMod>();
            }

            if (lgrip85)
            {
                if (hud.GetComponent<SpeedMod>() == null)
                    hud.AddComponent<SpeedMod>();
            }

            if (lgrip95)
            {
                if (hud.GetComponent<SpeedMod>() == null)
                    hud.AddComponent<SpeedMod>();
            }

            if (tfly)
            {
                if (hud.GetComponent<TFly>() == null)
                    hud.AddComponent<TFly>();
            }

            if (upsidedownmonkey)
            {
                if (hud.GetComponent<UpsideDownMonkey>() == null)
                    hud.AddComponent<UpsideDownMonkey>();
            }

            if (wallwalk)
            {
                if (hud.GetComponent<WallWalk>() == null)
                    hud.AddComponent<WallWalk>();
            }

            if (chams)
            {
                if (hud.GetComponent<Chams>() == null)
                    hud.AddComponent<Chams>();
            }

            if (boxesp)
            {
                if (hud.GetComponent<BoxEsp>() == null)
                    hud.AddComponent<BoxEsp>();
            }

            if (hollowboxesp)
            {
                if (hud.GetComponent<HollowBoxEsp>() == null)
                    hud.AddComponent<HollowBoxEsp>();
            }

            if (creepermonkey)
            {
                if (hud.GetComponent<CreeperMonkey>() == null)
                    hud.AddComponent<CreeperMonkey>();
            }

            if (ghostmonkey)
            {
                if (hud.GetComponent<GhostMonkey>() == null)
                    hud.AddComponent<GhostMonkey>();
            }

            if (invismonkey)
            {
                if (hud.GetComponent<InvisMonkey>() == null)
                    hud.AddComponent<InvisMonkey>();
            }

            if (legmod)
            {
                if (hud.GetComponent<LegMod>() == null)
                    hud.AddComponent<LegMod>();
            }

            if (taggun)
            {
                if (hud.GetComponent<TagGun>() == null)
                    hud.AddComponent<TagGun>();
            }

            if (breakmodcheckers)
            {
                if (hud.GetComponent<BreakModChecker>() == null)
                    hud.AddComponent<BreakModChecker>();
            }

            if (breaknametags)
            {
                if (hud.GetComponent<BreakNameTags>() == null)
                    hud.AddComponent<BreakNameTags>();
            }

            if (breakpunchmod)
            {
                if (hud.GetComponent<BreakPunchMod>() == null)
                    hud.AddComponent<BreakPunchMod>();
            }

            if (fpsbooster)
            {
                if (hud.GetComponent<FPSBooster>() == null)
                    hud.AddComponent<FPSBooster>();
            }
        }
    }
}