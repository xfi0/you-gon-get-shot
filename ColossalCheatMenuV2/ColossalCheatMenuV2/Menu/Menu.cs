using BepInEx;
using Colossal;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;
using UnityEngine;
using Colossal.Mods;
using UnityEngine.XR;
using GorillaNetworking;
using Photon.Pun;
using PlayFab;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;
using ExitGames.Client.Photon;
using Colossal.Menu.ClientHub;
using HarmonyLib;
using System.Reflection;
using Photon.Realtime;

[assembly: MelonInfo(typeof(MyMod), "Xfi0xcolossal", "1.0", "xfi0")]
[assembly: MelonGame("Lemming(shitter)", "Gorilla tag")]

namespace Colossal.Menu {
    public class MenuOption {
        public string DisplayName;
        public string _type;
        public bool AssociatedBool;
        public string AssociatedString;
        public float AssociatedFloat;
        public int AssociatedInt;
    }
    public class Menu {
        public static bool GUIToggled = true;

        static GameObject HUDObj;
        static GameObject HUDObj2;
        static GameObject MainCamera;
        static Text Testtext;
        private static TextAnchor textAnchor = TextAnchor.UpperRight;
        static Material AlertText = new Material(Shader.Find("GUI/Text Shader"));
        static Text NotifiText;

        public static string MenuState = "Main";
        public static string MenuColour = "magenta";
        public static bool MenuRGB = false;
        public static float menurgb = 0;
        public static int SelectedOptionIndex = 0;
        public static MenuOption[] CurrentViewingMenu = null;
        public static MenuOption[] MainMenu;
        public static MenuOption[] Movement;
        public static MenuOption[] Visual;
        public static MenuOption[] Player;
        public static MenuOption[] Computer;
        public static MenuOption[] Modders;
        public static MenuOption[] Account;
        public static MenuOption[] Settings;
        public static MenuOption[] Goofy;

        public static MenuOption[] Speed;
        public static MenuOption[] TagAura;
        public static MenuOption[] Presets;
        public static MenuOption[] WallWalk;
        public static MenuOption[] Sky;

        public static bool inputcooldown = false;
        public static bool menutogglecooldown = false;

