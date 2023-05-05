using GorillaNetworking;
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
    public class BreakPunchMod : DynamicClass
    {
        public static bool breakpunchmod = false;
        private float counter;
        public void Update()
        {
            counter += Time.deltaTime;
            GorillaLocomotion.Player.Instance.teleportThresholdNoVel = int.MaxValue;

            if (breakpunchmod && PhotonNetwork.InRoom)
            {
                var photonViews = PhotonNetwork.PhotonViews;
                foreach (var photonView in photonViews)
                {
                    if (photonView.Owner != null && photonView.Owner != PhotonNetwork.LocalPlayer)
                    {
                        if (photonView.Controller.CustomProperties.ContainsKey("com.fault.gorillatag.punchmod"))
                        {
                            if(counter >= 2)
                            {
                                GorillaTagger.Instance.myVRRig.enabled = false;
                                GorillaTagger.Instance.myVRRig.transform.position = photonView.transform.position;
                                GorillaLocomotion.Player.Instance.rightHandTransform.position = photonView.transform.position;

                                counter = 0;
                            }
                        }
                    }
                }
            }
            else
            {
                counter = 0;
            }
        }
    }
}
