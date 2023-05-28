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
        private int armlenght;
        public void Update() {
            if (Plugin.longarms) {
                Vector2 axis;
                InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out axis);
                if (axis.y >= 0.5f) {
                    armlenght++;
                    GorillaTagger.Instance.myVRRig.transform.localScale = new Vector3(armlenght, armlenght, armlenght);
                }
                if (axis.y >= -0.5f) {
                    armlenght--;
                    GorillaTagger.Instance.myVRRig.transform.localScale = new Vector3(armlenght, armlenght, armlenght);
                }

                bool reset;
                InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxisClick, out reset);
                if(reset) {
                    GorillaTagger.Instance.myVRRig.transform.localScale = new Vector3(0, 0, 0);
                }
            } else {
                Destroy(GorillaTagger.Instance.GetComponent<LongArm>());
            }
        }
    }
}