        public static bool driftmode = false;
        public static bool noti = true;
        public static bool overlay = true;
        public static bool agreement = false;
        public static void LoadOnce() {
            try {
                if (!agreement) {
                   
            NotifiLib.MainCamera = GameObject.Find("Main Camera");
            NotifiLib.HUDObj = new GameObject();
            NotifiLib.HUDObj2 = new GameObject();
            NotifiLib.HUDObj2.name = "HUB_AGREEMENT";
            NotifiLib.HUDObj.name = "HUB_AGREEMENT";
            NotifiLib.HUDObj.AddComponent<Canvas>();
            NotifiLib.HUDObj.AddComponent<CanvasScaler>();
            NotifiLib.HUDObj.AddComponent<GraphicRaycaster>();
            NotifiLib.HUDObj.GetComponent<Canvas>().enabled = true;
            NotifiLib.HUDObj.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
            NotifiLib.HUDObj.GetComponent<Canvas>().worldCamera = NotifiLib.MainCamera.GetComponent<Camera>();
            NotifiLib.HUDObj.GetComponent<RectTransform>().sizeDelta = new Vector2(5f, 5f);
           HUDObj.GetComponent<RectTransform>().position = new Vector3(MainCamera.transform.position.x, MainCamera.transform.position.y, MainCamera.transform.position.z);
                    HUDObj2.transform.position = new Vector3(MainCamera.transform.position.x, MainCamera.transform.position.y, MainCamera.transform.position.z - 4.6f);
                    HUDObj.transform.parent = HUDObj2.transform;
            NotifiLib.HUDObj.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 1.6f);
            Vector3 eulerAngles = NotifiLib.HUDObj.GetComponent<RectTransform>().rotation.eulerAngles;
            eulerAngles.y = -270f;
            NotifiLib.HUDObj.transform.localScale = new Vector3(1f, 1f, 1f);
            NotifiLib.HUDObj.GetComponent<RectTransform>().rotation = Quaternion.Euler(eulerAngles);
                    GameObject TestText = new GameObject();
                    TestText.transform.parent = HUDObj.transform;
                    Testtext = TestText.AddComponent<Text>();
                    Testtext.text = "<color=magenta><CONTROLS (DRIFT MODE)></color>\nLeft Joystick (Hold): Control\nRight Grip: Select\nRight Trigger: Move\nBoth Joysticks: Toggle\n\n<color=magenta><CONTROLS></color>\nRight Joystick (Right): Select\nRight Joystick (Down): Move\nBoth Joysticks: Toggle\n\n<color=magenta><CONTROLS (PC)></color>\nEnterKey: Select\nArrowKey (Up): Move Up\nArrowKey (Down): Move Down\n\n<color=cyan>Press Both Joysticks Or Enter...</color>";
                    Testtext.fontSize = 10;
                    Testtext.font = GameObject.Find("COC Text").GetComponent<Text>().font;
                    Testtext.rectTransform.sizeDelta = new Vector2(260, 300);
                    Testtext.rectTransform.localScale = new Vector3(0.01f, 0.01f, 1f);
                    Testtext.rectTransform.localPosition = new Vector3(-2.4f, -0.4f, 1f);
                    Testtext.material = AlertText;
                    NotifiText = Testtext;
                    Testtext.alignment = TextAnchor.UpperLeft;

                    HUDObj2.transform.transform.position = new Vector3(MainCamera.transform.position.x, MainCamera.transform.position.y, MainCamera.transform.position.z);
                    HUDObj2.transform.rotation = MainCamera.transform.rotation;
                } else {
                    if (GorillaTagger.Instance.gameObject.GetComponent<Overlay>() == null)
                        GorillaTagger.Instance.gameObject.AddComponent<Overlay>();

                    if (GorillaTagger.Instance.gameObject.GetComponent<Notifacations>() == null)
                        GorillaTagger.Instance.gameObject.AddComponent<Notifacations>();

                     NotifiLib.MainCamera = GameObject.Find("Main Camera");
            NotifiLib.HUDObj = new GameObject();
            NotifiLib.HUDObj2 = new GameObject();
            NotifiLib.HUDObj2.name = "CLIENT";
            NotifiLib.HUDObj.name = "CLIENT";
            NotifiLib.HUDObj.AddComponent<Canvas>();
            NotifiLib.HUDObj.AddComponent<CanvasScaler>();
            NotifiLib.HUDObj.AddComponent<GraphicRaycaster>();
            NotifiLib.HUDObj.GetComponent<Canvas>().enabled = true;
            NotifiLib.HUDObj.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
            NotifiLib.HUDObj.GetComponent<Canvas>().worldCamera = NotifiLib.MainCamera.GetComponent<Camera>();
            NotifiLib.HUDObj.GetComponent<RectTransform>().sizeDelta = new Vector2(5f, 5f);
           HUDObj.GetComponent<RectTransform>().position = new Vector3(MainCamera.transform.position.x, MainCamera.transform.position.y, MainCamera.transform.position.z);
                    HUDObj2.transform.position = new Vector3(MainCamera.transform.position.x, MainCamera.transform.position.y, MainCamera.transform.position.z - 4.6f);
                    HUDObj.transform.parent = HUDObj2.transform;
            NotifiLib.HUDObj.GetComponent<RectTransform>().localPosition = new Vector3(0f, 0f, 1.6f);
            Vector3 eulerAngles = NotifiLib.HUDObj.GetComponent<RectTransform>().rotation.eulerAngles;
            eulerAngles.y = -270f;
            NotifiLib.HUDObj.transform.localScale = new Vector3(1f, 1f, 1f);
            NotifiLib.HUDObj.GetComponent<RectTransform>().rotation = Quaternion.Euler(eulerAngles);
                    GameObject TestText = new GameObject();
                    TestText.transform.parent = HUDObj.transform;
                    Testtext = TestText.AddComponent<Text>();
                    Testtext.text = "";
                    Testtext.fontSize = 10;
                    Testtext.font = GameObject.Find("COC Text").GetComponent<Text>().font;
                    Testtext.rectTransform.sizeDelta = new Vector2(260, 160);
                    Testtext.rectTransform.localScale = new Vector3(0.01f, 0.01f, 1f);
                    Testtext.rectTransform.localPosition = new Vector3(-2.4f, 1f, 2f);
                    Testtext.material = AlertText;
                    NotifiText = Testtext;
                    Testtext.alignment = TextAnchor.UpperLeft;

                    HUDObj2.transform.transform.position = new Vector3(MainCamera.transform.position.x, MainCamera.transform.position.y, MainCamera.transform.position.z);
                    HUDObj2.transform.rotation = MainCamera.transform.rotation;

                    MainMenu = new MenuOption[11];
                    MainMenu[0] = new MenuOption { DisplayName = "Movement", _type = "submenu", AssociatedString = "Movement" };
                    MainMenu[1] = new MenuOption { DisplayName = "Visual", _type = "submenu", AssociatedString = "Visual" };
                    MainMenu[2] = new MenuOption { DisplayName = "Player", _type = "submenu", AssociatedString = "Player" };
                    MainMenu[3] = new MenuOption { DisplayName = "Computer", _type = "submenu", AssociatedString = "Computer" };
                    MainMenu[4] = new MenuOption { DisplayName = "Modders", _type = "submenu", AssociatedString = "Modders" };
                    MainMenu[5] = new MenuOption { DisplayName = "Account", _type = "submenu", AssociatedString = "Account" };
                    MainMenu[6] = new MenuOption { DisplayName = "Settings", _type = "submenu", AssociatedString = "Settings" };
                    MainMenu[7] = new MenuOption { DisplayName = "DriftMode", _type = "toggle", AssociatedBool = true };
                    MainMenu[8] = new MenuOption { DisplayName = "AntiCrash", _type = "toggle", AssociatedBool = true };
                    MainMenu[9] = new MenuOption { DisplayName = "Notifacations", _type = "toggle", AssociatedBool = true };
                    MainMenu[10] = new MenuOption { DisplayName = "Overlay", _type = "toggle", AssociatedBool = true };

                    Movement = new MenuOption[10];
                    Movement[0] = new MenuOption { DisplayName = "ExcelFly", _type = "toggle", AssociatedBool = false };
                    Movement[1] = new MenuOption { DisplayName = "TFly", _type = "toggle", AssociatedBool = false };
                    Movement[2] = new MenuOption { DisplayName = "WallWalk", _type = "submenu", AssociatedString = "WallWalk" };
                    Movement[3] = new MenuOption { DisplayName = "Speed", _type = "submenu", AssociatedString = "Speed" };
                    Movement[4] = new MenuOption { DisplayName = "Platforms", _type = "toggle", AssociatedBool = false };
                    Movement[5] = new MenuOption { DisplayName = "UpsideDown Monkey", _type = "toggle", AssociatedBool = false };
                    Movement[6] = new MenuOption { DisplayName = "FreezeMonkey", _type = "toggle", AssociatedBool = false };
                    Movement[7] = new MenuOption { DisplayName = "WateryAir", _type = "toggle", AssociatedBool = false };
                    Movement[8] = new MenuOption { DisplayName = "LongArms", _type = "toggle", AssociatedBool = false };
                    Movement[9] = new MenuOption { DisplayName = "Back", _type = "submenu", AssociatedString = "Back" };
                    Speed = new MenuOption[8];
                    Speed[0] = new MenuOption { DisplayName = "Mosa(7.5)", _type = "toggle", AssociatedBool = false };
                    Speed[1] = new MenuOption { DisplayName = "Coke(8.5)", _type = "toggle", AssociatedBool = false };
                    Speed[2] = new MenuOption { DisplayName = "Pixi(9.5)", _type = "toggle", AssociatedBool = false };
                    Speed[3] = new MenuOption { DisplayName = "RGrip(8.5)", _type = "toggle", AssociatedBool = false };
                    Speed[4] = new MenuOption { DisplayName = "RGrip(9.5)", _type = "toggle", AssociatedBool = false };
                    Speed[5] = new MenuOption { DisplayName = "LGrip(8.5)", _type = "toggle", AssociatedBool = false };
                    Speed[6] = new MenuOption { DisplayName = "LGrip(9.5)", _type = "toggle", AssociatedBool = false };
                    Speed[7] = new MenuOption { DisplayName = "Back", _type = "submenu", AssociatedString = "Back" };
                    WallWalk = new MenuOption[4];
                    WallWalk[0] = new MenuOption { DisplayName = "WallWalk (Colossal)", _type = "toggle", AssociatedBool = false };
                    WallWalk[1] = new MenuOption { DisplayName = "WallWalk (Ghost)", _type = "toggle", AssociatedBool = false };
                    WallWalk[2] = new MenuOption { DisplayName = "WallWalk (Blatant)", _type = "toggle", AssociatedBool = false };
                    WallWalk[3] = new MenuOption { DisplayName = "Back", _type = "submenu", AssociatedString = "Back" };

                    Visual = new MenuOption[6];
                    Visual[0] = new MenuOption { DisplayName = "---", _type = "toggle", AssociatedBool = false };
                    Visual[1] = new MenuOption { DisplayName = "---", _type = "toggle", AssociatedBool = false };
                    Visual[2] = new MenuOption { DisplayName = "---", _type = "toggle", AssociatedBool = false };
                    Visual[3] = new MenuOption { DisplayName = "Sky Colour", _type = "submenu", AssociatedString = "Sky" };
                    Visual[4] = new MenuOption { DisplayName = "WhyIsEveryoneLookingAtMe", _type = "toggle", AssociatedBool = false };
                    Visual[5] = new MenuOption { DisplayName = "Back", _type = "submenu", AssociatedString = "Back" };
                    Sky = new MenuOption[6];
                    Sky[0] = new MenuOption { DisplayName = "MonkeyColour", _type = "button", AssociatedString = "monkeycoloursky" };
                    Sky[1] = new MenuOption { DisplayName = "Purple", _type = "button", AssociatedString = "purplesky" };
                    Sky[2] = new MenuOption { DisplayName = "Red", _type = "button", AssociatedString = "redsky" };
                    Sky[3] = new MenuOption { DisplayName = "Cyan", _type = "button", AssociatedString = "cyansky" };
                    Sky[4] = new MenuOption { DisplayName = "Green", _type = "button", AssociatedString = "greensky" };
                    Sky[5] = new MenuOption { DisplayName = "Back", _type = "submenu", AssociatedString = "Back" };

                    Player = new MenuOption[9];
                    Player[0] = new MenuOption { DisplayName = "NoFinger", _type = "toggle", AssociatedBool = false };
                    Player[1] = new MenuOption { DisplayName = "TagGun", _type = "toggle", AssociatedBool = false };
                    Player[2] = new MenuOption { DisplayName = "LegMod", _type = "toggle", AssociatedBool = false };
                    Player[3] = new MenuOption { DisplayName = "CreeperMonkey", _type = "toggle", AssociatedBool = false };
                    Player[4] = new MenuOption { DisplayName = "GhostMonkey", _type = "toggle", AssociatedBool = false };
                    Player[5] = new MenuOption { DisplayName = "InvisMonkey", _type = "toggle", AssociatedBool = false };
                    Player[6] = new MenuOption { DisplayName = "TagAura", _type = "submenu", AssociatedString = "TagAura" };
                    Player[7] = new MenuOption { DisplayName = "TagAll", _type = "toggle", AssociatedBool = false };
                    Player[8] = new MenuOption { DisplayName = "Back", _type = "submenu", AssociatedString = "Back" };
                    TagAura = new MenuOption[4];
                    TagAura[0] = new MenuOption { DisplayName = "TagAura (Colossal)", _type = "toggle", AssociatedBool = false };
                    TagAura[1] = new MenuOption { DisplayName = "TagAura (Ghost)", _type = "toggle", AssociatedBool = false };
                    TagAura[2] = new MenuOption { DisplayName = "TagAura (Blatant)", _type = "toggle", AssociatedBool = false };
                    TagAura[3] = new MenuOption { DisplayName = "Back", _type = "submenu", AssociatedString = "Back" };

                    Modders = new MenuOption[5];
                    Modders[0] = new MenuOption { DisplayName = "Break NameTags", _type = "toggle", AssociatedBool = false };
                    Modders[1] = new MenuOption { DisplayName = "Break ModCheckers", _type = "toggle", AssociatedBool = false };
                    Modders[2] = new MenuOption { DisplayName = "No Snitch", _type = "button", AssociatedString = "nosnitch" };
                    Modders[3] = new MenuOption { DisplayName = "Pc Check Bypass", _type = "toggle", AssociatedBool = false };
                    Modders[4] = new MenuOption { DisplayName = "Back", _type = "submenu", AssociatedString = "Back" };

                    Computer = new MenuOption[8];
                    Computer[0] = new MenuOption { DisplayName = "Disconnect", _type = "button", AssociatedString = "disconnect" };
                    Computer[1] = new MenuOption { DisplayName = "RandomIdentity", _type = "button", AssociatedString = "randomidentity" };
                    Computer[2] = new MenuOption { DisplayName = "Join CGT", _type = "button", AssociatedString = "joincgt" };
                    Computer[3] = new MenuOption { DisplayName = "Join TTT", _type = "button", AssociatedString = "jointtt" };
                    Computer[4] = new MenuOption { DisplayName = "Join CBOT", _type = "button", AssociatedString = "joincbot" };
                    Computer[5] = new MenuOption { DisplayName = "Modded Casual", _type = "button", AssociatedString = "moddedcasual" };
                    Computer[6] = new MenuOption { DisplayName = "Modded Infection", _type = "button", AssociatedString = "moddedinfection" };
                    Computer[7] = new MenuOption { DisplayName = "Back", _type = "submenu", AssociatedString = "Back" };

                    Account = new MenuOption[5];
                    Account[0] = new MenuOption { DisplayName = "Disconnect", _type = "button", AssociatedString = "disconnectplayfab" };
                    Account[1] = new MenuOption { DisplayName = "Server: USW", _type = "button", AssociatedString = "serverusw" };
                    Account[2] = new MenuOption { DisplayName = "Server: US", _type = "button", AssociatedString = "serverus" };
                    Account[3] = new MenuOption { DisplayName = "Server: EU", _type = "button", AssociatedString = "servereu" };
                    Account[4] = new MenuOption { DisplayName = "Back", _type = "submenu", AssociatedString = "Back" };

                    Settings = new MenuOption[9];
                    Settings[0] = new MenuOption { DisplayName = "MenuColour : Purple", _type = "button", AssociatedString = "menupurple" };
                    Settings[1] = new MenuOption { DisplayName = "MenuColour : Red", _type = "button", AssociatedString = "menured" };
                    Settings[2] = new MenuOption { DisplayName = "MenuColour : Yellow", _type = "button", AssociatedString = "menuyellow" };
                    Settings[3] = new MenuOption { DisplayName = "MenuColour : Green", _type = "button", AssociatedString = "menugreen" };
                    Settings[4] = new MenuOption { DisplayName = "MenuColour : Blue", _type = "button", AssociatedString = "menublue" };
                    Settings[5] = new MenuOption { DisplayName = "MenuColour : RGB", _type = "toggle", AssociatedBool = false };
                    Settings[6] = new MenuOption { DisplayName = "MenuPos : TopRight", _type = "button", AssociatedString = "topright" };
                    Settings[7] = new MenuOption { DisplayName = "MenuPos : Middle", _type = "button", AssociatedString = "topmiddle" };
                    Settings[8] = new MenuOption { DisplayName = "Back", _type = "submenu", AssociatedString = "Back" };

                    MenuState = "Main";
                    CurrentViewingMenu = MainMenu;
                }

                UpdateMenuState(new MenuOption(), null, null);
            } catch(Exception ex) {
                Debug.Log(ex.ToString());
            }
            
        }
        public static void Load() {
            if(!agreement) {
                bool agreeL;
                bool agreeR;

                HUDObj2.transform.transform.position = new Vector3(MainCamera.transform.position.x, MainCamera.transform.position.y, MainCamera.transform.position.z);
                HUDObj2.transform.rotation = MainCamera.transform.rotation;

                InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisClick, out agreeL);
                InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisClick, out agreeR);
                if(agreeL && agreeR && !menutogglecooldown) {
                    menutogglecooldown = true;
                    agreement = true;
                    GameObject.Destroy(GameObject.Find("CLIENT_HUB_AGREEMENT"));
                    LoadOnce();
                } else {
                    menutogglecooldown = false;
                }

