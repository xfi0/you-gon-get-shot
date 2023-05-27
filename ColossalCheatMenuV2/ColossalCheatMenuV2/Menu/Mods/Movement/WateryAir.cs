using GorillaLocomotion.Swimming;
using GorillaNetworking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR;
using static Colossal.Plugin;

namespace Colossal.Mods {
    public class WateryAir : MonoBehaviour {
        private GameObject waterbox;
        public void Update() {
            if (Plugin.wateryair) {
                if (waterbox == null) {
                    GameObject.Find("Level").transform.Find("ForestToBeach_Prefab_V4").gameObject.SetActive(true);
                    waterbox = GameObject.Instantiate(GameObject.Find("Level/ForestToBeach_Prefab_V4/CaveWaterVolume"));
                    GameObject.Destroy(waterbox.GetComponentInChildren<Renderer>());
                }
                else {
                    bool L;
                    bool R;
                    InputDevices.GetDeviceAtXRNode(XRNode.LeftHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out L);
                    InputDevices.GetDeviceAtXRNode(XRNode.RightHand).TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out R);
                    if (L && R) {
                        waterbox.transform.position = GorillaTagger.Instance.headCollider.transform.position + new Vector3(0, 1, 0);
                    }
                    else {
                        waterbox.transform.position = new Vector3(0, -6969, 0);
                    }
                }
            }
            else {
                Destroy(GorillaTagger.Instance.GetComponent<WateryAir>());
                if (waterbox != null) {
                    GameObject.Destroy(waterbox);
                    waterbox = null;
                }
            }
        }
    }
}
