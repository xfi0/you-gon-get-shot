using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR;
using static Colossal.Plugin;

namespace Colossal.Mods {
    public class PcCheckBypass : MonoBehaviour {
        public void Update() {
            if (Plugin.pccheckbypass) {
                if(GameObject.Find("Level").transform.Find("mountain").gameObject.activeSelf) {
                    if(GameObject.Find("Level/mountain/Geometry/goodigloo").activeSelf) {
                        GameObject.Find("Level/mountain/Geometry/goodigloo").SetActive(false);
                    }
                }
            } else {
                Destroy(GorillaTagger.Instance.GetComponent<PcCheckBypass>());
                if (!GameObject.Find("Level/mountain/Geometry/goodigloo").activeSelf) {
                    GameObject.Find("Level/mountain/Geometry/goodigloo").SetActive(true);
                }
            }
        }
    }
}