                Keyboard current = Keyboard.current;
                if (current.enterKey.wasPressedThisFrame) {
                    menutogglecooldown = true;
                    agreement = true;
                    GameObject.Destroy(GameObject.Find("CLIENT_HUB_AGREEMENT"));
                    LoadOnce();
                }
            } else {
                bool toggle;
                bool toggle2;

                InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisClick, out toggle);
                InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisClick, out toggle2);
                if (toggle && toggle2 && !menutogglecooldown) {
                    menutogglecooldown = true;
                    HUDObj2.active = !HUDObj2.active;
                    GUIToggled = !GUIToggled;
                }
                if (!toggle && !toggle2 && menutogglecooldown) {
                    menutogglecooldown = false;
                }

                if (GUIToggled) {
                    HUDObj2.transform.position = new Vector3(MainCamera.transform.position.x, MainCamera.transform.position.y, MainCamera.transform.position.z);
                    HUDObj2.transform.rotation = MainCamera.transform.rotation;

                    Keyboard current = Keyboard.current;
                    if (current.upArrowKey.wasPressedThisFrame) {
                        inputcooldown = true;
                        if (SelectedOptionIndex == 0)
                            SelectedOptionIndex = CurrentViewingMenu.Count() - 1;
                        else {
                            SelectedOptionIndex = SelectedOptionIndex - 1;
                        }

                        UpdateMenuState(new MenuOption(), null, null);
                    }
                    if (current.downArrowKey.wasPressedThisFrame) {
                        inputcooldown = true;
                        if ((SelectedOptionIndex + 1) == CurrentViewingMenu.Count())
                            SelectedOptionIndex = 0;
                        else {
                            SelectedOptionIndex = SelectedOptionIndex + 1;
                        }

                        UpdateMenuState(new MenuOption(), null, null);
                    }
                    if (current.enterKey.wasPressedThisFrame) {
                        inputcooldown = true;
                        UpdateMenuState(CurrentViewingMenu[SelectedOptionIndex], null, "optionhit");
                    }

                    if (!driftmode) {
                        Vector2 axis;
                        InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out axis);
                        if (axis.y >= 0.5f && !inputcooldown) {
                            inputcooldown = true;
                            if (SelectedOptionIndex == 0)
                                SelectedOptionIndex = CurrentViewingMenu.Count() - 1;
                            else {
                                SelectedOptionIndex = SelectedOptionIndex - 1;
                            }

                            UpdateMenuState(new MenuOption(), null, null);
                        }
                        if (axis.y >= -0.5f && !inputcooldown) {
                            inputcooldown = true;
                            if ((SelectedOptionIndex + 1) == CurrentViewingMenu.Count())
                                SelectedOptionIndex = 0;
                            else {
                                SelectedOptionIndex = SelectedOptionIndex + 1;
                            }

                            UpdateMenuState(new MenuOption(), null, null);
                        }
                        if (axis.x >= 0.2f && !inputcooldown) {
                            inputcooldown = true;
                            UpdateMenuState(CurrentViewingMenu[SelectedOptionIndex], null, "optionhit");
                        }

                        if (axis.y <= -0.5f && axis.y <= 0.5f && axis.x <= 0.2f && inputcooldown) {
                            inputcooldown = false;
                        }
                    } else {
                        bool holding;
                        InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisClick, out holding);
                        if (holding) {
                            bool down;
                            bool select;
                            InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out down);
                            InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out select);
                            if (down && !inputcooldown) {
                                inputcooldown = true;
                                if ((SelectedOptionIndex + 1) == CurrentViewingMenu.Count())
                                    SelectedOptionIndex = 0;
                                else {
                                    SelectedOptionIndex = SelectedOptionIndex + 1;
                                }

                                UpdateMenuState(new MenuOption(), null, null);
                            }
                            if (select && !inputcooldown) {
                                inputcooldown = true;
                                UpdateMenuState(CurrentViewingMenu[SelectedOptionIndex], null, "optionhit");
                            }
                            if (!down && !select && inputcooldown) {
                                inputcooldown = false;
                            }
                        }
                    }
                }
                //DriftMode
                Menu.driftmode = MainMenu[7].AssociatedBool;
                Plugin.anticrash = MainMenu[8].AssociatedBool;
                Menu.noti = MainMenu[9].AssociatedBool;
                Menu.overlay = MainMenu[10].AssociatedBool;

                //Movement
                Plugin.excelfly = Movement[0].AssociatedBool;
                Plugin.tfly = Movement[1].AssociatedBool;
                Plugin.platforms = Movement[4].AssociatedBool;
                Plugin.upsidedownmonkey = Movement[5].AssociatedBool;
                Plugin.freezemonkey = Movement[6].AssociatedBool;
                Plugin.wateryair = Movement[7].AssociatedBool;
                Plugin.longarms = Movement[8].AssociatedBool;
                //Speed
                Plugin.mosa = Speed[0].AssociatedBool;
                Plugin.coke = Speed[1].AssociatedBool;
                Plugin.pixi = Speed[2].AssociatedBool;
                Plugin.rgrip85 = Speed[3].AssociatedBool;
                Plugin.rgrip95 = Speed[4].AssociatedBool;
                Plugin.lgrip85 = Speed[5].AssociatedBool;
                Plugin.lgrip95 = Speed[6].AssociatedBool;

                //WallWalk
                Plugin.colossalsettingswallwalk = WallWalk[0].AssociatedBool;
                Plugin.ghostwallwalk = WallWalk[1].AssociatedBool;
                Plugin.blatantwallwalk = WallWalk[2].AssociatedBool;

                //Visual
                Plugin.chams = Visual[0].AssociatedBool;
                Plugin.boxesp = Visual[1].AssociatedBool;
                Plugin.hollowboxesp = Visual[2].AssociatedBool;
                Plugin.whyiseveryonelookingatme = Visual[4].AssociatedBool;

                //Player
                Plugin.nofinger = Player[0].AssociatedBool;
                Plugin.taggun = Player[1].AssociatedBool;
                Plugin.legmod = Player[2].AssociatedBool;
                Plugin.creepermonkey = Player[3].AssociatedBool;
                Plugin.ghostmonkey = Player[4].AssociatedBool;
                Plugin.invismonkey = Player[5].AssociatedBool;
                Plugin.tagall = Player[7].AssociatedBool;
                //tag aura
                Plugin.tagauracolossal = TagAura[0].AssociatedBool;
                Plugin.tagauraghost = TagAura[1].AssociatedBool;
                Plugin.tagaurablatant = TagAura[2].AssociatedBool;

                //Modders
                Plugin.breaknametags = Modders[0].AssociatedBool;
                Plugin.breakmodcheckers = Modders[1].AssociatedBool;
                Plugin.pccheckbypass = Modders[3].AssociatedBool;

                MenuRGB = Settings[5].AssociatedBool;
                if (MenuRGB) {
                    if (menurgb >= 0.1f) {
                        MenuColour = "magenta";
                    }
                    if (menurgb >= 0.2f) {
                        MenuColour = "red";
                    }
                    if (menurgb >= 0.3f) {
                        MenuColour = "green";
                    }
                    if (menurgb >= 0.4f) {
                        MenuColour = "blue";
                    }
                    if (menurgb >= 0.5f) {
                        MenuColour = "cyan";
                    }
                    if (menurgb >= 0.6f) {
                        MenuColour = "yellow";
                    }
                    if (menurgb >= 0.6f) {
                        menurgb = 0;
                    }
                    if (Plugin.sussy) {
                        string ToDraw = $"<color={MenuColour}>SUSSY : {MenuState}</color>\n";
                        int i = 0;
                        if (CurrentViewingMenu != null) {
                            foreach (MenuOption opt in CurrentViewingMenu) {
                                if (SelectedOptionIndex == i) {
                                    ToDraw = ToDraw + ">";
                                }
                                ToDraw = ToDraw + opt.DisplayName;

                                if (opt._type == "toggle") {
                                    if (opt.AssociatedBool == true) {
                                        ToDraw = ToDraw + $" <color={MenuColour}>[ON]</color>";
                                    } else {
                                        ToDraw = ToDraw + " <color=red>[OFF]</color>";
                                    }
                                }
                                ToDraw = ToDraw + "\n";
                                i++;
                            }
                            Testtext.text = ToDraw;
                        } else {
                            Debug.Log("Null for some reason");
                        }
                    } else {
                        string ToDraw = $"<color={MenuColour}>COLOSSAL : {MenuState}</color>\n";
                        int i = 0;
                        if (CurrentViewingMenu != null) {
                            foreach (MenuOption opt in CurrentViewingMenu) {
                                if (SelectedOptionIndex == i) {
                                    ToDraw = ToDraw + ">";
                                }
                                ToDraw = ToDraw + opt.DisplayName;

                                if (opt._type == "toggle") {
                                    if (opt.AssociatedBool == true) {
                                        ToDraw = ToDraw + $" <color={MenuColour}>[ON]</color>";
                                    } else {
                                        ToDraw = ToDraw + " <color=red>[OFF]</color>";
                                    }
                                }
                                ToDraw = ToDraw + "\n";
                                i++;
                            }
                            Testtext.text = ToDraw;
                        } else {
                            Debug.Log("Null for some reason");
                        }
                    }
                }
            }
        }
        static void UpdateMenuState(MenuOption option, string _MenuState, string OperationType) {
            try {
                if (OperationType == "optionhit") {
                    if (option._type == "submenu") {
                        if (option.AssociatedString == "Movement") {
                            CurrentViewingMenu = Movement;
                            Debug.Log("<color=magenta>Movement...</color>");
                        }
                        if (option.AssociatedString == "Visual") {
                            CurrentViewingMenu = Visual;
                            Debug.Log("<color=magenta>Visual...</color>");
                        }
                        if (option.AssociatedString == "Player") {
                            CurrentViewingMenu = Player;
                            Debug.Log("<color=magenta>Player...</color>");
                        }
                        if (option.AssociatedString == "Computer") {
                            CurrentViewingMenu = Computer;
                            Debug.Log("<color=magenta>Computer...</color>");
                        }
                        if (option.AssociatedString == "Modders") {
                            CurrentViewingMenu = Modders;
                            Debug.Log("<color=magenta>Modders...</color>");
                        }
                        if (option.AssociatedString == "Account") {
                            CurrentViewingMenu = Account;
                            Debug.Log("<color=magenta>Account...</color>");
                        }
                        if (option.AssociatedString == "Settings") {
                            CurrentViewingMenu = Settings;
                            Debug.Log("<color=magenta>Settings...</color>");
                        }
                        if (option.AssociatedString == "Goofy") {
                            CurrentViewingMenu = Goofy;
                            Debug.Log("<color=magenta>Goofy...</color>");
                        }
                        if (option.AssociatedString == "DriftMode") {
                            CurrentViewingMenu = Account;
                            Debug.Log("<color=magenta>Account...</color>");
                        }
                        if (option.AssociatedString == "Back") {
                            CurrentViewingMenu = MainMenu;
                            Debug.Log("<color=magenta>Back...</color>");
                        }

                        if (option.AssociatedString == "Speed") {
                            CurrentViewingMenu = Speed;
                            Debug.Log("<color=magenta>Speed...</color>");
                        }
                        if (option.AssociatedString == "TagAura") {
                            CurrentViewingMenu = TagAura;
                            Debug.Log("<color=magenta>TagAura...</color>");
                        }
                        if (option.AssociatedString == "WallWalk") {
                            CurrentViewingMenu = WallWalk;
                            Debug.Log("<color=magenta>WallWalk...</color>");
                        }
                        if (option.AssociatedString == "Sky") {
                            CurrentViewingMenu = Sky;
                        }
                        MenuState = option.AssociatedString;
                        SelectedOptionIndex = 0;
                    }
                    if (option._type == "toggle") {
                        if (option.AssociatedBool == false) {
                            option.AssociatedBool = true;
                            CustomConsole.LogToConsole($"\nToggled {option.DisplayName} : {option.AssociatedBool}");
                            Notifacations.SendNotification($"<color={MenuColour}>[TOGGLED]</color> {option.DisplayName} : {option.AssociatedBool}");
                        } else {
                            option.AssociatedBool = false;
                            CustomConsole.LogToConsole($"\nToggled {option.DisplayName} : {option.AssociatedBool}");
                            Notifacations.SendNotification($"<color={MenuColour}>[TOGGLED]</color> {option.DisplayName} : {option.AssociatedBool}");
                        }
                    }
                    if (option._type == "button") {
                        //Computer
                        if (option.AssociatedString == "disconnect") {
                            PhotonNetworkController.Instance.AttemptDisconnect();
                        }
                        if (option.AssociatedString == "randomidentity") {
                            string[] names =
                            {
                                "COLOSSUS",
                                "123",
                                "PP",
                                "PBBV",
                                "SKILLISSUE",
                                "IMAGINE",
                                "SREN17",
                                "YOURMOM",
                                "GUMMIES",
                                "WATCH",
                                "MOUSE",
                                "BOZO",
                                "KEYS",
                                "PINE",
                                "LEMMING",
                                "ELECTRONIC",
                                "BODA",
                                "TTTPIG",
                                "TTTPIGFAN",
                                "555999",
                                "83459230",
                                "923059439",
                                "IJ48FNSF",
                                "MF4J8T9J",
                                "J3VU",
                                "3993NF39",
                            };
                            System.Random rand = new System.Random();
                            int index = rand.Next(names.Length);
                            PhotonNetwork.LocalPlayer.NickName = names[index];
                            GorillaComputer.instance.currentName = names[index];
                            GorillaComputer.instance.savedName = names[index];
                            PlayerPrefs.SetString("GorillaLocomotion.PlayerName", names[index]);
                        }
                        if (option.AssociatedString == "joincgt") {
                            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom("CGT");
                        }
                        if (option.AssociatedString == "jointtt") {
                            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom("TTT");
                        }
                        if (option.AssociatedString == "joincbot") {
                            PhotonNetworkController.Instance.AttemptToJoinSpecificRoom("CBOT");
                        }
                        if (option.AssociatedString == "moddedcasual") {
                            GorillaComputer.instance.currentGameMode = "MODDED_MODDED_CASUALCASUAL";
                        }
                        if (option.AssociatedString == "moddedinfection") {
                            GorillaComputer.instance.currentGameMode = "MODDED_MODDED_DEFAULTINFECTION";
                        }

                        //Account
                        if (option.AssociatedString == "disconnectplayfab") {
                            PhotonNetwork.Disconnect();
                            PhotonNetworkController.Instance.FullDisconnect();
                            PlayFabClientAPI.ForgetAllCredentials();
                        }
                        if (option.AssociatedString == "serverusw") {
                            PhotonNetworkController.Instance.FullDisconnect();
                            PhotonNetworkController.Instance.ConnectToRegion("USW");
                            PhotonNetworkController.Instance.InitiateConnection();
                        }
                        if (option.AssociatedString == "serverus") {
                            PhotonNetworkController.Instance.FullDisconnect();
                            PhotonNetworkController.Instance.ConnectToRegion("USW");
                            PhotonNetworkController.Instance.InitiateConnection();
                        }
                        if (option.AssociatedString == "servereu") {
                            PhotonNetworkController.Instance.FullDisconnect();
                            PhotonNetworkController.Instance.ConnectToRegion("EU");
                            PhotonNetworkController.Instance.InitiateConnection();
                        }

                        //Sky
                        if (option.AssociatedString == "monkeycoloursky") {
                            GameObject gameObject = GameObject.Find("Level/newsky");
                            gameObject.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
                            gameObject.GetComponent<MeshRenderer>().material.color = new Color(GorillaTagger.Instance.myVRRig.GetComponent<SkinnedMeshRenderer>().material.color.r, GorillaTagger.Instance.myVRRig.GetComponent<SkinnedMeshRenderer>().material.color.g, GorillaTagger.Instance.myVRRig.GetComponent<SkinnedMeshRenderer>().material.color.b);
                        }
                        if (option.AssociatedString == "purplesky") {
                            GameObject gameObject = GameObject.Find("Level/newsky");
                            gameObject.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
                            gameObject.GetComponent<MeshRenderer>().material.color = Color.magenta;
                        }
                        if (option.AssociatedString == "redsky") {
                            GameObject gameObject = GameObject.Find("Level/newsky");
                            gameObject.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
                            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                        }
                        if (option.AssociatedString == "cyansky") {
                            GameObject gameObject = GameObject.Find("Level/newsky");
                            gameObject.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
                            gameObject.GetComponent<MeshRenderer>().material.color = Color.cyan;
                        }
                        if (option.AssociatedString == "greensky") {
                            GameObject gameObject = GameObject.Find("Level/newsky");
                            gameObject.GetComponent<MeshRenderer>().material.shader = Shader.Find("Standard");
                            gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                        }

                        if (option.AssociatedString == "menupurple") {
                            MenuColour = "magenta";
                        }
                        if (option.AssociatedString == "menured") {
                            MenuColour = "red";
                        }
                        if (option.AssociatedString == "menuyellow") {
                            MenuColour = "yellow";
                        }
                        if (option.AssociatedString == "menugreen") {
                            MenuColour = "green";
                        }
                        if (option.AssociatedString == "menublue") {
                            MenuColour = "cyan";
                        }
                        if(option.AssociatedString == "topright") {
                            Testtext.rectTransform.localPosition = new Vector3(-2.4f, 1f, 2f);
                        }
                        if (option.AssociatedString == "topmiddle") {
                            Testtext.rectTransform.localPosition = new Vector3(-0.8f, 0f, 1f);
                        }

                        if (option.AssociatedString == "nosnitch") {
                            if (PhotonNetwork.InRoom) {
                                if (!Plugin.GetPhotonViewFromVR(GorillaTagger.Instance.myVRRig.gameObject).Controller.CustomProperties.ContainsValue("You know mod checkers are a illegal mod right :p")) {
                                    Hashtable hash = new Hashtable();
                                    hash.Add("mods", "You know mod checkers are a illegal mod right :p");
                                    Plugin.GetPhotonViewFromVR(GorillaTagger.Instance.myVRRig.gameObject).Controller.SetCustomProperties(hash);
                                }
                            }
                        }
                    }
                }
            } catch {
            }
            if (!MenuRGB) {
                if (Plugin.sussy) {
                    string ToDraw = $"<color={MenuColour}>SUSSY : {MenuState}</color>\n";
                    int i = 0;
                    if (CurrentViewingMenu != null) {
                        foreach (MenuOption opt in CurrentViewingMenu) {
                            if (SelectedOptionIndex == i) {
                                ToDraw = ToDraw + ">";
                            }
                            ToDraw = ToDraw + opt.DisplayName;

                            if (opt._type == "toggle") {
                                if (opt.AssociatedBool == true) {
                                    ToDraw = ToDraw + $" <color={MenuColour}>[ON]</color>";
                                } else {
                                    ToDraw = ToDraw + " <color=red>[OFF]</color>";
                                }
                            }
                            ToDraw = ToDraw + "\n";
                            i++;
                        }
                        Testtext.text = ToDraw;
                    } else {
                        Debug.Log("Null for some reason");
                    }
                } else {
                    string ToDraw = $"<color={MenuColour}>COLOSSAL : {MenuState}</color>\n";
                    int i = 0;
                    if (CurrentViewingMenu != null) {
                        foreach (MenuOption opt in CurrentViewingMenu) {
                            if (SelectedOptionIndex == i) {
                                ToDraw = ToDraw + ">";
                            }
                            ToDraw = ToDraw + opt.DisplayName;

                            if (opt._type == "toggle") {
                                if (opt.AssociatedBool == true) {
                                    ToDraw = ToDraw + $" <color={MenuColour}>[ON]</color>";
                                } else {
                                    ToDraw = ToDraw + " <color=red>[OFF]</color>";
                                }
                            }
                            ToDraw = ToDraw + "\n";
                            i++;
                        }
                        Testtext.text = ToDraw;
                    } else {
                        Debug.Log("Null for some reason");
                    }
                }
            }
        }
    }
}
