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
    public class FreezeMonkey : MonoBehaviour
    {
        public void Update()
        {
            if (Plugin.freezemonkey)
            {
                bool freeze;
                InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out freeze);
                if (freeze)
                {
                    GorillaTagger.Instance.myVRRig.enabled = false;
                    GorillaTagger.Instance.myVRRig.transform.position = GorillaLocomotion.Player.Instance.bodyCollider.transform.position;
                    GorillaTagger.Instance.myVRRig.transform.rotation = GorillaLocomotion.Player.Instance.bodyCollider.transform.rotation;
                }
                else
                {
                    GorillaTagger.Instance.myVRRig.enabled = true;
                }
            }
            else
            {
                Destroy(Plugin.hud.GetComponent<FreezeMonkey>());
            }
        }
    }
}
