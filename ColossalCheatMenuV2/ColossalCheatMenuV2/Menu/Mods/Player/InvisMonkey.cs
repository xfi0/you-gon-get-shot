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
    public class InvisMonkey : MonoBehaviour
    {
        public void Update()
        {
            if (Plugin.invismonkey && PhotonNetwork.InRoom)
            {
                bool invisL;
                InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out invisL);
                if (invisL)
                {
                    GorillaTagger.Instance.myVRRig.enabled = !GorillaTagger.Instance.myVRRig.enabled;
                    GorillaTagger.Instance.myVRRig.transform.position = new Vector3(GorillaLocomotion.Player.Instance.headCollider.transform.position.x, -646.46466f, GorillaLocomotion.Player.Instance.headCollider.transform.position.z);
                }
            }
            else
            {
                Destroy(GorillaTagger.Instance.GetComponent<InvisMonkey>());
            }
        }
    }
}
