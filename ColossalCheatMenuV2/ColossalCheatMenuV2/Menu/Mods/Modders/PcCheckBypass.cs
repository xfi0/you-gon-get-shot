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
                if(GameObject.Find("Environment Objects/LocalObjects_Prefab").transform.Find("Mountain").gameObject.activeSelf) {
                    if(GameObject.Find("Environment Objects/LocalObjects_Prefab/Mountain/Geometry/goodigloo").activeSelf) {
                        GameObject.Find("Environment Objects/LocalObjects_Prefab/Mountain/Geometry/goodigloo").SetActive(false);
                    }
                }
            } else {
                Destroy(GorillaTagger.Instance.GetComponent<PcCheckBypass>());
                if (!GameObject.Find("Environment Objects/LocalObjects_Prefab/Mountain/Geometry/goodigloo").activeSelf) {
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/Mountain/Geometry/goodigloo").SetActive(true);
                }
            }
        }
    }
}
