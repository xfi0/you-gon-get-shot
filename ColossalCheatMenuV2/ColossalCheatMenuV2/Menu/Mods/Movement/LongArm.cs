using Colossal.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR;
using static Colossal.Plugin;

namespace Colossal.Mods {
    public class LongArm : MonoBehaviour {
        private float armlenght;
        public void Update() {
            if (Plugin.longarms) {
                bool L;
                bool R;
                bool clickR;
                InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out L);
                InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out R);
                InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisClick, out clickR);
                if (L && clickR) {
                    armlenght -= 0.01f;
                    GorillaTagger.Instance.transform.localScale = new Vector3(armlenght, armlenght, armlenght);
                }
                if (R && clickR) {
                    armlenght += 0.01f;
                    GorillaTagger.Instance.transform.localScale = new Vector3(armlenght, armlenght, armlenght);
                }
                if (R && L && clickR) {
                    GorillaTagger.Instance.transform.localScale = new Vector3(1, 1, 1);
                }
            } else {
                Destroy(GorillaTagger.Instance.GetComponent<LongArm>());
                GorillaTagger.Instance.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
