using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR;
using static Colossal.Plugin;

namespace Colossal.Mods
{
    public class Platforms : DynamicClass
    {
        public static bool platforms = false;
        public static GameObject PlatL;
        private bool PlatLonce = false;

        public static GameObject PlatR;
        private bool PlatRonce = false;
        public void Update()
        {
            if (platforms)
            {
                bool platL;
                bool platR;
                InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out platL);
                InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out platR);
                if (platL)
                {
                    if (!PlatLonce)
                    {
                        PlatL = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        //PlatL.GetComponent<Renderer>().material.color = Color.magenta;
                        PlatL.GetComponent<Renderer>().material.mainTexture = Plugin.texture;
                        PlatL.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                        PlatL.transform.position = GorillaLocomotion.Player.Instance.leftHandTransform.position;

                        PlatLonce = true;
                    }
                }
                else if (PlatLonce)
                {
                    UnityEngine.Object.Destroy(PlatL);
                    PlatLonce = false;
                }

                if (platR)
                {
                    if (!PlatRonce)
                    {
                        PlatR = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        //PlatR.GetComponent<Renderer>().material.color = Color.magenta;
                        PlatR.GetComponent<Renderer>().material.mainTexture = Plugin.texture;
                        PlatR.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
                        PlatR.transform.position = GorillaLocomotion.Player.Instance.rightHandTransform.position;

                        PlatRonce = true;
                    }
                }
                else if (PlatRonce)
                {
                    UnityEngine.Object.Destroy(PlatR);
                    PlatRonce = false;
                }
            }
        }
    }
}
