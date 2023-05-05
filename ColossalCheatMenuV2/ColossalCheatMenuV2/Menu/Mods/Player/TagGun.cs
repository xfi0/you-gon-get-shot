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
    public class TagGun : DynamicClass
    {
        public static bool taggun = false;
        public void Update()
        {
            if (taggun && PhotonNetwork.InRoom)
            {
                bool shoot = false;
                InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisClick, out shoot);
                RaycastHit raycastHit;
                Physics.Raycast(GorillaLocomotion.Player.Instance.rightHandTransform.position - GorillaLocomotion.Player.Instance.rightHandTransform.up, -GorillaLocomotion.Player.Instance.rightHandTransform.up, out raycastHit);
                if (shoot)
                {
                    GorillaTagger.Instance.myVRRig.enabled = false;
                    GorillaTagger.Instance.myVRRig.transform.position = raycastHit.point;
                    GorillaLocomotion.Player.Instance.rightHandTransform.position = raycastHit.point;
                }
                else
                {
                    GorillaTagger.Instance.myVRRig.enabled = true;
                }
            }
        }
    }
}
