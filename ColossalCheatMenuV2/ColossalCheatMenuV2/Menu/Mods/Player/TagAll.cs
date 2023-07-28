using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR;
using static Colossal.Plugin;

namespace Colossal.Mods {
    public class TagAll : MonoBehaviour {
        private LineRenderer radiusLine;
        private Material lineMaterial;
        private GameObject[] objectsToDestroy;
        public void Update() {
            if (Plugin.tagall) {
                GorillaTagger.Instance.tagCooldown = 0;
                GorillaLocomotion.Player.Instance.teleportThresholdNoVel = int.MaxValue;
                foreach (VRRig vrrig in GameObject.Find("GorillaVRRigs").GetComponentsInChildren<VRRig>()) {
                    if (!vrrig.isMyPlayer) {
                        float distance = Vector3.Distance(GorillaTagger.Instance.offlineVRRig.transform.position, vrrig.transform.position);
                        if (distance < GorillaGameManager.instance.tagDistanceThreshold && !GorillaGameManager.instance.gameObject.GetComponent<GorillaTagManager>().currentInfectedArray.Contains(vrrig.myPlayer.ActorNumber)) {
                            if (GorillaGameManager.instance.gameObject.GetComponent<GorillaTagManager>().currentInfectedArray.Contains(Plugin.GetPhotonViewFromVR(GorillaTagger.Instance.offlineVRRig.gameObject).Owner.ActorNumber)) {
                                if (radiusLine == null) {
                                    lineMaterial = new Material(Shader.Find("Sprites/Default"));
                                    lineMaterial.color = new Color(0.6f, 0f, 0.8f, 0.5f);

                                    GameObject lineObject = new GameObject("RadiusLine");
                                    lineObject.transform.parent = vrrig.transform;
                                    radiusLine = lineObject.AddComponent<LineRenderer>();
                                    radiusLine.positionCount = 2;
                                    radiusLine.startWidth = 0.05f;
                                    radiusLine.endWidth = 0.05f;
                                    radiusLine.material = lineMaterial;
                                }
                                GorillaLocomotion.Player.Instance.rightControllerTransform.position = vrrig.transform.position;
                                radiusLine.SetPosition(0, vrrig.transform.position);
                                radiusLine.SetPosition(1, GorillaTagger.Instance.transform.position);
                                if (radiusLine.GetPosition(0) == null) {
                                    if (radiusLine != null) {
                                        Destroy(radiusLine);
                                        radiusLine = null;
                                    }
                                }
                            }
                        } else if(!GorillaGameManager.instance.gameObject.GetComponent<GorillaTagManager>().currentInfectedArray.Contains(vrrig.myPlayer.ActorNumber)) {
                            if (radiusLine == null) {
                                lineMaterial = new Material(Shader.Find("Sprites/Default"));
                                lineMaterial.color = new Color(0.6f, 0f, 0.8f, 0.5f);

                                GameObject lineObject = new GameObject("RadiusLine");
                                lineObject.transform.parent = vrrig.transform;
                                radiusLine = lineObject.AddComponent<LineRenderer>();
                                radiusLine.positionCount = 2;
                                radiusLine.startWidth = 0.05f;
                                radiusLine.endWidth = 0.05f;
                                radiusLine.material = lineMaterial;
                            }
                            GorillaLocomotion.Player.Instance.rightControllerTransform.position = vrrig.transform.position;
                            radiusLine.SetPosition(0, vrrig.transform.position);
                            radiusLine.SetPosition(1, GorillaLocomotion.Player.Instance.bodyCollider.transform.position);
                            if (radiusLine.GetPosition(0) == null) {
                                if (radiusLine != null) {
                                    Destroy(radiusLine);
                                    radiusLine = null;
                                }
                            }
                            GorillaTagger.Instance.offlineVRRig.transform.position = vrrig.transform.position;
                            GorillaTagger.Instance.offlineVRRig.enabled = false;
                            GorillaTagger.Instance.offlineVRRig.enabled = true;
                        }
                    }
                }
            } else {
                Destroy(GorillaTagger.Instance.GetComponent<TagAll>());
                GorillaTagger.Instance.offlineVRRig.enabled = true;
                if (radiusLine != null) {
                    Destroy(radiusLine.gameObject);
                    radiusLine = null;
                }
            }
        }
    }
}
