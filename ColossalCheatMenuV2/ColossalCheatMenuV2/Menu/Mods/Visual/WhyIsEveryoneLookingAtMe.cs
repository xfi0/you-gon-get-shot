using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR;
using static Colossal.Plugin;

namespace Colossal.Mods {
    public class WhyIsEveryoneLookingAtMe : MonoBehaviour {
        public void Update() {
            if (Plugin.whyiseveryonelookingatme) {
                foreach (VRRig vrrig in GameObject.Find("GorillaVRRigs").GetComponentsInChildren<VRRig>()) {
                    if (!vrrig.isOfflineVRRig && !vrrig.isMyPlayer && !vrrig.photonView.IsMine) {
                        vrrig.transform.LookAt(GorillaLocomotion.Player.Instance.transform.position);
                    }
                }
            } else {
                Destroy(GorillaTagger.Instance.GetComponent<WhyIsEveryoneLookingAtMe>());
            }
        }
    }
}
