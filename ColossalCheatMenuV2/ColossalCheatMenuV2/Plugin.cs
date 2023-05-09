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
using Hashtable = ExitGames.Client.Photon.Hashtable;

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
        public static bool fpsbooster = false;
        public static bool creepermonkey = false;
        public static bool ghostmonkey = false;
        public static bool invismonkey = false;
        public static bool legmod = false;
        public static bool nofinger = false;
        public static bool taggun = false;
        public static bool breakmodcheckers = false;
        public static bool breaknametags = false;
        public static bool breakpunchmod = false;

        public static bool isadmin = false;
        public static string version = "1.2";

        public async void Awake()
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    string versiondownload = client.DownloadString("https://pastebin.com/raw/2uU6L7NZ");
                    if (versiondownload != version)
                    {
                        Debug.Log("<color=magenta>Update needed... Downloading</color>");
                        await update();
                    }
                    else
                    {
                        Debug.Log("<color=magenta>Up To Date!</color>");
                    }
                }
                catch (WebException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        public void Update()
        {
            if (!doonce)
            {
                //Loads the menus start function
                Menu.Menu.LoadOnce();
                Debug.Log("<color=magenta>Loaded menu start functions!</color>");

                //for the credits board
                GameObject.Find("CodeOfConduct").GetComponent<Text>().text = "<color=magenta>COLOSSAL CHEAT MENU V2</color>";
                GameObject.Find("COC Text").GetComponent<Text>().text = $"CREDITS:\n<color=magenta>LARS : MENU TEMPLATE (THANKS AGAIN)</color>\n<color=magenta>COLOSSUS : MENU CREATOR</color>\n<color=yellow>WILL : NO FINGERS</color>\n<color=white>FAULT : LEG MOD</color>\n<color=yellow>STARRY : CREEPERMOKNEY (HALF)</color>";
                Debug.Log("<color=magenta>Loaded COC!</color>");

                //just for components
                hud = GameObject.Find("CLIENT_HUB");

                Debug.Log("<color=magenta>Loaded MOTD!</color>");

                doonce = true;
            }
            if (PhotonNetwork.InRoom && !inroom)
            {
                //getting motd
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
        public async Task update()
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    string downloadfilelink = client.DownloadString("https://pastebin.com/raw/SqF7czTS");
                    client.DownloadFile(downloadfilelink, "BepInEx/plugins/ColossalCheatMenuV2.dll");
                }
                catch (WebException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
        private void ModManager()
        {
            if (GorillaTagger.Instance.gameObject.GetComponent<ThisGuyIsUsingColossal>() == null)
                GorillaTagger.Instance.gameObject.AddComponent<ThisGuyIsUsingColossal>();

            if (excelfly)
            {
                if(GorillaTagger.Instance.gameObject.GetComponent<ExcelFly>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<ExcelFly>();
            }

            if (freezemonkey)
            {
                if (GorillaTagger.Instance.gameObject.GetComponent<FreezeMonkey>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<FreezeMonkey>();
            }

            if (platforms)
            {
                if (GorillaTagger.Instance.gameObject.GetComponent<Platforms>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<Platforms>();
            }

            if (mosa)
            {
                if (GorillaTagger.Instance.gameObject.GetComponent<SpeedMod>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<SpeedMod>();
            }

            if (coke)
            {
                if (GorillaTagger.Instance.gameObject.GetComponent<SpeedMod>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<SpeedMod>();
            }

            if (pixi)
            {
                if (GorillaTagger.Instance.gameObject.GetComponent<SpeedMod>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<SpeedMod>();
            }

            if (rgrip85)
            {
                if (GorillaTagger.Instance.gameObject.GetComponent<SpeedMod>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<SpeedMod>();
            }

            if (rgrip95)
            {
                if (GorillaTagger.Instance.gameObject.GetComponent<SpeedMod>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<SpeedMod>();
            }

            if (lgrip85)
            {
                if (GorillaTagger.Instance.gameObject.GetComponent<SpeedMod>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<SpeedMod>();
            }

            if (lgrip95)
            {
                if (GorillaTagger.Instance.gameObject.GetComponent<SpeedMod>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<SpeedMod>();
            }

            if (tfly)
            {
                if (GorillaTagger.Instance.gameObject.GetComponent<TFly>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<TFly>();
            }

            if (upsidedownmonkey)
            {
                if (GorillaTagger.Instance.gameObject.GetComponent<UpsideDownMonkey>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<UpsideDownMonkey>();
            }

            if (wallwalk)
            {
                if (GorillaTagger.Instance.gameObject.GetComponent<WallWalk>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<WallWalk>();
            }

            if (chams)
            {
                if (GorillaTagger.Instance.gameObject.GetComponent<Chams>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<Chams>();
            }

            if (boxesp)
            {
                if (GorillaTagger.Instance.gameObject.GetComponent<BoxEsp>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<BoxEsp>();
            }

            if (hollowboxesp)
            {
                if (GorillaTagger.Instance.gameObject.GetComponent<HollowBoxEsp>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<HollowBoxEsp>();
            }

            if (creepermonkey)
            {
                if (GorillaTagger.Instance.gameObject.GetComponent<CreeperMonkey>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<CreeperMonkey>();
            }

            if (ghostmonkey)
            {
                if (GorillaTagger.Instance.gameObject.GetComponent<GhostMonkey>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<GhostMonkey>();
            }

            if (invismonkey)
            {
                if (GorillaTagger.Instance.gameObject.GetComponent<InvisMonkey>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<InvisMonkey>();
            }

            if (legmod)
            {
                if (GorillaTagger.Instance.gameObject.GetComponent<LegMod>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<LegMod>();
            }

            if (taggun)
            {
                if (GorillaTagger.Instance.gameObject.GetComponent<TagGun>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<TagGun>();
            }

            if (breakmodcheckers)
            {
                if (GorillaTagger.Instance.gameObject.GetComponent<BreakModChecker>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<BreakModChecker>();
            }

            if (breaknametags)
            {
                if (GorillaTagger.Instance.gameObject.GetComponent<BreakNameTags>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<BreakNameTags>();
            }

            if (breakpunchmod)
            {
                if (GorillaTagger.Instance.gameObject.GetComponent<BreakPunchMod>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<BreakPunchMod>();
            }

            if (fpsbooster)
            {
                if (GorillaTagger.Instance.gameObject.GetComponent<FPSBooster>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<FPSBooster>();
            }
        }
    }
}