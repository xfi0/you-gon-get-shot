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
    public class SpeedMod : MonoBehaviour
    {
        public void Update()
        {
            if (Plugin.mosa)
            {
                GorillaLocomotion.Player.Instance.maxJumpSpeed = 7.5f;
            }
            if (Plugin.coke)
            {
                GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.5f;
            }
            if (Plugin.pixi)
            {
                GorillaLocomotion.Player.Instance.maxJumpSpeed = 9.5f;
            }
            if (Plugin.rgrip85)
            {
                bool grip;
                InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out grip);
                if (grip)
                {
                    GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.5f;
                }
            }
            if (Plugin.rgrip95)
            {
                bool grip;
                InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out grip);
                if (grip)
                {
                    GorillaLocomotion.Player.Instance.maxJumpSpeed = 9.5f;
                }
            }
            if (Plugin.lgrip85)
            {
                bool grip;
                InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out grip);
                if (grip)
                {
                    GorillaLocomotion.Player.Instance.maxJumpSpeed = 8.5f;
                }
            }
            if (Plugin.lgrip95)
            {
                bool grip;
                InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out grip);
                if (grip)
                {
                    GorillaLocomotion.Player.Instance.maxJumpSpeed = 9.5f;
                }
            }
            bool once = false;
            if (!Plugin.mosa && !Plugin.coke && !Plugin.pixi && !Plugin.rgrip85 && !Plugin.rgrip95 && !Plugin.lgrip85 && !Plugin.lgrip95 && !once)
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

                Destroy(GorillaTagger.Instance.GetComponent<SpeedMod>());
            }
        }
    }
}
