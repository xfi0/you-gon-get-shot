using Mono.Cecil.Cil;
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
    public class SpeedMod : DynamicClass
    {
        public static bool mosa = false;
        public static bool coke = false;
        public static bool pixi = false;
        public static bool rgrip85 = false;
        public static bool rgrip95 = false;
        public static bool lgrip85 = false;
        public static bool lgrip95 = false;
        public void Update()
        {
            if (mosa)
            {
                GorillaLocomotion.Player.Instance.maxJumpSpeed = 7.5f;
            }
            if (coke)
            {
                GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.5f;
            }
            if (pixi)
            {
                GorillaLocomotion.Player.Instance.maxJumpSpeed = 9.5f;
            }
            if (rgrip85)
            {
                bool grip;
                InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out grip);
                if (grip)
                {
                    GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.5f;
                }
            }
            if (rgrip95)
            {
                bool grip;
                InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out grip);
                if (grip)
                {
                    GorillaLocomotion.Player.Instance.maxJumpSpeed = 9.5f;
                }
            }
            if (lgrip85)
            {
                bool grip;
                InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out grip);
                if (grip)
                {
                    GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.5f;
                }
            }
            if (lgrip95)
            {
                bool grip;
                InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out grip);
                if (grip)
                {
                    GorillaLocomotion.Player.Instance.maxJumpSpeed = 9.5f;
                }
            }
            bool once = false;
            if (!mosa && !coke && !pixi && !rgrip85 && !rgrip95 && !lgrip85 && !lgrip95 && !once)
            {
                foreach (VRRig vrrig in GameObject.Find("GorillaVRRigs").GetComponentsInChildren<VRRig>())
                {
                    if (vrrig.isOfflineVRRig && vrrig.isMyPlayer && vrrig.photonView.IsMine)
                    {
                        if (vrrig.mainSkin.material.name.Contains("fected"))
                        {
                            GorillaLocomotion.Player.Instance.maxJumpSpeed = 8f;
                        }
                        if (!vrrig.mainSkin.material.name.Contains("fected"))
                        {
                            GorillaLocomotion.Player.Instance.maxJumpSpeed = 6.5f;
                        }
                    }
                }
                once = true;
            }
        }
    }
}
