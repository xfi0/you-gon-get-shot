using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.XR;
using static Colossal.Plugin;

namespace Colossal.Mods
{
    public class GhostMonkey : DynamicClass
    {
        public static bool ghostmonkey = false;
        public void Update()
        {
            if (ghostmonkey && PhotonNetwork.InRoom)
            {
                bool ghostR;
                InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out ghostR);
                if (ghostR)
                {
                    GorillaTagger.Instance.myVRRig.enabled = false;
                }
                else
                {
                    GorillaTagger.Instance.myVRRig.enabled = true;
                }
            }
        }
    }
}
