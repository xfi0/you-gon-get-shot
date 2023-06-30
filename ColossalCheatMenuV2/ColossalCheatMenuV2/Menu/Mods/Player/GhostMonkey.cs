using Photon.Pun;
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
    public class GhostMonkey : MonoBehaviour
    {
        public void Update()
        {
            if (Plugin.ghostmonkey && PhotonNetwork.InRoom)
            {
                bool ghostR;
                InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out ghostR);
                if (ghostR)
                {
                    GorillaTagger.Instance.myVRRig.enabled = false;
                } else {
                    GorillaTagger.Instance.myVRRig.enabled = true;
                }
            }
            else
            {
                Destroy(GorillaTagger.Instance.GetComponent<GhostMonkey>());
            }
        }
    }
}
