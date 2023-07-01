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
    //[BepInPlugin("org.ColossusYTTV.ColossalCheatMenuV2", "ColossalCheatMenuV2", "1.0.0")]
    public class Plugin : MonoBehaviour {
        /*private void OnEnable() {
            HarmonyLoader.ApplyHarmonyPatches();
        }

        private void OnDisable() {
            HarmonyLoader.RemoveHarmonyPatches();
        }*/
        private bool inroom = false;
        private bool doonce = false;

        public static Texture2D texture;
        public static Material boardmat;

        public static int called = 0;
        public static float instantate = 0;
        private float rainbowtext = 0f;
        private float deltaTime = 0.0f;
        public static float reporttimer = 0;
        public static float mastertimer = 0;

        private static string textcolour = "magenta";

        public static GameObject hud;

        public static bool excelfly = false;
        public static bool wateryair = false;
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
        public static bool colossalsettingswallwalk = false;
        public static bool ghostwallwalk = false;
        public static bool blatantwallwalk = false;
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
        public static bool whyiseveryonelookingatme = false;
        public static bool pccheckbypass = false;
        public static bool longarms = false;
        public static bool tagauracolossal = false;
        public static bool tagauraghost = false;
        public static bool tagaurablatant = false;
        public static bool tagall = false;
        public static bool anticrash = false;

        public static string version = "3.4";
        public static bool sussy = false;
        public static PhotonView GetPhotonViewFromVR(GameObject vrRig) {
            MethodInfo getViewListMethod = AccessTools.Method(typeof(PhotonNetwork), "GetPhotonViewList");

            List<PhotonView> photonViews = (List<PhotonView>)getViewListMethod.Invoke(null, null);

            foreach (PhotonView photonView in photonViews) {
                Photon.Realtime.Player owner = (Photon.Realtime.Player)AccessTools.Field(typeof(PhotonView), "ownershipTransfer").GetValue(photonView);

                if (owner != null && owner.TagObject == vrRig) {
                    return photonView;
                }
            }

            return null;
        }
        
        public void Update() {
            if (!doonce) {
                HarmonyLoader.ApplyHarmonyPatchesOnEvent();

                //Loads the menus start function
                Menu.Menu.LoadOnce();
                CustomConsole.LogToConsole("Loaded menu start functions!");

                //Colours
                boardmat = new Material(Shader.Find("Standard"));
                boardmat.color = new Color(0.6f, 0, 0.80f);

                if (GameObject.Find("Level").transform.Find("lower level").gameObject.activeSelf) {
                    GameObject.Find("Level/lower level/StaticUnlit/motdscreen").GetComponent<Renderer>().material = boardmat;
                    GameObject.Find("Level/lower level/StaticUnlit/screen").GetComponent<Renderer>().material = boardmat;

                    GameObject.Find("Level/lower level/Wall Monitors Screens/wallmonitorforest").GetComponent<Renderer>().material = boardmat;
                    GameObject.Find("Level/lower level/Wall Monitors Screens/wallmonitorcave").GetComponent<Renderer>().material = boardmat;
                    GameObject.Find("Level/lower level/Wall Monitors Screens/wallmonitorskyjungle").GetComponent<Renderer>().material = boardmat;
                    GameObject.Find("Level/lower level/Wall Monitors Screens/wallmonitorcosmetics").GetComponent<Renderer>().material = boardmat;
                    GameObject.Find("Level/lower level/Wall Monitors Screens/wallmonitorcanyon").GetComponent<Renderer>().material = boardmat;

                    GameObject.Find("Level/forest/ForestObjects/campgroundstructure/scoreboard/REMOVE board").GetComponent<MeshRenderer>().material = boardmat;

                    GameObject.Find("Level/lower level/UI/-- PhysicalComputer UI --/monitor").GetComponent<Renderer>().material = boardmat;

                    GameObject.Find("Level/lower level/UI/motd/motdtext").GetComponent<Text>().color = Color.cyan;
                    GameObject.Find("Level/lower level/UI/motd").GetComponent<Text>().color = Color.cyan;
                    GameObject.Find("Level/lower level/UI/motd").GetComponent<Text>().text = "UPDATES";
                    GameObject.Find("Level/lower level/UI/Tree Room Texts/WallScreenForest").GetComponent<Text>().color = Color.cyan;
                    GameObject.Find("Level/lower level/UI/Tree Room Texts/WallScreenCave").GetComponent<Text>().color = Color.cyan;
                    GameObject.Find("Level/lower level/UI/Tree Room Texts/WallScreenCity Front").GetComponent<Text>().color = Color.cyan;
                    GameObject.Find("Level/lower level/UI/Tree Room Texts/WallScreenCanyon").GetComponent<Text>().color = Color.cyan;
                    CustomConsole.LogToConsole("Loaded Colours!");
                }

                //just for components
                hud = GameObject.Find("CLIENT_HUB");

                doonce = true;
            }
            if (PhotonNetwork.InRoom && !inroom) {
                if (GameObject.Find("Level").transform.Find("lower level").gameObject.activeSelf) {
                    //getting motd
                    using (WebClient client = new WebClient()) {
                        try {
                            string rawData = client.DownloadString("https://pastebin.com/raw/bhLzrd4F");
                            GameObject.Find("Level/lower level/UI/motd/motdtext").GetComponent<Text>().text = rawData;
                        } catch (WebException ex) {
                            CustomConsole.LogToConsole("Error: " + ex.Message);
                        }
                    }
                    CustomConsole.LogToConsole("\nLoaded MOTD!");

                    GameObject.Find("Level/lower level/Wall Monitors Screens/wallmonitorforest").GetComponent<Renderer>().material = boardmat;
                    GameObject.Find("Level/lower level/Wall Monitors Screens/wallmonitorcave").GetComponent<Renderer>().material = boardmat;
                    GameObject.Find("Level/lower level/Wall Monitors Screens/wallmonitorskyjungle").GetComponent<Renderer>().material = boardmat;
                    GameObject.Find("Level/lower level/Wall Monitors Screens/wallmonitorcosmetics").GetComponent<Renderer>().material = boardmat;
                    GameObject.Find("Level/lower level/Wall Monitors Screens/wallmonitorcanyon").GetComponent<Renderer>().material = boardmat;

                    GameObject.Find("Level/lower level/UI/Tree Room Texts/WallScreenForest").GetComponent<Text>().text = $"<Colossal Cheat Menu V2>\nPhoton Name: {PhotonNetwork.LocalPlayer.NickName}\nUserID: {PhotonNetwork.LocalPlayer.UserId}\nRoom Name: {PhotonNetwork.CurrentRoom.Name}   Players: {PhotonNetwork.CurrentRoom.PlayerCount}\nMaster: {PhotonNetwork.MasterClient.NickName}   Public: {PhotonNetwork.CurrentRoom.IsVisible}";
                    GameObject.Find("Level/lower level/UI/Tree Room Texts/WallScreenCave").GetComponent<Text>().text = $"<Colossal Cheat Menu V2>\nPhoton Name: {PhotonNetwork.LocalPlayer.NickName}\nUserID: {PhotonNetwork.LocalPlayer.UserId}\nRoom Name: {PhotonNetwork.CurrentRoom.Name}   Players: {PhotonNetwork.CurrentRoom.PlayerCount}\nMaster: {PhotonNetwork.MasterClient.NickName}   Public: {PhotonNetwork.CurrentRoom.IsVisible}";
                    GameObject.Find("Level/lower level/UI/Tree Room Texts/WallScreenCity Front").GetComponent<Text>().text = $"<Colossal Cheat Menu V2>\nPhoton Name: {PhotonNetwork.LocalPlayer.NickName}\nUserID: {PhotonNetwork.LocalPlayer.UserId}\nRoom Name: {PhotonNetwork.CurrentRoom.Name}   Players: {PhotonNetwork.CurrentRoom.PlayerCount}\nMaster: {PhotonNetwork.MasterClient.NickName}   Public: {PhotonNetwork.CurrentRoom.IsVisible}";
                    GameObject.Find("Level/lower level/UI/Tree Room Texts/WallScreenCanyon").GetComponent<Text>().text = $"<Colossal Cheat Menu V2>\nPhoton Name: {PhotonNetwork.LocalPlayer.NickName}\nUserID: {PhotonNetwork.LocalPlayer.UserId}\nRoom Name: {PhotonNetwork.CurrentRoom.Name}   Players: {PhotonNetwork.CurrentRoom.PlayerCount}\nMaster: {PhotonNetwork.MasterClient.NickName}   Public: {PhotonNetwork.CurrentRoom.IsVisible}";

                    GameObject.Find("Global/GorillaUI/ForestScoreboardAnchor/GorillaScoreBoard(Clone)/Board Text").GetComponent<Text>().color = Color.cyan;
                    CustomConsole.LogToConsole("Loaded Colours And Info!\n");
                }
                inroom = true;
            }
            if (!PhotonNetwork.InRoom && inroom) {
                inroom = false;
            }
            deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;

            Menu.Menu.Load();
            ModManager();

        }
        public void FixedUpdate() {
            if(PhotonNetwork.InRoom) {
                reporttimer += Time.deltaTime;
                if(reporttimer >= 20) {
                    reporttimer = 0;
                }
            }
            if (PhotonNetwork.InRoom) {
                mastertimer += Time.deltaTime;
                if (mastertimer >= 20) {
                    mastertimer = 0;
                }
            }
            if (PhotonNetwork.InRoom) {
                instantate += Time.deltaTime;
            } else {
                instantate = 0;
                called = 0;
            }
            if (instantate >= 120) {
                called = 0;
            }
            if (Menu.Menu.MenuRGB) {
                Menu.Menu.menurgb += Time.deltaTime;
            } else {
                if (Menu.Menu.menurgb != 0) {
                    Menu.Menu.menurgb = 0;
                }
            }
            if (GameObject.Find("Level").transform.Find("lower level").gameObject.activeSelf) {
                rainbowtext += Time.deltaTime;
                if (rainbowtext >= 0.1f) {
                    textcolour = "magenta";
                    GameObject.Find("CodeOfConduct").GetComponent<Text>().text = $"<color={textcolour}>COLOSSAL CHEAT MENU V2</color>";
                    GameObject.Find("COC Text").GetComponent<Text>().text = $"<color=cyan>Thank you for using CCMV2, the successor to the</color><color={textcolour}> first cheat menu!</color><color=cyan> CCMV2 will be getting frequently updated with new features/FUD. \n\nContributors:\n</color><color={textcolour}>ColossusYTTV: Menu Maker/Mod Creator\nLars/LHAX: Menu Base</color><color=cyan>\nWM: No Fingers\nStarry: Creeper Monke/Tester\nAntic: Tester\nCunzaki/Plinko: Tester\nKman: BepinexPatch\n\nCurrent Menu Version: {version}</color>";
                }
                if (rainbowtext >= 0.2f) {
                    textcolour = "red";
                    GameObject.Find("CodeOfConduct").GetComponent<Text>().text = $"<color={textcolour}>COLOSSAL CHEAT MENU V2</color>";
                    GameObject.Find("COC Text").GetComponent<Text>().text = $"<color=cyan>Thank you for using CCMV2, the successor to the</color><color={textcolour}> first cheat menu!</color><color=cyan> CCMV2 will be getting frequently updated with new features/FUD. \n\nContributors:\n</color><color={textcolour}>ColossusYTTV: Menu Maker/Mod Creator\nLars/LHAX: Menu Base</color><color=cyan>\nWM: No Fingers\nStarry: Creeper Monke/Tester\nAntic: Tester\nCunzaki/Plinko: Tester\nKman: BepinexPatch\n\nCurrent Menu Version: {version}</color>";
                }
                if (rainbowtext >= 0.3f) {
                    textcolour = "green";
                    GameObject.Find("CodeOfConduct").GetComponent<Text>().text = $"<color={textcolour}>COLOSSAL CHEAT MENU V2</color>";
                    GameObject.Find("COC Text").GetComponent<Text>().text = $"<color=cyan>Thank you for using CCMV2, the successor to the</color><color={textcolour}> first cheat menu!</color><color=cyan> CCMV2 will be getting frequently updated with new features/FUD. \n\nContributors:\n</color><color={textcolour}>ColossusYTTV: Menu Maker/Mod Creator\nLars/LHAX: Menu Base</color><color=cyan>\nWM: No Fingers\nStarry: Creeper Monke/Tester\nAntic: Tester\nCunzaki/Plinko: Tester\nKman: BepinexPatch\n\nCurrent Menu Version: {version}</color>";
                }
                if (rainbowtext >= 0.4f) {
                    textcolour = "blue";
                    GameObject.Find("CodeOfConduct").GetComponent<Text>().text = $"<color={textcolour}>COLOSSAL CHEAT MENU V2</color>";
                    GameObject.Find("COC Text").GetComponent<Text>().text = $"<color=cyan>Thank you for using CCMV2, the successor to the</color><color={textcolour}> first cheat menu!</color><color=cyan> CCMV2 will be getting frequently updated with new features/FUD. \n\nContributors:\n</color><color={textcolour}>ColossusYTTV: Menu Maker/Mod Creator\nLars/LHAX: Menu Base</color><color=cyan>\nWM: No Fingers\nStarry: Creeper Monke/Tester\nAntic: Tester\nCunzaki/Plinko: Tester\nKman: BepinexPatch\n\nCurrent Menu Version: {version}</color>";
                }
                if (rainbowtext >= 0.5f) {
                    textcolour = "cyan";
                    GameObject.Find("CodeOfConduct").GetComponent<Text>().text = $"<color={textcolour}>COLOSSAL CHEAT MENU V2</color>";
                    GameObject.Find("COC Text").GetComponent<Text>().text = $"<color=cyan>Thank you for using CCMV2, the successor to the</color><color={textcolour}> first cheat menu!</color><color=cyan> CCMV2 will be getting frequently updated with new features/FUD. \n\nContributors:\n</color><color={textcolour}>ColossusYTTV: Menu Maker/Mod Creator\nLars/LHAX: Menu Base</color><color=cyan>\nWM: No Fingers\nStarry: Creeper Monke/Tester\nAntic: Tester\nCunzaki/Plinko: Tester\nKman: BepinexPatch\n\nCurrent Menu Version: {version}</color>";
                }
                if (rainbowtext >= 0.6f) {
                    textcolour = "yellow";
                    GameObject.Find("CodeOfConduct").GetComponent<Text>().text = $"<color={textcolour}>COLOSSAL CHEAT MENU V2</color>";
                    GameObject.Find("COC Text").GetComponent<Text>().text = $"<color=cyan>Thank you for using CCMV2, the successor to the</color><color={textcolour}> first cheat menu!</color><color=cyan> CCMV2 will be getting frequently updated with new features/FUD. \n\nContributors:\n</color><color={textcolour}>ColossusYTTV: Menu Maker/Mod Creator\nLars/LHAX: Menu Base</color><color=cyan>\nWM: No Fingers\nStarry: Creeper Monke/Tester\nAntic: Tester\nCunzaki/Plinko: Tester\nKman: BepinexPatch\n\nCurrent Menu Version: {version}</color>";
                }
                if (rainbowtext >= 0.6f) {
                    rainbowtext = 0;
                }
            }
        }
        public static async Task update() {
            using (WebClient client = new WebClient()) {
                try {
                    string downloadfilelink = client.DownloadString("https://pastebin.com/raw/SqF7czTS");
                    client.DownloadFile(downloadfilelink, "BepInEx/plugins/ColossalCheatMenuV2.dll");
                } catch (WebException ex) {
                    CustomConsole.LogToConsole("Error: " + ex.Message);
                }
            }
        }
        bool title = false;
        private void ModManager() {
            /*if (GorillaTagger.Instance.gameObject.GetComponent<ThisGuyIsUsingColossal>() == null)
                GorillaTagger.Instance.gameObject.AddComponent<ThisGuyIsUsingColossal>();*/

            if (GorillaTagger.Instance.gameObject.GetComponent<CustomConsole>() == null)
                GorillaTagger.Instance.gameObject.AddComponent<CustomConsole>();
            if (GorillaTagger.Instance.gameObject.GetComponent<CustomConsole>() && !title) {
                CustomConsole.LogToConsole(
                @"
                _________  ________  .____    ________    _________ _________   _____  .____     
                \_   ___ \ \_____  \ |    |   \_____  \  /   _____//   _____/  /  _  \ |    |    
                /    \  \/  /   |   \|    |    /   |   \ \_____  \ \_____  \  /  /_\  \|    |    
                \     \____/    |    \    |___/    |    \/        \/        \/    |    \    |___ 
                 \______  /\_______  /_______ \_______  /_______  /_______  /\____|__  /_______ \
                        \/         \/        \/       \/        \/        \/         \/        \/
                                Trolling lemming harder since July, 19th. 2022
                ");
                title = true;
            }

            /*if (tagall) {
                if (GorillaTagger.Instance.gameObject.GetComponent<TagAll>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<TagAll>();
            }*/

            if (tagauracolossal) {
                if (GorillaTagger.Instance.gameObject.GetComponent<TagAura>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<TagAura>();
            }

            if (tagauraghost) {
                if (GorillaTagger.Instance.gameObject.GetComponent<TagAura>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<TagAura>();
            }

            if (tagaurablatant) {
                if (GorillaTagger.Instance.gameObject.GetComponent<TagAura>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<TagAura>();
            }

            if (longarms) {
                if (GorillaTagger.Instance.gameObject.GetComponent<LongArm>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<LongArm>();
            }

            if (whyiseveryonelookingatme) {
                if (GorillaTagger.Instance.gameObject.GetComponent<WhyIsEveryoneLookingAtMe>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<WhyIsEveryoneLookingAtMe>();
            }

            if (excelfly) {
                if (GorillaTagger.Instance.gameObject.GetComponent<ExcelFly>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<ExcelFly>();
            }

            if (wateryair) {
                if (GorillaTagger.Instance.gameObject.GetComponent<WateryAir>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<WateryAir>();
            }

            /*if (freezemonkey) {
                if (GorillaTagger.Instance.gameObject.GetComponent<FreezeMonkey>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<FreezeMonkey>();
            }*/

            if (platforms) {
                if (GorillaTagger.Instance.gameObject.GetComponent<Platforms>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<Platforms>();
            }

            if (mosa) {
                if (GorillaTagger.Instance.gameObject.GetComponent<SpeedMod>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<SpeedMod>();
            }

            if (coke) {
                if (GorillaTagger.Instance.gameObject.GetComponent<SpeedMod>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<SpeedMod>();
            }

            if (pixi) {
                if (GorillaTagger.Instance.gameObject.GetComponent<SpeedMod>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<SpeedMod>();
            }

            if (rgrip85) {
                if (GorillaTagger.Instance.gameObject.GetComponent<SpeedMod>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<SpeedMod>();
            }

            if (rgrip95) {
                if (GorillaTagger.Instance.gameObject.GetComponent<SpeedMod>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<SpeedMod>();
            }

            if (lgrip85) {
                if (GorillaTagger.Instance.gameObject.GetComponent<SpeedMod>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<SpeedMod>();
            }

            if (lgrip95) {
                if (GorillaTagger.Instance.gameObject.GetComponent<SpeedMod>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<SpeedMod>();
            }

            if (tfly) {
                if (GorillaTagger.Instance.gameObject.GetComponent<TFly>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<TFly>();
            }

            if (upsidedownmonkey) {
                if (GorillaTagger.Instance.gameObject.GetComponent<UpsideDownMonkey>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<UpsideDownMonkey>();
            }

            if (colossalsettingswallwalk) {
                if (GorillaTagger.Instance.gameObject.GetComponent<WallWalk>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<WallWalk>();
            }

            if (ghostwallwalk) {
                if (GorillaTagger.Instance.gameObject.GetComponent<WallWalk>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<WallWalk>();
            }

            if (blatantwallwalk) {
                if (GorillaTagger.Instance.gameObject.GetComponent<WallWalk>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<WallWalk>();
            }

            /*if (chams) {
                if (GorillaTagger.Instance.gameObject.GetComponent<Chams>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<Chams>();
            }

            if (boxesp) {
                if (GorillaTagger.Instance.gameObject.GetComponent<BoxEsp>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<BoxEsp>();
            }

            if (hollowboxesp) {
                if (GorillaTagger.Instance.gameObject.GetComponent<HollowBoxEsp>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<HollowBoxEsp>();
            }*/

            if (creepermonkey) {
                if (GorillaTagger.Instance.gameObject.GetComponent<CreeperMonkey>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<CreeperMonkey>();
            }

            /*if (ghostmonkey) {
                if (GorillaTagger.Instance.gameObject.GetComponent<GhostMonkey>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<GhostMonkey>();
            }

            if (invismonkey) {
                if (GorillaTagger.Instance.gameObject.GetComponent<InvisMonkey>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<InvisMonkey>();
            }*/

            if (legmod) {
                if (GorillaTagger.Instance.gameObject.GetComponent<LegMod>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<LegMod>();
            }

            /*if (taggun) {
                if (GorillaTagger.Instance.gameObject.GetComponent<TagGun>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<TagGun>();
            }*/

            if (breakmodcheckers) {
                if (GorillaTagger.Instance.gameObject.GetComponent<BreakModChecker>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<BreakModChecker>();
            }

            if (breaknametags) {
                if (GorillaTagger.Instance.gameObject.GetComponent<BreakNameTags>() == null)
                    GorillaTagger.Instance.gameObject.AddComponent<BreakNameTags>();
            }
        }
    }
}