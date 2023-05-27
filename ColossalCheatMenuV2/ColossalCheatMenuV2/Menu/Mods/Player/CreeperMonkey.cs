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
    public class CreeperMonkey : MonoBehaviour
    {
        public void Update()
        {
            if (Plugin.creepermonkey)
            {
                bool hand;
                bool head;
                InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(CommonUsages.triggerButton, out hand);
                InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(CommonUsages.triggerButton, out head);
                if (head)
                {
                    float num = float.PositiveInfinity;
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        if (!vrrig.isOfflineVRRig && vrrig != GorillaTagger.Instance.myVRRig)
                        {
                            float sqrMagnitude = (vrrig.transform.position - GorillaLocomotion.Player.Instance.transform.position).sqrMagnitude;
                            if (sqrMagnitude < num)
                            {
                                num = sqrMagnitude;
                                GameObject.Find("Global/GorillaParent/GorillaVRRigs/Gorilla Player Networked(Clone)/VR Constraints/Head Constraint").transform.LookAt(vrrig.headMesh.transform.position);
                            }
                        }
                    }
                }
                if (hand)
                {
                    float num = float.PositiveInfinity;
                    foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
                    {
                        if (!vrrig.isOfflineVRRig && vrrig != GorillaTagger.Instance.myVRRig)
                        {
                            float sqrMagnitude = (vrrig.transform.position - GorillaLocomotion.Player.Instance.transform.position).sqrMagnitude;
                            if (sqrMagnitude < num)
                            {
                                num = sqrMagnitude;
                                GameObject.Find("Global/GorillaParent/GorillaVRRigs/Gorilla Player Networked(Clone)/VR Constraints/RightArm/Right Arm IK/TargetWrist").transform.position = vrrig.headMesh.transform.position;
                            }
                        }
                    }
                }
            }
            else
            {
                Destroy(GorillaTagger.Instance.GetComponent<CreeperMonkey>());
            }
        }
    }
}
